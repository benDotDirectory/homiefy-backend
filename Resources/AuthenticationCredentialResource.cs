using System.ComponentModel.DataAnnotations;

namespace homiefy_backend.Resources
{
    public class AuthenticationCredentialResource
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }
    }
}
