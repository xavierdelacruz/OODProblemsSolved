public class BlackJackDeck : Deck {
	
	public BlackJackDeck() {
	}
	
	public override List<Card> CreateDeck() {
		var res = new List<Card>();
		
		foreach (BlackJackSuit suit in Enum.GetValues(typeof(BlackJackSuit))) {
			for (int i = 1; i < 14; i++) {
				res.Add(new BlackJackCard(suit, i));
			}
		}
		
		return res;
	}
}