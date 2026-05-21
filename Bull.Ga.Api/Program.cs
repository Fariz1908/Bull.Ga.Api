using Bull.Ga.Api.Authorization;
using Bull.Ga.Api.Helpers;
using Bull.Ga.Business;
using Bull.Ga.Business.Facades;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Business.Modules;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Helpers;
using Bull.Ga.Common.Utils;
using Bull.Ga.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logPath = builder.Configuration.GetSection("LogPath").GetSection("LogDirPath").Value ?? "..//Log/Log_.log";
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    x.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    x.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Bull General Affairs API",
        Description = "API General Affairs Apps",
        Contact = new OpenApiContact
        {
            Name = "IT Administrator",
            Email = "it.staff@bull.co.id"
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                       Enter 'Bearer' [space] and then your token in the text input below.
                       \r\n\r\n Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Db Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );
builder.Services.AddMemoryCache();

// Configure strongly typed setting Object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Dependency Injection
builder.Services.AddTransient<IDomainServices, DomainServices>();

builder.Services.AddScoped<IAssetCategoryFacades, AssetCategoryFacades>();
builder.Services.AddScoped<IDropdownFacades, DropdownFacades>();
builder.Services.AddScoped<ILocationFacades, LocationFacades>();

builder.Services.AddScoped<IAssetCategoryServices, AssetCategoryServices>();
builder.Services.AddScoped<IDropdownServices, DropdownServices>();
builder.Services.AddScoped<ILocationServices, LocationServices>();
builder.Services.AddScoped<IProfileServices, ProfileServices>();

builder.Services.AddScoped<IJwtUtils, JwtUtils>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseForwardedHeaders();

    app.UseMiddleware<SwaggerRestrictionMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ClientPermission");
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
