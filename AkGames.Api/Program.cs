using AkGames.Api.Core.Models;
using AkGames.Api.Data;
using AkGames.Api.Helpers;
using AkGames.Api.Repos.AuthRepos;
using AkGames.Api.Repos.CategoriseRpos;
using AkGames.Api.Repos.DevicesRepos;
using AkGames.Api.Repos.GamesRepos;
using AkGames.Api.Seeds;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IGamesRepo, GameRepo>();
builder.Services.AddScoped<ICategoriseRepo, CategoriseRepo>();
builder.Services.AddScoped<IDevicesRepo, DevicesRepo>();
builder.Services.AddScoped<IAuthRepo, AuthRepo>();


//Add Identity Service

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//--------

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = builder.Configuration["JWT:Issuer"],
                       ValidAudience = builder.Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
                       ClockSkew = TimeSpan.Zero
                   };
               });

//Map JWT Class With JWT Key

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

//Add Cors Service

var policyName = "_myAllowSpecificOrigins";

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(name: policyName,
                          builder =>
                          {
                              builder
                                .WithOrigins("http://akgames.vercel.app/")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                          });
    }
    );

//Add AutoMapper Service
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using var scope = scopeFactory.CreateScope();

var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

await DefaultUsers.SeedAdminUserAsync(userManger);


app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
