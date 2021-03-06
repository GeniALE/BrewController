// ReSharper disable UnusedMember.Global

using System.Threading.Tasks;
using BrewController.Models.TogglerValueModels;
using BrewController.Utilities;
using HotChocolate.Execution;
using HotChocolate.Types;

namespace BrewController.Schema;

public partial class Mutation
{
    public async Task<TogglerValue> AddTogglerValue(string togglerId, TogglerStatus status)
    {
        var togglerValue = new TogglerValue
        {
            TogglerId = togglerId,
            Status = status,
        };

        var topic = $"{togglerId}_{nameof(Subscription.GetLatestTogglerValue)}";

        await this._database.GetTogglerValuesCollection().InsertOneAsync(togglerValue);
        await this._sender.SendAsync(topic, togglerValue);
        var toggler = await this._database.GetTogglersCollection().FindItemAsync(togglerValue.TogglerId);
        await this._brewLogger.AddUpdateLog($"Updated toggler {toggler.Name} status: {togglerValue.Status}");

        return togglerValue;
    }
}

public partial class Subscription
{
    [SubscribeAndResolve]
    public ValueTask<ISourceStream<TogglerValue>> GetLatestTogglerValue(string togglerId)
    {
        var topic = $"{togglerId}_{nameof(this.GetLatestTogglerValue)}";
        return this._receiver.SubscribeAsync<string, TogglerValue>(topic);
    }
}