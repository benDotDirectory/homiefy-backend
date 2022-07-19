using SpotifyAPI.Web;

namespace homiefy_backend
{
    public class Constants
    {
        // Version info
        public static string API_VERSION = "v1";

        // Auth server
        public static int AuthServerPort = 5000;
        public static string AuthServerCallbackURI = $"http://localhost:{AuthServerPort}/callback";

        // Authorization scopes for Spotify API
        public static List<string> HostUserScopes = new List<string> { Scopes.UserModifyPlaybackState };
    }
}
 