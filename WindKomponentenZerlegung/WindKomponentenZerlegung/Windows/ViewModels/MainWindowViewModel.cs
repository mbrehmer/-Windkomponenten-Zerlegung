using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace WindKomponentenZerlegung
{
	/// <summary>
	/// The view model of the App-Shell (main window)
	/// </summary>
	/// <seealso cref="Caliburn.Micro.PropertyChangedBase" />
	/// <seealso cref="WindKomponentenZerlegung.IShell" />
	[Export (typeof(IShell))]
	public class MainWindowViewModel : PropertyChangedBase, IShell
	{
		#region private data-members
		private string _windowTitle;
		private readonly IEventAggregator eventAggregator;
		private readonly IWindowManager windowManager;
		#endregion

		#region public properties
		/// <summary>
		/// Gets or sets the window title.
		/// </summary>
		/// <value>
		/// The window title.
		/// </value>
		public string WindowTitle
		{
			get { return _windowTitle; }
			set
			{
				_windowTitle = value;
				NotifyOfPropertyChange(() => WindowTitle);
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
		/// </summary>
		/// <param name="eventAggregator">The event aggregator.</param>
		/// <param name="windowManager">The window manager.</param>
		public MainWindowViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
		{
			this.eventAggregator = eventAggregator;
			this.windowManager = windowManager;

			WindowTitle = "Windkomponenten-Zerlegung";
		}
		#endregion
	}
}
