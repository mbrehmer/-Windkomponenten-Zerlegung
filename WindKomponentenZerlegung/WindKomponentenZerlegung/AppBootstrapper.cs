using Caliburn.Micro;
using Common.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace WindKomponentenZerlegung
{
	/// <summary>
	/// The bootstrapper of the application
	/// </summary>
	/// <seealso cref="Caliburn.Micro.BootstrapperBase" />
	class AppBootstrapper : BootstrapperBase
	{
		#region private data-members
		/// <summary>
		/// The IoC-container
		/// </summary>
		private SimpleContainer container;
		#endregion

		#region constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="AppBootstrapper"/> class.
		/// </summary>
		public AppBootstrapper()
		{
			Initialize();
		}
		#endregion

		#region overrides
		/// <summary>
		/// Override to configure the framework and setup your IoC container.
		/// </summary>
		protected override void Configure()
		{
			container = new SimpleContainer();

			container.Singleton<IWindowManager, WindowManager>();
			container.Singleton<IEventAggregator, EventAggregator>();
			container.PerRequest<IShell, MainWindowViewModel>();

			TypeMappingConfiguration config = new TypeMappingConfiguration
			{
				DefaultSubNamespaceForViews = "WindKomponentenZerlegung",
				DefaultSubNamespaceForViewModels = "Common.ViewModels"
			};

			ViewModelLocator.ConfigureTypeMappings(config);
			ViewLocator.ConfigureTypeMappings(config);
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			List<Assembly> result = new List<Assembly>(base.SelectAssemblies());

			result.Add(typeof(IShell).Assembly);

			return result;
		}

		/// <summary>
		/// Override this to provide an IoC specific implementation.
		/// </summary>
		/// <param name="service">The service to locate.</param>
		/// <param name="key">The key to locate.</param>
		/// <returns>
		/// The located service.
		/// </returns>
		protected override object GetInstance(System.Type service, string key)
		{
			return container.GetInstance(service, key);
		}

		/// <summary>
		/// Override this to provide an IoC specific implementation
		/// </summary>
		/// <param name="service">The service to locate.</param>
		/// <returns>
		/// The located services.
		/// </returns>
		protected override IEnumerable<object> GetAllInstances(System.Type service)
		{
			return container.GetAllInstances(service);
		}

		/// <summary>
		/// Override this to provide an IoC specific implementation.
		/// </summary>
		/// <param name="instance">The instance to perform injection on.</param>
		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}

		/// <summary>
		/// Override this to add custom behavior to execute after the application starts.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The args.</param>
		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			DisplayRootViewFor<IShell>();
		}
		#endregion
	}
}
