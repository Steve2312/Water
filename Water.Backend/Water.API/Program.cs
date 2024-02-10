using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Water.API.Filters;
using Water.API.Repositories;
using Water.API.Repositories.Interfaces;
using Water.API.Services;
using Water.API.Services.Interfaces;
using Water.API.Swagger;
using Water.API.Utils;
using Water.API.Utils.Interfaces;
using Water.DAL;

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                       throw new ArgumentException("Environment variable: CONNECTION_STRING not found");
var domain = Environment.GetEnvironmentVariable("AUTH0_DOMAIN") ??
                       throw new ArgumentException("Environment variable: AUTH0_DOMAIN not found");
var audience = Environment.GetEnvironmentVariable("AUTH0_AUDIENCE") ??
             throw new ArgumentException("Environment variable: AUTH0_AUDIENCE not found");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IConsumptionService, ConsumptionService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISubjectUserMapRepository, SubjectUserMapRepository>();

builder.Services.AddScoped<IClaimsPrincipalUtil, ClaimsPrincipalUtil>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = audience;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});
builder.Services.AddDbContext<WaterDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<NameIdentifierNotFoundExceptionFilterAttribute>();
    options.Filters.Add<UserNotFoundExceptionFilterAttribute>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddBearerDefinition();
    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

var app = builder.Build();

// TODO: Use Migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<WaterDbContext>();

    context?.Database.EnsureDeleted();
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();