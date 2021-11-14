using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Subscriptions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace BrewController.OpcUA
{
    public class BrewListener : BackgroundService
    {
        private readonly BrewClient _brewClient;

        public BrewListener(BrewClient brewClient)
        {
            this._brewClient = brewClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var client = this._brewClient;
            foreach (var node in client.BrowseNodes())
            {
                if (node != null)
                {
                    Console.WriteLine($"\\----------- {node.Name.Value} => {node.NodeId} ------------\\");
                }
            }
            // var rootNode =
            //     client.BrowseNode(
            //         $"{Environment.GetEnvironmentVariable("BREW_OPCUA_SERVER_NAMESPACE") ?? "http://test.brewcontroller.server"};i=84");

            // foreach (var node in rootNode.Children())
            // {
            //     if (node != null)
            //     {
            //         Console.WriteLine($"\\----------- {node.Name.Value} => {node.NodeId} ------------\\");
            //     }
            // }
            //
            // var rootNode = client.BrowseNode("ns=3;i=1009");
            //
            // var nodes = rootNode.Children();
            //
            // foreach (var node in nodes)
            // {
            //     Console.WriteLine($"\\----------- {node.Name.Value} => {node.NodeId} ------------\\");
            //
            //     var accessLevel = node.Attribute(OpcAttribute.AccessLevel);
            //     Console.WriteLine(accessLevel.Value);
            //
            //     Console.WriteLine($"/----------- {node.Name.Value} => {node.NodeId} ------------/");
            // }

            // var subscription = client.SubscribeDataChange("ns=3;i=1001", this.HandleChange);

            // while (!stoppingToken.IsCancellationRequested) { }
        }

        private void HandleChange(object sender, OpcDataChangeReceivedEventArgs e)
        {
            Console.WriteLine(e.Item.Value);
        }
    }
}
