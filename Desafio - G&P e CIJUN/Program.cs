using Desafio___G_P_e_CIJUN.Data;
using Desafio___G_P_e_CIJUN.Repositories;
using Desafio___G_P_e_CIJUN.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

// Services
builder.Services.AddScoped<IScoreService, ScoreService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger (somente em desenvolvimento)
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// CORs
app.UseCors(policy =>
{
	policy.AllowAnyOrigin()
		  .AllowAnyHeader()
		  .AllowAnyMethod();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
