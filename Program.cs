using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Datas;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => 
  options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 26))
  ));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
  SeedData(app);

void SeedData(IHost app)
{
  var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

  using (var scope = scopedFactory?.CreateScope())
  {
    var service = scope?.ServiceProvider.GetService<Seed>();
    service?.SeedDataContext();
  }
}



app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "This is my Web Api");
app.Run();
