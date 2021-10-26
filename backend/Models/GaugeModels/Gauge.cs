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
    public partial class Gauge : MongoCollectionItem
    {
        public string PhysicalId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GaugeType Type { get; set; }

        public string Rank { get; set; } = null!;

        public bool Interactive { get; set; }

        // references

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;

        public async Task<Category> GetCategory([Service] IMongoDatabase database) =>
            await database.GetCategoriesCollection().FindItemAsync(this.CategoryId);

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
        Temperature,
        Pressure,
    }
}
