// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using BrewController.Models;
using BrewController.Models.TogglerModels;
using BrewController.Utilities;
using MongoDB.Driver;

namespace BrewController.Schema
{
    public partial class Query
    {
        public async Task<IEnumerable<Toggler>> GetTogglers(string? categoryId)
        {
            var filter = categoryId != null
                ? Builders<Toggler>.Filter.Eq("CategoryId", categoryId)
                : Builders<Toggler>.Filter.Empty;

            var result = await this._database.GetTogglersCollection().FindAsync(filter);

            return await result.ToListAsync();
        }

        public async Task<Toggler> GetToggler(string togglerId) =>
            await this._database.GetTogglersCollection().FindItemAsync(togglerId);
    }

    public partial class Mutation
    {
        public async Task<Toggler> AddToggler(AddToggler newToggler, Ranking ranking)
        {
            var toggler = new Toggler(newToggler);
            await ranking.UpdateModelRank(toggler, this._database.GetTogglersCollection());

            await this._database.GetTogglersCollection().InsertOneAsync(toggler);
            await this._brewLogger.AddUpdateLog($"New toggler added: {toggler.Name}");

            return toggler;
        }

        public async Task<Toggler> UpdateToggler(UpdateToggler updatedToggler, Ranking? ranking)
        {
            var toggler = new Toggler(updatedToggler);
            if (ranking != null)
            {
                await ranking.UpdateModelRank(toggler, this._database.GetTogglersCollection());
            }

            await this._database.GetTogglersCollection().UpdateItemAsync(toggler);
            await this._brewLogger.AddUpdateLog($"Toggler updated: {toggler.Name}");

            return toggler;
        }

        public async Task<OperationResult> DeleteToggler(string togglerId) =>
            await this._database.GetTogglersCollection().DeleteItemAsync(togglerId);
    }
}
