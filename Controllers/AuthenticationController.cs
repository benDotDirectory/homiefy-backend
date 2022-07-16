using Microsoft.AspNetCore.Mvc;

using homiefy_backend.Models;

namespace homiefy_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        /*
         * Authenticates the host user for a session
         * This user will be authenticated with scopes necessary for queueing music, etc
         */

        [Route("/

        [HttpGet(Name = "GetTest")]
        public string Get()
        {
            return "Test";
        }

        [HttpPost(Name = "PostAuthenticateHostUser")]
        public AuthenticationResult Post([FromBody] string clientId, string clientSecret)
        {
            return new AuthenticationResult()
            {
                AuthenticationSuccess = true,
                SpotifyDisplayName = "TEST",
                SpotifyId = "TEST"
            };
        }

    }
}
