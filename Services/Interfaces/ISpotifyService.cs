using homiefy_backend.Domain.Models;

using SpotifyAPI.Web;

namespace homiefy_backend.Services.Interfaces
{
    public interface ISpotifyService
    {
        Task<AuthorizationResult> IsUserAuthorized();
        Task<bool> AddToQueue(string songUri);
        Task<SearchResponse> Search(string searchTerm);
    }
}
