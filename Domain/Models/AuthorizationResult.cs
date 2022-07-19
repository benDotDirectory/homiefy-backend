namespace homiefy_backend.Domain.Models
{
    public class AuthorizationResult
    {
        public bool AuthenticationSuccess;

        public string? ExceptionMessage;

        public string SpotifyDisplayName;

        public string SpotifyId;

        public AuthorizationCredential AuthCred;
    }
}
