public class PokemonCard : Card {
	private string pokemon { get; set;}
	private int pokedexNum { get; set;}
	private bool isFoil { get; set; }
	private string series {get; set;}
	private Moves[] moves;
	
	public PokemonCard(string pokemon, int pokedex, bool isFoil, string series, Moves[] moves) {
		this.pokemon = pokemon;
		this.pokedexNum = pokedex;
		this.isFoil = isFoil;
		this.series = series;
		this.moves = moves;
	}
}