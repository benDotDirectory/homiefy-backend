using Microsoft.AspNetCore.Mvc;

namespace homiefy_backend.Models
{
    public class AuthenticationResult : Controller
    {
        public bool AuthenticationSuccess;

        public string SpotifyDisplayName;

        public string SpotifyId;
    }
}
