using FastEndpoints;
using FastEndpoints.Swagger;
using UgandaGeoDataApi.Features.Uganda.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Uganda GeoData API";
            s.Version = "v1";
        };
        o.AutoTagPathSegmentIndex = 0;
    });

builder.Services.AddScoped<JsonFileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();