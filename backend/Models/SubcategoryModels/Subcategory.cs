using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models.CategoryModels;
using BrewController.Models.GaugeModels;
using BrewController.Models.TogglerModels;
using BrewController.Utilities;
using HotChocolate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BrewController.Models.SubcategoryModels
{
    public partial class Subcategory : MongoCollectionItem
    {
        public string Name { get; set; } = null!;

        public string Rank { get; set; } = null!;

        // references

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;

        public async Task<Category> GetCategory([Service] IMongoDatabase database) =>
            await database.GetCategoriesCollection().FindItemAsync(this.CategoryId);

        [BsonIgnore]
        public IEnumerable<Toggler> Togglers { get; set; } = Array.Empty<Toggler>();

        [BsonIgnore]
        public IEnumerable<Gauge> Gauges { get; set; } = Array.Empty<Gauge>();
    }
}
