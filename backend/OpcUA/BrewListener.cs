using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrewController.Utilities;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Subscriptions;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace BrewController.OpcUA;

public class BrewListener : BackgroundService
{
    private readonly BrewClient _brewClient;
    private Dictionary<string, (string ObjectId, string ControllerType)> _brewControllers = new();

    public BrewListener(BrewClient brewClient)
    {
        this._brewClient = brewClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // var rootNode =
        //     client.BrowseNode(
        //         $"{Environment.GetEnvironmentVariable("BREW_OPCUA_SERVER_NAMESPACE") ?? "http://test.brewcontroller.server"};i=84");
        var rootNode = this._brewClient.BrowseNode("ns=2;i=1");

        var controllerNodes = rootNode.Children().Where(cn =>
        {
            var accessLevel = cn.Attribute(OpcAttribute.AccessLevel).Value.AsValue<byte>();
            return accessLevel.Value.GetBit(0);
        }).ToArray();

        var controllerInfos = await Task.WhenAll(controllerNodes.Select(this.GetControllerInfos));
        foreach (var (node, controllerInfo) in controllerNodes.Zip(controllerInfos))
        {
            this._brewControllers.Add(node.NodeId.ToString(), controllerInfo);
            this._brewClient.SubscribeDataChange(node.NodeId, this.HandleChange);
        }

        while (!stoppingToken.IsCancellationRequested) { }
    }

    private void HandleChange(object sender, OpcDataChangeReceivedEventArgs eventArgs)
    {
        var nodeId = eventArgs.MonitoredItem.NodeId;
        var nodeIdValue = $"ns={nodeId.NamespaceIndex};i={nodeId.ValueAsString}";

        var controllerInfo = this._brewControllers[nodeIdValue];

        Task.Run(async () => await this._brewClient.CreateControllerValue(controllerInfo, eventArgs.Item.Value));
    }

    private Task<(string ObjectId, string ControllerType)> GetControllerInfos(OpcNodeInfo controllerNode)
    {
        var accessLevel = controllerNode.Attribute(OpcAttribute.AccessLevel).Value.AsValue<byte>();
        return this._brewClient.CreateController(controllerNode, accessLevel.Value.GetBit(1));
    }
}
