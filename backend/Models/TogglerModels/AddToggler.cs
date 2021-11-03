namespace BrewController.Models.TogglerModels
{
    public class AddToggler
    {
        public string PhysicalId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Interactive { get; set; }

        public string CategoryId { get; set; } = null!;
    }

    public partial class Toggler
    {
        public Toggler(AddToggler addToggler)
        {
            this.PhysicalId = addToggler.PhysicalId;
            this.Name = addToggler.Name;
            this.Description = addToggler.Description;
            this.Interactive = addToggler.Interactive;
            this.CategoryId = addToggler.CategoryId;
        }
    }
}
