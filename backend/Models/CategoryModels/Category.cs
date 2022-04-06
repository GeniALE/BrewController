// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models.GaugeModels;
using BrewController.Models.TogglerModels;
using BrewController.Utilities;
using HotChocolate;
using MongoDB.Driver;

namespace BrewController.Models.CategoryModels;
public partial class Category : RankedMongoCollectionItem
{
    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;

    public async Task<IEnumerable<Toggler>> GetTogglers([Service] IMongoDatabase database)
    {
        var filter = Builders<Toggler>.Filter.Eq("CategoryId", this.Id);
        var togglers = await database
            .GetTogglersCollection()
            .Find(filter)
            .SortByDescending(bson => bson.Rank)
            .ToListAsync();

        return togglers ?? new List<Toggler>();
    }

    public async Task<IEnumerable<Gauge>> GetGauges([Service] IMongoDatabase database)
    {
        var filter = Builders<Gauge>.Filter.Eq("CategoryId", this.Id);
        var gauges = await database
            .GetGaugesCollection()
            .Find(filter)
            .SortByDescending(bson => bson.Rank)
            .ToListAsync();

        return gauges ?? new List<Gauge>();
    }
}
