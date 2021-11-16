using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models.CategoryModels;
using BrewController.Models.GaugeValueModels;
using BrewController.Utilities;
using HotChocolate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BrewController.Models.GaugeModels
{
    public partial class Gauge : RankedMongoCollectionItem
    {
        public Gauge() { }

        public string NodeId { get; set; } = null!;

        public string NodeName { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public GaugeType Type { get; set; } = GaugeType.NotSet;

        public bool Interactive { get; set; }

        // references

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        public async Task<Category?> GetCategory([Service] IMongoDatabase database)
        {
            if (this.CategoryId == null)
            {
                return null;
            }

            return await database.GetCategoriesCollection().FindItemAsync(this.CategoryId);
        }

        public async Task<IEnumerable<GaugeValue>> GetValues([Service] IMongoDatabase database)
        {
            var filter = Builders<GaugeValue>.Filter.Eq("GaugeId", this.Id);
            var gaugeValues = await database
                .GetGaugeValuesCollection()
                .Find(filter)
                .SortByDescending(bson => bson.Id)
                .ToListAsync();

            return gaugeValues ?? new List<GaugeValue>();
        }
    }

    public enum GaugeType
    {
        NotSet,
        Temperature,
        Pressure,
    }
}
