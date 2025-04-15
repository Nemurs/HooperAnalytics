using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hooper Analytics API", Description = "Advanced Basketball Data Analytics for Everyone", Version = "v1" });
});

builder.Services.AddOpenApi();

//Define a unique string for Cors Policy
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "https://localhost:3000",
            "https://www.hooperanalytics.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
      });
});

builder.Services.AddControllers();

//Build
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hooper Analytics API V1");
    });
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api", () => "Hooper Analytics API V1 \n Documentation: https://github.com/Nemurs/HooperAnalytics").RequireCors(MyAllowSpecificOrigins);

app.MapGet("/api/test", () => new { Message = "api test is good!" }).RequireCors(MyAllowSpecificOrigins);

app.Run();
