using AutoMapper;

using homiefy_backend.Domain.Models;
using homiefy_backend.Resources;

namespace homiefy_backend.Mappers.ResourceToModel
{
    public class AuthenticationCredentialProfile : Profile
    {
        public AuthenticationCredentialProfile()
        {
            CreateMap<AuthenticationCredentialResource, AuthorizationCredential>();
        }
    }
}
