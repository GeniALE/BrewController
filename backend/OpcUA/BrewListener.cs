using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrewController.Utilities;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Subscriptions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace BrewController.OpcUA
{
    public class BrewListener : BackgroundService
    {
        private readonly BrewClient _brewClient;
        private Dictionary<string, (string ObjectId, string ControllerType)> _brewControllers;

        public BrewListener(BrewClient brewClient)
        {
            this._brewClient = brewClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var client = this._brewClient;
            // var rootNode =
            //     client.BrowseNode(
            //         $"{Environment.GetEnvironmentVariable("BREW_OPCUA_SERVER_NAMESPACE") ?? "http://test.brewcontroller.server"};i=84");
            var rootNode = client.BrowseNode("ns=2;i=1");

            var controllerNodes = rootNode.Children().Where(cn =>
            {
                var accessLevel = cn.Attribute(OpcAttribute.AccessLevel).Value.AsValue<byte>();
                return accessLevel.Value.GetBit(0);
            }).ToArray();

            var controllerInfos = await Task.WhenAll(controllerNodes.Select(this.GetControllerInfos));
            var a = controllerNodes.Zip(controllerInfos);
            foreach (var (node, controllerInfo) in controllerNodes.Zip(controllerInfos))
            {
                this._brewControllers.Add(node.NodeId.ToString(), controllerInfo);
                client.SubscribeDataChange(node.NodeId, this.HandleChange);
            }

            while (!stoppingToken.IsCancellationRequested) { }
        }

        private void HandleChange(object sender, OpcDataChangeReceivedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Item.Value);
        }

        private Task<(string ObjectId, string ControllerId)> GetControllerInfos(OpcNodeInfo controllerNode)
        {
            using var client = this._brewClient;

            var accessLevel = controllerNode.Attribute(OpcAttribute.AccessLevel).Value.AsValue<byte>();
            return client.CreateController(controllerNode, accessLevel.Value.GetBit(1));
        }
    }
}
