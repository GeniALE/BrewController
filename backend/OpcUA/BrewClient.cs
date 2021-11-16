using System;
using System.Linq;
using System.Threading.Tasks;
using BrewController.Models.GaugeModels;
using BrewController.Models.TogglerModels;
using BrewController.Utilities;
using HotChocolate.Subscriptions;
using MongoDB.Driver;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace BrewController.OpcUA
{
    public class BrewClient : OpcClient
    {
        private readonly IMongoDatabase _database;
        private readonly ITopicEventSender _sender;

        public BrewClient(IMongoDatabase database, ITopicEventSender sender)
            : base(Environment.GetEnvironmentVariable("BREW_OPCUA_SERVER_ADDRESS") ?? "opc.tcp://localhost:4840")
        {
            this._database = database;
            this._sender = sender;
            this.Connect();
        }

        public async Task<(string ObjectId, string ControllerType)> CreateController(OpcNodeInfo node, bool isInteractive)
        {
            var nodeDataType = (uint)node.Attribute(OpcAttribute.DataType).Value.AsValue<OpcNodeId>().Value.Value;

            switch (nodeDataType)
            {
                case DataTypes.Number:
                case DataTypes.Integer:
                case DataTypes.UInteger:
                case DataTypes.Int16:
                case DataTypes.UInt16:
                case DataTypes.Int32:
                case DataTypes.UInt32:
                case DataTypes.Int64:
                case DataTypes.UInt64:
                case DataTypes.Float:
                case DataTypes.Double:
                    var gaugeId = await this.CreateOrGetGauge(new Gauge
                    {
                        Interactive = isInteractive,
                        NodeId = node.NodeId.ValueAsString,
                        NodeName = node.DisplayName.Value,
                    });
                    return (gaugeId, "Gauge");
                case DataTypes.Boolean:
                    var togglerId = await this.CreateOrGetToggler(new Toggler
                    {
                        Interactive = isInteractive,
                        NodeId = node.NodeId.ToString(),
                        NodeName = node.DisplayName.Value,
                    });
                    return (togglerId, "Toggler");
                default:
                    throw new Exception($"Can't support {nodeDataType} datatype");
            }
        }

        private async Task<string> CreateOrGetGauge(Gauge gauge)
        {
            var filter = Builders<Gauge>.Filter.Eq("NodeId", gauge.NodeId);
            var result = await this._database.GetGaugesCollection().FindAsync(filter);
            var foundGaugeList = await result.ToListAsync();

            if (foundGaugeList.SingleOrDefault() != null)
            {
                return foundGaugeList.Single().Id;
            }

            await this._database.GetGaugesCollection().InsertOneAsync(gauge);
            return gauge.Id;
        }

        private async Task<string> CreateOrGetToggler(Toggler toggler)
        {
            var filter = Builders<Toggler>.Filter.Eq("NodeId", toggler.NodeId);
            var result = await this._database.GetTogglersCollection().FindAsync(filter);
            var foundTogglerList = await result.ToListAsync();

            if (foundTogglerList.SingleOrDefault() != null)
            {
                return foundTogglerList.Single().Id;
            }

            await this._database.GetTogglersCollection().InsertOneAsync(toggler);
            return toggler.Id;
        }
    }
}
