namespace BCJ.Profit
{
	public delegate void MapsTo(Topic x);

	public class Topic
	{
		public int Id;
		public string RtdCode;
		public string RtdSubject;
		public event MapsTo UpdateCallback;
		private object? lastReceivedValue;
		public object Reference;

		public object? LastReceivedValue
		{
			get => lastReceivedValue;
			set
			{
				lastReceivedValue = value;
				UpdateCallback?.Invoke(this);
			}
		}

		private static int seqIds = 10000;
		private static readonly object semaforo = new();

		public Topic(string code, string subject, object reference, MapsTo updateCallback)
		{
			lock (semaforo)
			{
				Id = ++seqIds;
			}
			RtdCode = code;
			RtdSubject = subject;
			Reference = reference;
			UpdateCallback = updateCallback;
		}
		public object[] RtdTopic()
		{
			object[] topic = new object[2];
			topic[0] = RtdCode;
			topic[1] = RtdSubject;
			return topic;
		}
	}

}