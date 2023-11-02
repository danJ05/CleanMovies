using CleanMovie.Application.Interfaces;
using CleanMovie.Application.Services;
using CleanMovies.Infrastructures.Data;
using CleanMovies.Infrastructures.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Register configuration
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.



builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
	b => b.MigrationsAssembly("CleanMovies.WebAPi")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMoviesService , MoviesServices>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
