// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models;
using BrewController.Models.CategoryModels;
using BrewController.Utilities;
using MongoDB.Driver;

namespace BrewController.Schema
{
    public partial class Query
    {
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var filter = Builders<Category>.Filter.Empty;
            var result = this._database.GetCategoriesCollection().Find(filter).SortBy(category => category.Rank);

            var categories = await result.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategory(string categoryId) =>
            await this._database.GetCategoriesCollection().FindItemAsync(categoryId);
    }

    public partial class Mutation
    {
        public async Task<Category> AddCategory(AddCategory newCategory, string? previousCategoryId, string? nextCategoryId)
        {
            var category = new Category(newCategory);

            var previousCategory = previousCategoryId != null ? await this._database.GetCategoriesCollection().FindItemAsync(previousCategoryId) : null;
            var nextCategory = nextCategoryId != null ? await this._database.GetCategoriesCollection().FindItemAsync(nextCategoryId) : null;
            category.Rank = Rank.Generate(previousCategory?.Rank, nextCategory?.Rank);

            await this._database.GetCategoriesCollection().InsertOneAsync(category);
            await this._brewLogger.AddUpdateLog($"New category added: {category.Name}");

            return category;
        }

        public async Task<Category> UpdateCategory(UpdateCategory updatedCategory, string? previousCategoryId, string? nextCategoryId)
        {
            var category = new Category(updatedCategory);

            if (previousCategoryId != null || nextCategoryId != null)
            {
                var previousCategory = previousCategoryId != null ? await this._database.GetCategoriesCollection().FindItemAsync(previousCategoryId) : null;
                var nextCategory = nextCategoryId != null ? await this._database.GetCategoriesCollection().FindItemAsync(nextCategoryId) : null;
                category.Rank = Rank.Generate(previousCategory?.Rank, nextCategory?.Rank);
            }

            await this._database.GetCategoriesCollection().UpdateItemAsync(category);
            await this._brewLogger.AddUpdateLog($"Category updated: {category.Name}");

            return await this._database.GetCategoriesCollection().FindItemAsync(updatedCategory.Id);
        }

        public async Task<OperationResult> DeleteCategory(string categoryId) =>
            await this._database.GetCategoriesCollection().DeleteItemAsync(categoryId);
    }
}
