namespace IBOVTracker
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			using (Form main = new FormIBOVTracker())
			{
				Application.Run(main);
			}
		}
	}
}