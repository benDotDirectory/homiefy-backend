using AutoMapper;

using homiefy_backend.Domain.Models;
using homiefy_backend.Resources;

namespace homiefy_backend.Mappers.ModelToResource
{
    public class AuthorizationResultMapper : Profile
    {
        public AuthorizationResultMapper()
        {
            CreateMap<AuthorizationResult, AuthorizationResultResource>();
        }
    }
}
