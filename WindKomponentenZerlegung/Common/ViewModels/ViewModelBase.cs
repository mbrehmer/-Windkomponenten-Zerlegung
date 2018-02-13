using Caliburn.Micro;

namespace Common.ViewModels
{
	/// <summary>
	/// An abstract base-class for all view models.
	/// </summary>
	/// <seealso cref="Caliburn.Micro.PropertyChangedBase" />
	public abstract class ViewModelBase : PropertyChangedBase
	{
		#region private data-members

		private double _width, _height;

		#endregion private data-members

		#region protected data members

		protected readonly IEventAggregator eventAggregator;
		protected readonly IWindowManager windowManager;

		#endregion protected data members

		#region properties

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>
		/// The width.
		/// </value>
		public double Width
		{
			get { return _width; }
			set
			{
				_width = value;
				NotifyOfPropertyChange(() => Width);
			}
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		public double Height
		{
			get { return _height; }
			set
			{
				_height = value;
				NotifyOfPropertyChange(() => Height);
			}
		}

		#endregion properties

		#region constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelBase"/> class.
		/// </summary>
		public ViewModelBase()
		{
			this.eventAggregator = IoC.Get<IEventAggregator>();
			this.windowManager = IoC.Get<IWindowManager>();

			this.Width = double.NaN;
			this.Height = double.NaN;
		}

		#endregion constructors
	}
}