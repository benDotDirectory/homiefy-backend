using homiefy_backend.Clients;
using homiefy_backend.Services.Interfaces;
using homiefy_backend.Domain.Models;
using homiefy_backend.Persistence.Repositories.Interfaces;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace homiefy_backend.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthenticationCredentialRepository _authenticationCredentialRepository;

        private EmbedIOAuthServer _authServer;
        private SpotifyClient _spotifyHostUser;

        private string _hostClientId;
        private string _hostClientSecret;

        public AuthorizationService(IAuthenticationCredentialRepository authenticationCredentialRepository)
        {
            this._authenticationCredentialRepository = authenticationCredentialRepository;
        }

        /*
         * Gets authorization URL to return to client for authorizing a spotify account for use with this application
         */
        public async Task<AuthorizationUrlResponse> GetAuthorizationUrl(AuthorizationCredential credential)
        {
            // @TODO handle client secret better (hash this)
            _hostClientId = credential.ClientId;
            _hostClientSecret = credential.ClientSecret;

            _authServer = new EmbedIOAuthServer(new Uri(Constants.AuthServerCallbackURI), Constants.AuthServerPort);
            await _authServer.Start();

            _authServer.AuthorizationCodeReceived += OnAuthorizationCodeRecieved;
            _authServer.ErrorReceived += OnErrorRecieved;

            var request = new LoginRequest(_authServer.BaseUri, _hostClientId, LoginRequest.ResponseType.Code)
            {
                Scope = Constants.HostUserScopes
            };

            return new AuthorizationUrlResponse { AuthorizationUrl = request.ToUri().ToString() };
        }

        /*
         * 

        // ========================================================================================================================================================================================================

        /*
         * Auth server delegate methods
         */
        private async Task OnAuthorizationCodeRecieved(object sender, AuthorizationCodeResponse response)
        {
            await _authServer.Stop();

            AuthorizationCodeTokenResponse token = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(_hostClientId, _hostClientSecret, response.Code, _authServer.BaseUri)
            );

            var config = SpotifyClientConfig.CreateDefault().WithToken(token.AccessToken, token.TokenType);
            //var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(new AuthorizationCodeAuthenticator(_hostClientId, _hostClientSecret, token));
            //_spotifyHostUser = new SpotifyClient(config);
            GlobalSpotifyClient.Spotify = new SpotifyClient(config); // @todo do this better
        }

        private async Task OnErrorRecieved(object sender, string error, string state)
        {
            Console.WriteLine($"Aborting authorization, error occured:\n{error}\nstate: {state}");
            await _authServer.Stop();
        }

    }
}
