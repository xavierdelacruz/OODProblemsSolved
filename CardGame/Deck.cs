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
