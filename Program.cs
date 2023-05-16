using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Datas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(options => 
  options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 26))
  ));

var app = builder.Build();

app.MapGet("/", () => "This is my Web Api");
app.Run();
