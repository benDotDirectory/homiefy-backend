using System.ComponentModel.DataAnnotations;

namespace homiefy_backend.Domain.Models
{
    public class AuthorizationCredential
    {
        public string Id;

        public string ClientId;

        public string ClientSecret;
    }
}
