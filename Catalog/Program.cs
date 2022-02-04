using Catalog.Repositories;
using Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Configuration;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

builder.Services.AddScoped<IItemsRepository, InMemItemsRepository>();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddSingleton<IMongoClient, MongoClient>();

// Adding MongoDb configuration
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    //var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(mongoDbSettings.ConnectionString);
});
builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();
builder.Services.AddSingleton<IUsersRepository, MongoDbUsersRepository>();
builder.Services.AddSingleton<ICompanyRepository, MongoDbCompanyRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddMongoDb(
        mongoDbSettings.ConnectionString,
            name: "mongoDb",
            timeout: TimeSpan.FromSeconds(3),
            tags: new[] { "ready" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = (check) => check.Tags.Contains("ready"),
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(
            new
            {
                status = report.Status.ToString(),
                checks = report.Entries.Select(entry => new
                {
                    name = entry.Key,
                    status = entry.Value.Status.ToString(),
                    exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                    duration = entry.Value.Duration.ToString()
                })
            }
         );
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = (_) => false
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();