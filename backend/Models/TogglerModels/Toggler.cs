using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models.CategoryModels;
using BrewController.Models.TogglerValueModels;
using BrewController.Utilities;
using HotChocolate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BrewController.Models.TogglerModels
{
    public partial class Toggler : RankedMongoCollectionItem
    {
        public Toggler() { }

        public string NodeId { get; set; } = null!;

        public string NodeName { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Interactive { get; set; }

        // references

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; } = null!;

        public async Task<Category?> GetCategory([Service] IMongoDatabase database)
        {
            if (this.CategoryId == null)
                return null;

            return await database.GetCategoriesCollection().FindItemAsync(this.CategoryId);
        }

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
