public class Caller {
	private string name;
	private string number;
	private CallCenter cc;
	private static Call call;
	public Caller(string name, string phone, CallCenter cc) {
		this.name = name;
		this.number = phone;
		this.cc = cc;
	}
	
	public void MakeCall(string message) {
		if (call == null || call.GetResol()) {
			call = new Call(this, this.number);
			call.SetMessage(message);
			cc.ReceiveCall(call);
		} else {
			cc.ReceiveCall(call);
		}
	}
}