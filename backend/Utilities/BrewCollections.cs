using BrewController.Models.CategoryModels;
using BrewController.Models.GaugeModels;
using BrewController.Models.GaugeValueModels;
using BrewController.Models.LogModels;
using BrewController.Models.TogglerModels;
using BrewController.Models.TogglerValueModels;
using MongoDB.Driver;

namespace BrewController.Utilities
{
    public static class BrewCollections
    {
        public static IMongoCollection<Category> GetCategoriesCollection(this IMongoDatabase database) =>
            database.GetCollection<Category>("categories");

        public static IMongoCollection<Gauge> GetGaugesCollection(this IMongoDatabase database) =>
            database.GetCollection<Gauge>("gauges");

        public static IMongoCollection<GaugeValue> GetGaugeValuesCollection(this IMongoDatabase database) =>
            database.GetCollection<GaugeValue>("gauge_values");

        public static IMongoCollection<Log> GetLogsCollection(this IMongoDatabase database) =>
            database.GetCollection<Log>("logs");

        public static IMongoCollection<Toggler> GetTogglersCollection(this IMongoDatabase database) =>
            database.GetCollection<Toggler>("togglers");

        public static IMongoCollection<TogglerValue> GetTogglerValuesCollection(this IMongoDatabase database) =>
            database.GetCollection<TogglerValue>("toggler_values");
    }
}
