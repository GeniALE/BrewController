namespace BrewController.Models.SubcategoryModels
{
    public class AddSubcategory
    {
        public string Name { get; set; } = null!;

        public string Rank { get; set; } = null!;

        public string CategoryId { get; set; } = null!;
    }

    public partial class Subcategory
    {
        public Subcategory(AddSubcategory addSubcategory)
        {
            this.Name = addSubcategory.Name;
            this.Rank = addSubcategory.Rank;
            this.CategoryId = addSubcategory.CategoryId;
        }
    }
}
