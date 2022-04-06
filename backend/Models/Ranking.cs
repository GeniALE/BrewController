using System.Threading.Tasks;
using BrewController.Utilities;
using MongoDB.Driver;

namespace BrewController.Models;

public class Ranking
{
    public string? PreviousId { get; set; }

    public string? NextId { get; set; }

    public async Task UpdateModelRank<T>(T item, IMongoCollection<T> collection) where T : RankedMongoCollectionItem
    {
        var previousItem = this.PreviousId != null ? await collection.FindItemAsync(this.PreviousId) : null;
        var nextItem = this.NextId != null ? await collection.FindItemAsync(this.NextId) : null;

        item.Rank = Rank.Generate(previousItem?.Rank, nextItem?.Rank);
    }
}
