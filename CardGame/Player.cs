
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