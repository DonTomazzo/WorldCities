using WorldCitiesAPI.Data;
using Microsoft.EntityFrameworkCore;
// using Swashbuckle.AspNetCore.Swagger; // Denna behövs inte nödvändigtvis här
// using Swashbuckle.AspNetCore.SwaggerGen; // Dessa är för AddSwaggerGen och UseSwaggerUI
// using Swashbuckle.AspNetCore.SwaggerUI; // De kan tas bort om AddSwaggerGen löser felet

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Lägg till DbContext till tjänsterna
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); // Denna rad är korrekt och behövs

// Konfigurera Swagger/OpenAPI.
// Du hade builder.Services.AddEndpointsApiExplorer(); och builder.Services.AddSwaggerGen();
// Dessa två rader är standard för Swagger och behövs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Denna rad SKA bara finnas EN gång!

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Använd Swagger och Swagger UI i utvecklingsmiljön
    app.UseSwagger(); // Lägg till denna rad
    app.UseSwaggerUI(); // Lägg till denna rad

    // app.MapOpenApi(); // Denna rad ska tas bort om du använder UseSwagger/UseSwaggerUI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();