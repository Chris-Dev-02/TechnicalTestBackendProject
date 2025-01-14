using Microsoft.EntityFrameworkCore;
using MediatR;
using StackExchange.Redis;
using TechnicalTestBackendProject.Data;
using System.Text.Json.Serialization;
using TechnicalTestBackendProject.Services.Interfaces;
using TechnicalTestBackendProject.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechnicalTestBackendProject.Repository;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Validators;
using FluentValidation;

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

// <---- Configure JWT Authentication ---->
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

// <---- AutoMapper configuration ---->
builder.Services.AddAutoMapper(typeof(Program));

// <---- Custom general services configuration ---->
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICRUDActionsService<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO>, BoardService>();
builder.Services.AddScoped<ICRUDActionsService<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO>, TaskService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
// <---- Custom repositories configuration ---->
builder.Services.AddScoped<IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO>, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO>, BoardRepository>();
builder.Services.AddScoped<IRepository<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO>, TaskRepository>();

// <---- Validators configuration ---->
builder.Services.AddScoped<IValidator<UserCreateDTO>, SignupValidator>();
builder.Services.AddScoped<IValidator<LoginDTO>, LoginValidator>();
builder.Services.AddScoped<IValidator<BoardCreateDTO>, CreateBoardValidator>();
builder.Services.AddScoped<IValidator<BoardUpdateDTO>, UpdateBoardValidator>();
builder.Services.AddScoped<IValidator<TaskCreateDTO>, CreateTaskValidator>();
builder.Services.AddScoped<IValidator<TaskUpdateDTO>, UpdateTaskValidator>();

// <---- Service that sync databases ---->
//builder.Services.AddHostedService<CacheSyncService>();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//await app.RunAsync();

app.Run();
