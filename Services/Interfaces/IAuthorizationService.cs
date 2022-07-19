using homiefy_backend.Domain.Models;

namespace homiefy_backend.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<AuthorizationUrlResponse> GetAuthorizationUrl(AuthorizationCredential credential);
    }
}
