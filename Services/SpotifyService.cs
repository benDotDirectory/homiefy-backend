using homiefy_backend.Clients;
using homiefy_backend.Domain.Models;
using homiefy_backend.Services.Interfaces;

using SpotifyAPI.Web;

namespace homiefy_backend.Services
{
    /*
     * This service interacts with the Spotify API.
     * I plan to write some higher level services like a QueueService or something, that lets users manipulate a queue before it gets sent to Spotify.
     */
    public class SpotifyService : ISpotifyService
    {
        private SpotifyClient _spotify;


        public SpotifyService()
        {
            _spotify = GlobalSpotifyClient.Spotify;
        }

        /*
         * Tests to make sure user is authorized
         */
        public async Task<AuthorizationResult> IsUserAuthorized()
        { 
            try
            {
                var user = await _spotify.UserProfile.Current();
                return new AuthorizationResult()
                {
                    AuthenticationSuccess = true,
                    SpotifyDisplayName = user.DisplayName,
                    SpotifyId = user.Id
                };
            }
            catch (Exception e)
            {
                return new AuthorizationResult()
                {
                    AuthenticationSuccess = false,
                    ExceptionMessage = e.Message
                };
            }
        }

        /*
         * Add a song to the queue
         */

        /*
         * Remove a song from the queue
         */



    }
}
