using Microsoft.EntityFrameworkCore;

using AutoMapper;

using SpotifyAPI;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Http;
using static SpotifyAPI.Web.Scopes;

using homiefy_backend.Services;
using homiefy_backend.Services.Interfaces;
using homiefy_backend.Persistence.Contexts;
using homiefy_backend.Persistence.Repositories;
using homiefy_backend.Persistence.Repositories.Interfaces;
using homiefy_backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("homiefy-in-memory-db");
});

builder.Services.AddScoped<IAuthenticationCredentialRepository, AuthenticationCredentialRepository>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
