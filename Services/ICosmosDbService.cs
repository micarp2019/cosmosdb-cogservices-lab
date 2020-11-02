using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterPhotos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterPhotos.Models;

    public interface ICosmosDbService
    {
        Task<IEnumerable<Photo>> GetItemsAsync(string query);
        Task<Photo> GetItemAsync(string id);
        Task AddItemAsync(Photo item);
        Task UpdateItemAsync(string id, Photo item);
        Task DeleteItemAsync(string id);
    }
}
