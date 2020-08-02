public class Respondent : IEmployees {
	private bool isFree;
	private CallCenter cc;
	public Respondent(CallCenter cc) {
		this.isFree = true;
		this.cc = cc;
	}
	
	public void Answer(Call c) {
		if (Resolve()) {
			this.isFree = false;
			c.SetResol(true);
			cc.GetOutstandingCalls().Remove(c.GetId());
			this.isFree = true;
		} else {
			Escalate(c);
		}
	}
	
	private void Escalate(Call c) {
		this.isFree = false;
		var managers = cc.GetManagers();
		foreach (var manager in managers) {
			if (manager.GetAvail()) {
				manager.Answer(c);
				this.isFree = true;
				return;
			}
		} 
		
		var directors = cc.GetDirectors();
		foreach (var director in directors) {
			if (director.GetAvail()) {
				director.Answer(c);
				this.isFree = true;
				return;
			}
		}
		
		// At this point, no one was able to answer the call.
		// Put it back in the queue.
		cc.GetCalls().Enqueue(c);
		this.isFree = true;
	}
	
	private bool Resolve() {
		Random rng = new Random();
		return rng.Next(0, 2) > 0;
	}
	
	public bool GetAvail() {
		return this.isFree;
	}
	
	public void SetAvail(bool isAvail) {
		this.isFree = isAvail;
	}
}