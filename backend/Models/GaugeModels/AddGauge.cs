namespace BrewController.Models.GaugeModels;

public class AddGauge
{
    public string NodeId { get; set; } = null!;

    public string NodeName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public GaugeType Type { get; set; }

    public bool Interactive { get; set; }

    public string CategoryId { get; set; } = null!;
}

public partial class Gauge
{
    public Gauge(AddGauge addGauge)
    {
        this.NodeId = addGauge.NodeId;
        this.NodeName = addGauge.NodeName;
        this.Name = addGauge.Name;
        this.Description = addGauge.Description;
        this.Type = addGauge.Type;
        this.Interactive = addGauge.Interactive;
        this.CategoryId = addGauge.CategoryId;
    }
}
