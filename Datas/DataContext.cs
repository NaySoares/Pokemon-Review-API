using Microsoft.EntityFrameworkCore;

namespace PokemonReviewApp.Datas;

public class DataContext: DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
		
	}
}