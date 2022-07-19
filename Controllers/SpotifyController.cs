using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using homiefy_backend.Domain.Models;
using homiefy_backend.Services.Interfaces;
using homiefy_backend.Resources;

using Newtonsoft.Json;

namespace homiefy_backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;

        public SpotifyController(ISpotifyService spotifyService, IMapper mapper)
        {
            _spotifyService = spotifyService;
            _mapper = mapper;
        }

        /*
         * Checks if user is authorized
         */
        [HttpGet("is-user-authorized")]
        public async Task<IActionResult> IsUserAuthorized()
        {
            var result = await _spotifyService.IsUserAuthorized();

            if (!result.AuthenticationSuccess)
            {
                return StatusCode(500, $"{Values.UserIsNotAuthorized}\nException message: {result.ExceptionMessage}");
            }

            var authResult = _mapper.Map<AuthorizationResult, AuthorizationResultResource>(result);

            return Ok(JsonConvert.SerializeObject(authResult));
        }

        /*
         * Adds a song to the queue
         */
        [HttpPost("add-to-queue")]
        public async Task<IActionResult> AddToQueue(string uri)
        {
            var result = await _spotifyService.AddToQueue(uri);

            if (!result) return StatusCode(500, $"{Values.FailedToAddToQueue}\nURI: {uri}");
            else return Ok("Add song to queue.");
        }

        /*
         * Searches a track using spotify api and returns results.
         */
        [HttpGet("search-track")]
        public async Task<IActionResult> SearchTrack(string query)
        {
            var result = await _spotifyService.Search(query);
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}
