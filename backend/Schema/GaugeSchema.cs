// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models;
using BrewController.Models.GaugeModels;
using BrewController.Utilities;
using MongoDB.Driver;

namespace BrewController.Schema;

public partial class Query
{
    public async Task<IEnumerable<Gauge>> GetGauges(string? categoryId)
    {
        var filter = categoryId != null
            ? Builders<Gauge>.Filter.Eq("CategoryId", categoryId)
            : Builders<Gauge>.Filter.Empty;

        var result = await this._database.GetGaugesCollection().FindAsync(filter);

        return await result.ToListAsync();
    }

    public async Task<Gauge> GetGauge(string gaugeId) =>
        await this._database.GetGaugesCollection().FindItemAsync(gaugeId);
}

public partial class Mutation
{
    public async Task<Gauge> AddGauge(AddGauge newGauge, Ranking ranking)
    {
        var gauge = new Gauge(newGauge);
        await ranking.UpdateModelRank(gauge, this._database.GetGaugesCollection());

        await this._database.GetGaugesCollection().InsertOneAsync(gauge);
        await this._brewLogger.AddUpdateLog($"New gauge added: {gauge.Name}");

        return gauge;
    }

    public async Task<Gauge> UpdateGauge(UpdateGauge updatedGauge, Ranking? ranking)
    {
        var gauge = new Gauge(updatedGauge);
        if (ranking != null)
            await ranking.UpdateModelRank(gauge, this._database.GetGaugesCollection());

        await this._database.GetGaugesCollection().UpdateItemAsync(gauge);
        await this._brewLogger.AddUpdateLog($"Gauge updated: {gauge.Name}");

        return gauge;
    }

    public async Task<OperationResult> DeleteGauge(string gaugeId) =>
        await this._database.GetGaugesCollection().DeleteItemAsync(gaugeId);
}