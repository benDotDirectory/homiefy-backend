using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using homiefy_backend.Domain.Models;
using homiefy_backend.Persistence.Repositories;
using homiefy_backend.Persistence.Contexts;
using homiefy_backend.Persistence.Repositories.Interfaces;


namespace homiefy_backend.Persistence.Repositories
{
    public class AuthenticationCredentialRepository : BaseRepository, IAuthenticationCredentialRepository
    {
        public AuthenticationCredentialRepository(AppDbContext context) : base(context)
        {
            // ...
        }
    }
}
