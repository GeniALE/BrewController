namespace BrewController.Models.CategoryModels;

public class UpdateCategory
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Color { get; set; } = null!;
}

public partial class Category
{
    public Category(UpdateCategory updateCategory)
    {
        this.Id = updateCategory.Id;
        this.Name = updateCategory.Name!;
        this.Color = updateCategory.Color!;
    }
}
