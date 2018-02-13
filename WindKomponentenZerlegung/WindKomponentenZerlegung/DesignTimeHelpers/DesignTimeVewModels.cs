using Caliburn.Micro;

namespace WindKomponentenZerlegung
{
	/// <summary>
	/// Static instanced of all view models, needed for Design-Time support.
	/// </summary>
	public static class DesignTimeVewModels
	{
		#region public properties

		/// <summary>
		/// Gets the main window view model instance for Design-TIme support.
		/// </summary>
		/// <value>
		/// The main window view model.
		/// </value>
		public static MainWindowViewModel MainWindowViewModel { get; private set; }

		#endregion public properties

		#region constructors

		/// <summary>
		/// Initializes the <see cref="DesignTimeVewModels"/> class.
		/// </summary>
		static DesignTimeVewModels()
		{
			var eventAggregator = IoC.Get<IEventAggregator>();
			var windowManager = IoC.Get<IWindowManager>();

			MainWindowViewModel = new MainWindowViewModel(eventAggregator, windowManager);
		}

		#endregion constructors
	}
}