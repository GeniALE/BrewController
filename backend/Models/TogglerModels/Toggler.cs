using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models.SubcategoryModels;
using BrewController.Models.TogglerValueModels;
using BrewController.Utilities;
using HotChocolate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BrewController.Models.TogglerModels
{
    public partial class Toggler : MongoCollectionItem
    {
        public string PhysicalId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Interactive { get; set; }

        public string Rank { get; set; } = null!;

        // references

        [BsonRepresentation(BsonType.ObjectId)]
        public string SubcategoryId { get; set; } = null!;

        public async Task<Subcategory> GetSubcategory([Service] IMongoDatabase database) =>
            await database.GetSubcategoriesCollection().FindItemAsync(this.SubcategoryId);

        public async Task<IEnumerable<TogglerValue>> GetValues([Service] IMongoDatabase database)
        {
            var filter = Builders<TogglerValue>.Filter.Eq("TogglerId", this.Id);
            var togglerValues = await database
                .GetTogglerValuesCollection()
                .Find(filter)
                .SortByDescending(bson => bson.Id)
                .ToListAsync();

            return togglerValues ?? new List<TogglerValue>();
        }
    }
}
