namespace BrewController.Models.GaugeModels
{
    public class UpdateGauge
    {
        public string Id { get; set; } = null!;

        public string PhysicalId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GaugeType Type { get; set; }

        public string Rank { get; set; } = null!;

        public bool Interactive { get; set; }

        public string CategoryId { get; set; } = null!;
    }

    public partial class Gauge
    {
        public Gauge(UpdateGauge updateGauge)
        {
            this.Id = updateGauge.Id;
            this.PhysicalId = updateGauge.PhysicalId;
            this.Name = updateGauge.Name;
            this.Description = updateGauge.Description;
            this.Type = updateGauge.Type;
            this.Rank = updateGauge.Rank;
            this.Interactive = updateGauge.Interactive;
            this.CategoryId = updateGauge.CategoryId;
        }
    }
}
