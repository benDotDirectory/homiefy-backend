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
        public async Task<bool> AddToQueue(string songUri)
        {
            return await _spotify.Player.AddToQueue(new PlayerAddToQueueRequest(songUri));
        }

        /*
         * Search a query and return the results
         */
        public async Task<SearchResponse> Search(string searchTerm)
        {
            // @TODO validate searchTerm
            // @TODO support searching songs, artists, etc
            SearchRequest req = new SearchRequest(query: searchTerm, type: SearchRequest.Types.Track);
            SearchResponse resp = await _spotify.Search.Item(req);
            return resp;
        }
        


    }
}
