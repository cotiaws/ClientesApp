using ClientesApp.Domain.Extensions;
using ClientesApp.Infra.Data.MongoDB.Extensions;
using ClientesApp.Infra.Data.SqlServer.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddDomainServicesConfig();
builder.Services.AddSqlServerConfig(builder.Configuration);
builder.Services.AddMongoDBConfig(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("All", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(options => {
    options.WithTheme(ScalarTheme.BluePlanet);
});

app.UseCors("All");

app.UseAuthorization();
app.MapControllers();
app.Run();
