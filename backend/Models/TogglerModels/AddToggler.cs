namespace BrewController.Models.TogglerModels;

public class AddToggler
{
    public string NodeId { get; set; } = null!;

    public string NodeName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Interactive { get; set; }

    public string CategoryId { get; set; } = null!;
}

public partial class Toggler
{
    public Toggler(AddToggler addToggler)
    {
        this.NodeId = addToggler.NodeId;
        this.NodeName = addToggler.NodeName;
        this.Name = addToggler.Name;
        this.Description = addToggler.Description;
        this.Interactive = addToggler.Interactive;
        this.CategoryId = addToggler.CategoryId;
    }
}
