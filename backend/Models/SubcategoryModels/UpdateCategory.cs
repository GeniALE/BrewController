namespace BrewController.Models.SubcategoryModels
{
    public class UpdateSubcategory
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Rank { get; set; } = null!;

        public string CategoryId { get; set; } = null!;
    }

    public partial class Subcategory
    {
        public Subcategory(UpdateSubcategory updateSubcategory)
        {
            this.Id = updateSubcategory.Id;
            this.Name = updateSubcategory.Name;
            this.Rank = updateSubcategory.Rank;
            this.CategoryId = updateSubcategory.CategoryId;
        }
    }
}
