// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models;
using BrewController.Models.GaugeModels;
using BrewController.Utilities;
using MongoDB.Driver;

namespace BrewController.Schema
{
    public partial class Query
    {
        public async Task<IEnumerable<Gauge>> GetGauges(string? subcategoryId)
        {
            var filter = subcategoryId != null
                ? Builders<Gauge>.Filter.Eq("SubcategoryId", subcategoryId)
                : Builders<Gauge>.Filter.Empty;

            var result = await this._database.GetGaugesCollection().FindAsync(filter);

            return await result.ToListAsync();
        }

        public async Task<Gauge> GetGauge(string gaugeId) =>
            await this._database.GetGaugesCollection().FindItemAsync(gaugeId);
    }

    public partial class Mutation
    {
        public async Task<Gauge> AddGauge(AddGauge newGauge)
        {
            var gauge = new Gauge(newGauge);
            await this._database.GetGaugesCollection().InsertOneAsync(gauge);
            await this._brewLogger.AddUpdateLog($"New gauge added: {gauge.Name}");

            return gauge;
        }

        public async Task<Gauge> UpdateGauge(UpdateGauge updatedGauge)
        {
            var gauge = new Gauge(updatedGauge);
            await this._database.GetGaugesCollection().UpdateItemAsync(gauge);
            await this._brewLogger.AddUpdateLog($"Gauge updated: {gauge.Name}");

            return gauge;
        }

        public async Task<OperationResult> DeleteGauge(string gaugeId) =>
            await this._database.GetGaugesCollection().DeleteItemAsync(gaugeId);
    }
}
