using AutoMapper;
using homiefy_backend.Domain.Models;
using homiefy_backend.Resources;

namespace homiefy_backend.Mappers.ModelToResource
{
    public class AuthenticationCredentialProfile : Profile
    {
        public AuthenticationCredentialProfile()
        {
            CreateMap<AuthorizationCredential, AuthenticationCredentialResource>();
        }
    }
}
