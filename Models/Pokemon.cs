namespace PokemonReviewApp.Models;

public class Pokemon
{
	public int Id { set; get; }
	public string Name { get; set; }
	public DateTime BirthDate { get; set; }
	public ICollection<Review> Reviews { get; set; }
	public ICollection<PokemonOwner> PokemonOwners { get; set; }
	public ICollection<PokemonCategory> PokemonCategories { get; set; }
}