// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using BrewController.Models.GaugeModels;
using BrewController.Models.TogglerModels;
using MongoDB.Bson.Serialization.Attributes;

namespace BrewController.Models.CategoryModels
{
    public partial class Category : MongoCollectionItem
    {
        public string Name { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string Rank { get; set; } = null!;

        // todo: implement getter
        [BsonIgnore]
        public IEnumerable<Toggler> Togglers { get; set; } = Array.Empty<Toggler>();

        // todo: implement getter
        [BsonIgnore]
        public IEnumerable<Gauge> Gauges { get; set; } = Array.Empty<Gauge>();
    }
}
