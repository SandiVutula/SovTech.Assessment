using Microsoft.OpenApi.Models;
using SovTech.Services;
using SovTech.Services.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Chuck Norris REST API",
        Description = "The API returns a list of all categories and resolves a random joke based on a category"
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//Here I'm just enabling CORS to allow the SPA Angular Client to consume the API Service
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
}));

//Registering the Joke service using Dependency Injection for instance creation 
builder.Services.AddSingleton<IJokeService, JokeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
