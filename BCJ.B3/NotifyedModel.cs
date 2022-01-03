using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BCJ.B3
{
	public class NotifyedModel: INotifyPropertyChanged
	{
		public static SynchronizationContext? _scheduler = null;// = TaskScheduler.FromCurrentSynchronizationContext();
#pragma warning disable CS8603 // Possível retorno de referência nula.
		private static SynchronizationContext GetSynchronizationContext() => _scheduler;
#pragma warning restore CS8603 // Possível retorno de referência nula.


		public event PropertyChangedEventHandler? PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				if (SynchronizationContext.Current != GetSynchronizationContext())
				{
					GetSynchronizationContext().Post((state) =>
					{
						try { PropertyChanged(state, new PropertyChangedEventArgs(propertyName)); } catch { }
					}, this);
				} else
				{
					try { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); } catch {}
				}
			}
		}

		public NotifyedModel()
		{
			if (_scheduler == null)
				_scheduler = SynchronizationContext.Current;
		}
	}
}
