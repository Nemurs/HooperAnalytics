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
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1) define a unique string
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 2) define allowed domains, in this case "http://hooperanalytics.com" and "*" = all
//    domains, for testing purposes only.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "http://localhost:3000/", "https://hooperanalytics.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
      });
});

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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api", () => "Hooper Analytics API V1 \n Documentation: https://github.com/Nemurs/HooperAnalytics" );

app.MapGet("/api/test", () => "api test is good!");

app.Run();
