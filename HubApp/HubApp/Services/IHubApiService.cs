using HubApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HubApp.Services
{
    public interface IHubApiService
    {
        Task<List<Tag>> GetTagsAsync();
        Task<List<Content>> GetContentsByTagIdAsync(string tagId);
        Task<List<Content>> GetContentsByFilterAsync(string filter);
    }
}
