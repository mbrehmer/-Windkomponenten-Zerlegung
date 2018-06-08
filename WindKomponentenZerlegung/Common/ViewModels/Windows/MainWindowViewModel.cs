using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Common.ViewModels
{
	/// <summary>
	/// The view model of the App-Shell (main window)
	/// </summary>
	/// <seealso cref="Caliburn.Micro.PropertyChangedBase" />
	/// <seealso cref="WindKomponentenZerlegung.IShell" />
	[Export(typeof(IShell))]
	public class MainWindowViewModel : ViewModelBase, IShell
	{
		#region private data-members

		private string _windowTitle;

		private int _runwayHeading;
		private int _windDirection;
		private int _windSpeed;
		private List<string> _windDimension;
		private string _selectedWindDimension;

		#endregion private data-members

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
				double value = WindSpeed * Math.Cos(DegreesToRadial(WindDirection - RunwayHeading));

				string result = Math.Abs(value).ToString("N2") + " " + SelectedWindDimension;

				if (value >= 0.00) result += " Gegenwind";
				else result += " Rückenwind";

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
				double value = WindSpeed * Math.Sin(DegreesToRadial(WindDirection - RunwayHeading));

				string result = Math.Abs(value).ToString("N2") + " " + SelectedWindDimension;

				if (value >= 0.00) result += " von rechts";
				else result += " von links";

				return result;
			}
		}

		#endregion public properties

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
		/// </summary>
		/// <param name="eventAggregator">The event aggregator.</param>
		/// <param name="windowManager">The window manager.</param>
		public MainWindowViewModel() : base()
		{
			WindowTitle = "Windkomponenten-Zerlegung";

			RunwayHeading = 0;
			WindDirection = 0;
			WindSpeed = 0;
			WindDimension = new List<string> { "kt", "m/s", "km/h" };
			SelectedWindDimension = WindDimension[0];
		}

		#endregion Constructors

		#region private function members

		/// <summary>
		/// Converts degreeses into a radial.
		/// </summary>
		/// <param name="angle">The angle in degrees.</param>
		/// <returns>The angle as a radial</returns>
		private double DegreesToRadial(double angle)
		{
			return Math.PI * angle / 180.0;
		}

		#endregion private function members
	}
}