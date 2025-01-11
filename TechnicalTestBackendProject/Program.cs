using Microsoft.EntityFrameworkCore;
using MediatR;
using StackExchange.Redis;
using TechnicalTestBackendProject.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MediatR configuration
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// <---- Databases configuration ---->
// Postgres connection
var postgresConnectionString = builder.Configuration.GetConnectionString("PostgresConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(postgresConnectionString));
// Redis connection
var redisConnectionString = builder.Configuration.GetConnectionString("RedisConnection") ?? throw new InvalidOperationException("Connection string 'RedisConnection' not found.");
var redis = ConnectionMultiplexer.Connect(redisConnectionString);
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

// <---- Ignoring cycles references on foreign keys ---->
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// <---- CORS configuration ---->
var customCorsPolicy = "ReactFrontendCorsPolicy";
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: customCorsPolicy,
        builder => builder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(allowedOrigins)
            .AllowCredentials());
});


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

app.UseCors(customCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
