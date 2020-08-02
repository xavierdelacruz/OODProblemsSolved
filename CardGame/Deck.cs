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
