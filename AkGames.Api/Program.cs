using AkGames.Api.Data;
using AkGames.Api.Repos.CategoriseRpos;
using AkGames.Api.Repos.DevicesRepos;
using AkGames.Api.Repos.GamesRepos;
using Microsoft.EntityFrameworkCore;
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

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
