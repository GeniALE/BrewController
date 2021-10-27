namespace BrewController.Models
{
    public abstract class RankedMongoCollectionItem : MongoCollectionItem
    {
        public string Rank { get; set; } = null!;
    }
}
