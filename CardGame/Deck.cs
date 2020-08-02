using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		try {
			var dealer = new Dealer(new BlackJackDeck(), 10000);
			var player1 = new Player("John", dealer);
			var player2 = new Player("Joe", dealer);			
			var card = dealer.DealCard();
			
			Console.WriteLine("value: " + card.GetValue() + " suit: " + card.GetSuit());
			dealer.AddCard(card);
			dealer.Shuffle();
			card = dealer.DealCard();
			Console.WriteLine("value: " + card.GetValue() + " suit: " + card.GetSuit());
			
		} catch (Exception ex) {
			Console.WriteLine(ex.Message);
		}
	}
}

public abstract class Deck {
	public abstract List<Card> CreateDeck();
}

public class Player {
	private List<BlackJackCard> hand;
	private string name;
	private Dealer dealer;
	private int score;
	
	public Player(string name, Dealer dealer) {
		this.name = name;
		this.hand = new List<BlackJackCard>();
		this.dealer = dealer;
		this.score = 0;
	}
}

public class Dealer {
	private List<Card> deck;
	private HashSet<Card> dealt;
	private int money;
	
	public Dealer(Deck deck, int money) {
		this.deck = deck.CreateDeck();
		this.dealt = new HashSet<Card>();
		this.money = money;
	}
	
	public void Shuffle(){
		var count = deck.Count;
		var rng = new Random();
		for (int i = 0; i < count; i++) {
			var tmp = deck[i];
			var next = rng.Next(0, count);
			deck[i] = deck[next];
			deck[next] = tmp;
		}
	}
	
	
	public BlackJackCard DealCard(int index) {
		if (deck.Count <= 0) {
			throw new Exception("No cards left to deal");
		}
		
		var card = deck[index];
		dealt.Add(card);
		deck.Remove(card);
		return (BlackJackCard) card;
	}
	
	public BlackJackCard DealCard() {
		if (deck.Count <= 0) {
			throw new Exception("No cards left to deal");
		}
		
		var card = deck[deck.Count-1];
		dealt.Add(card);
		deck.Remove(card);
		return (BlackJackCard) card;
	}
	
	public List<BlackJackCard> DealHand(int count) {
		if (deck.Count <= 0) {
			throw new Exception("No cards left to deal");
		}
		
		var res = new List<BlackJackCard>();
		for (int i = 0; i < count; i++) {
			var deckCount = deck.Count;
			var rng = new Random();
			var next = rng.Next(0, deckCount);
			var card = (BlackJackCard) deck[next];
			res.Add(card);
			deck.Remove(card);
			dealt.Add(card);
		}
		
		return res;
	}
	
	public void AddCard(BlackJackCard card) {
		if (dealt.Contains(card)) {
			dealt.Remove(card);
			deck.Add(card);
			Console.WriteLine("Added card back successfully to deck");
		} else {
			throw new Exception("Already have the same card: " + card.GetValue() + " " + card.GetSuit()); 
		}
	}
}
		

public abstract class Card {
}
			
public class BlackJackCard : Card { 
	private int val;
	private BlackJackSuit suit;
	
	public BlackJackCard(BlackJackSuit suit, int val) {
		if (val < 1 || val > 13) {
			Console.WriteLine("Invalid card");
		}
		
		if (!Enum.IsDefined(typeof(BlackJackSuit), suit)) {
			Console.WriteLine("Invalid suit");
		}
			
		this.val = val;
		this.suit = suit;
	}
	
	public int GetValue() {
		return this.val;
	}
	
	public BlackJackSuit GetSuit() {
		return this.suit;
	}
}

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

public class Moves {
	public Moves() {
		
	}
}

public enum BlackJackSuit { 
	HEART,
	SPADE,
	CLOVER,
	DIAMOND,
}