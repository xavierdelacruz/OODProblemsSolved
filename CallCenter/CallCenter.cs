public class CallCenter {
	private List<Dispatcher> dispatchers;
	private List<Respondent> respondents;
	private List<Manager> managers;
	private List<Director> directors;
	private Queue<Call> calls;
	private HashSet<int> callIdsOutstanding;
	private static CallCenter instance;
	
	// Singleton Design Pattern. Can only have one call center at a time.
	public static CallCenter GetInstance() {
		if (instance == null) {
			instance = new CallCenter();
		}
		return instance;
	}
	
	public static void Main() {
	
	}
	
	protected CallCenter() {
		this.dispatchers = new List<Dispatcher>();
		this.respondents = new List<Respondent>();
		this.managers = new List<Manager>();
		this.directors = new List<Director>();
		this.calls = new Queue<Call>();
		this.callIdsOutstanding = new HashSet<int>();
	}
	
	public void DispatchCall() {
		var currCall = calls.Dequeue();
		if (!SendToDispatcher(dispatchers, currCall)) {
			calls.Enqueue(currCall);
		}
	}
	
	private bool SendToDispatcher(List<Dispatcher> dispatchers, Call call) {
		foreach (var dispatcher in dispatchers) {
			if (dispatcher.GetAvail()) {
				dispatcher.Answer(call);
				return true;
			}
		}		
		return false;
	}
	
	public void ReceiveCall(Call c) {	
		var id = c.GetId();		
		if (callIdsOutstanding.Contains(id)) {
			Console.WriteLine("Call already in queue. Please wait for your turn.");
		} else {
			Random rng = new Random();
			// This means that its a new call. Give it a new id that's not in the outstanding ones, or -1
			while (id == -1 || callIdsOutstanding.Contains(id)) {
				id = rng.Next(0, 65535);
			}
			calls.Enqueue(c);
			callIdsOutstanding.Add(c.GetId());
		}
	}
	
	public List<Respondent> GetRespondents() {
		return this.respondents;
	}
	
	public List<Manager> GetManagers() {
		return this.managers;
	}
	
	public List<Director> GetDirectors() {
		return this.directors;
	}
	
	public Queue<Call> GetCalls() {
		return this.calls;
	}
	
	public HashSet<int> GetOutstandingCalls() {
		return this.callIdsOutstanding;
	}
}