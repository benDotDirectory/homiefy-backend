using homiefy_backend.Domain.Models;

namespace homiefy_backend.Services.Interfaces
{
    public interface ISpotifyService
    {
        Task<AuthorizationResult> IsUserAuthorized();
    }
}
