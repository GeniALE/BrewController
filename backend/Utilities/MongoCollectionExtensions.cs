using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models;
using MongoDB.Driver;

namespace BrewController.Utilities
{
    public static class MongoCollectionExtensions
    {
        public static Task<T> FindItemAsync<T>(this IMongoCollection<T> collection, string id)
            where T : MongoCollectionItem
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).FirstAsync();
        }

        public static Task<UpdateResult> UpdateItemAsync<T>(this IMongoCollection<T> collection, T item)
            where T : MongoCollectionItem
        {
            var filter = Builders<T>.Filter.Eq("Id", item.Id);
            var combinedUpdates = new List<UpdateDefinition<T>>();

            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(item, null);

                if (value != null)
                {
                    combinedUpdates.Add(Builders<T>.Update.Set(property.Name, value));
                }
            }

            return collection.UpdateOneAsync(filter, Builders<T>.Update.Combine(combinedUpdates));
        }

        public static async Task<OperationResult> DeleteItemAsync<T>(this IMongoCollection<T> collection, string id)
            where T : MongoCollectionItem
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.DeleteOneAsync(filter);

            return new OperationResult { Worked = result.IsAcknowledged, };
        }
    }
}
