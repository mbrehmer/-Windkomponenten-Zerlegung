using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;

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
		private readonly IEventAggregator eventAggregator;
		private readonly IWindowManager windowManager;

		private string _windowTitle;

		private int _runwayHeading;
		private int _windDirection;
		private int _windSpeed;
		private List<string> _windDimension;
		private string _selectedWindDimension;
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

		/// <summary>
		/// Gets or sets the runway heading.
		/// </summary>
		/// <value>
		/// The runway heading.
		/// </value>
		public int RunwayHeading
		{
			get { return _runwayHeading; }
			set
			{
				_runwayHeading = value;
				NotifyOfPropertyChange(() => RunwayHeading);
				NotifyOfPropertyChange(() => HeadWindText);
				NotifyOfPropertyChange(() => CrossWindText);
			}
		}

		/// <summary>
		/// Gets or sets the wind direction.
		/// </summary>
		/// <value>
		/// The wind direction.
		/// </value>
		public int WindDirection
		{
			get { return _windDirection; }
			set
			{
				_windDirection = value;
				NotifyOfPropertyChange(() => WindDirection);
				NotifyOfPropertyChange(() => HeadWindText);
				NotifyOfPropertyChange(() => CrossWindText);
			}
		}

		/// <summary>
		/// Gets or sets the wind speed.
		/// </summary>
		/// <value>
		/// The wind speed.
		/// </value>
		public int WindSpeed
		{
			get { return _windSpeed; }
			set
			{
				_windSpeed = value;
				NotifyOfPropertyChange(() => WindSpeed);
				NotifyOfPropertyChange(() => HeadWindText);
				NotifyOfPropertyChange(() => CrossWindText);
			}
		}

		/// <summary>
		/// Gets or sets the list of possible wind dimensions.
		/// </summary>
		/// <value>
		/// The list of possible wind dimensions.
		/// </value>
		public List<string> WindDimension
		{
			get { return _windDimension; }
			set
			{
				_windDimension = value;
				NotifyOfPropertyChange(() => WindDimension);
			}
		}

		/// <summary>
		/// Gets or sets the selected wind dimension.
		/// </summary>
		/// <value>
		/// The selected wind dimension.
		/// </value>
		public string SelectedWindDimension
		{
			get { return _selectedWindDimension; }
			set
			{
				_selectedWindDimension = value;
				NotifyOfPropertyChange(() => SelectedWindDimension);
				NotifyOfPropertyChange(() => HeadWindText);
				NotifyOfPropertyChange(() => CrossWindText);
			}
		}

		/// <summary>
		/// Gets the head wind text.
		/// </summary>
		/// <value>
		/// The head wind text.
		/// </value>
		public string HeadWindText
		{
			get
			{
				string result = String.Empty;

				// TODO: implementation

				return result;
			}
		}

		/// <summary>
		/// Gets the cross wind text.
		/// </summary>
		/// <value>
		/// The cross wind text.
		/// </value>
		public string CrossWindText
		{
			get
			{
				string result = String.Empty;

				// TODO: impelmentation

				return result;
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

			RunwayHeading = 180;
			WindDirection = 180;
			WindSpeed = 0;
			WindDimension = new List<string> { "kt", "m/s", "km/h" };
			SelectedWindDimension = WindDimension[0];
		}
		#endregion
	}
}
