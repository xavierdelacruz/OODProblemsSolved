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