public class Dispatcher : IEmployees {
	private bool isFree;
	private CallCenter cc;
	public Dispatcher(CallCenter cc) {
		this.isFree = true;
		this.cc = cc;
	}
	
	public void Answer(Call c) {
		this.isFree = false;
		var respondents = cc.GetRespondents();
		foreach (var res in respondents) {
			if (res.GetAvail()) {		
				res.Answer(c);
				this.isFree = true;
				return;
			}
		}
		
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
	
	public bool GetAvail() {
		return this.isFree;
	}
	
	public void SetAvail(bool isAvail) {
		this.isFree = isAvail;
	}
}
