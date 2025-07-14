using WorldCitiesAPI.Data;
using Microsoft.EntityFrameworkCore;
// using Swashbuckle.AspNetCore.Swagger; // Denna beh�vs inte n�dv�ndigtvis h�r
// using Swashbuckle.AspNetCore.SwaggerGen; // Dessa �r f�r AddSwaggerGen och UseSwaggerUI
// using Swashbuckle.AspNetCore.SwaggerUI; // De kan tas bort om AddSwaggerGen l�ser felet

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// L�gg till DbContext till tj�nsterna
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); // Denna rad �r korrekt och beh�vs

// Konfigurera Swagger/OpenAPI.
// Du hade builder.Services.AddEndpointsApiExplorer(); och builder.Services.AddSwaggerGen();
// Dessa tv� rader �r standard f�r Swagger och beh�vs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Denna rad SKA bara finnas EN g�ng!

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Anv�nd Swagger och Swagger UI i utvecklingsmilj�n
    app.UseSwagger(); // L�gg till denna rad
    app.UseSwaggerUI(); // L�gg till denna rad

    // app.MapOpenApi(); // Denna rad ska tas bort om du anv�nder UseSwagger/UseSwaggerUI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();