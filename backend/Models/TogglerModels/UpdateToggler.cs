namespace BrewController.Models.TogglerModels
{
    public class UpdateToggler
    {
        public string Id { get; set; } = null!;

        public string NodeId { get; set; } = null!;

        public string NodeName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Interactive { get; set; }

        public string CategoryId { get; set; } = null!;
    }

    public partial class Toggler
    {
        public Toggler(UpdateToggler updateToggler)
        {
            this.Id = updateToggler.Id;
            this.NodeId = updateToggler.NodeId;
            this.NodeName = updateToggler.NodeName;
            this.Name = updateToggler.Name;
            this.Description = updateToggler.Description;
            this.Interactive = updateToggler.Interactive;
            this.CategoryId = updateToggler.CategoryId;
        }
    }
}
