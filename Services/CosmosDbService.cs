namespace TwitterPhotos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TwitterPhotos.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;
    using Microsoft.Extensions.Configuration;
    using System;

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Photo item)
        {
            await this._container.CreateItemAsync<Photo>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Photo>(id, new PartitionKey(id));
        }

        public async Task<Photo> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Photo> response = await this._container.ReadItemAsync<Photo>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Photo>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Photo>(new QueryDefinition(queryString));
            List<Photo> results = new List<Photo>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }
            Photo p = results[0];
            
            Console.WriteLine("tag:" + p.Tag);
            return results;
        }

        public async Task UpdateItemAsync(string id, Photo item)
        {
            await this._container.UpsertItemAsync<Photo>(item, new PartitionKey(id));
        }

    }
}
