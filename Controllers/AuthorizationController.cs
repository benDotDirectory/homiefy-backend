using System.Resources;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using homiefy_backend.Domain.Models;
using homiefy_backend.Services.Interfaces;
using homiefy_backend.Extensions;
using homiefy_backend.Resources;

namespace homiefy_backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthorizationController(IAuthorizationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /*
         * Calls AuthorizationService to build up a URL to return to the frontend.
         * The user can use this URL to authorization usage of the Spotify API/this app with their account
         */
        [HttpPost("build-auth-url", Name = "PostAuthUrl")]
        public async Task<IActionResult> AuthorizationUrl([FromBody] AuthenticationCredentialResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var credentials = _mapper.Map<AuthenticationCredentialResource, AuthorizationCredential>(userCredentials);

            try
            {
                var result = await _authenticationService.GetAuthorizationUrl(credentials);
                return Ok(result.AuthorizationUrl);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{Values.FailedToGetAuthorizationUrl}\n{e.Message}");
            }

        }
    }
}
