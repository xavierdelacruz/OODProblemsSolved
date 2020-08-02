public class Call {
	private Caller caller;
	private int callId;
	private bool isResolved;
	private string message;
	
	public Call(Caller caller, string phone) {
		this.caller = caller;
		this.callId = -1;
	}
	
	public bool GetResol() {
		return this.isResolved;
	}
	
	public void SetResol(bool resol) {
		this.isResolved = resol;
	}
	
	public Caller GetCaller() {
		return this.caller;
	}
	
	public void SetMessage(string message) {
		this.message = message;
	}
	
	public string GetMessage() {
		return this.message;
	}
	
	public int GetId() {
		return this.callId;
	}
	
	public void SetId(int id) {
		this.callId = id;
	}
}