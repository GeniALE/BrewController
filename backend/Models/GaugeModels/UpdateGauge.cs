namespace BrewController.Models.GaugeModels
{
    public class UpdateGauge
    {
        public string Id { get; set; } = null!;

        public string NodeId { get; set; } = null!;

        public string NodeName { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public GaugeType Type { get; set; }

        public string? CategoryId { get; set; }
    }

    public partial class Gauge
    {
        public Gauge(UpdateGauge updateGauge)
        {
            this.NodeId = updateGauge.NodeId;
            this.NodeName = updateGauge.NodeName;
            this.Id = updateGauge.Id;
            this.Name = updateGauge.Name;
            this.Description = updateGauge.Description;
            this.Type = updateGauge.Type;
            this.CategoryId = updateGauge.CategoryId;
        }
    }
}
