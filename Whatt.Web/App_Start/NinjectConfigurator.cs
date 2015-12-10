using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Whatt.Ninject;
using Whatt.Data;
using Whatt.Web.Models.TypeMappers;
using Whatt.Core;
using WHATT.Managers;

namespace WHATT.App_Start
{
	/// <summary>
	/// Class used to set up the Ninject DI container.
	/// </summary>
	public class NinjectConfigurator
	{
		/// <summary>
		/// Entry method used by caller to configure the given 
		/// container with all of this application's 
		/// dependencies. Also configures the container as this
		/// application's dependency resolver.
		/// </summary>
		public void Configure(IKernel container)
		{
			// Add all bindings/dependencies
			AddBindings(container);

			// Use the container and our NinjectDependencyResolver as
			// application's resolver
			var resolver = new NinjectDependencyResolver(container);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}

		/// <summary>
		/// Add all bindings/dependencies to the container
		/// </summary>
		private void AddBindings(IKernel container)
		{
			 //ConfigureLog4net(container);

			container.Bind<IBetSlipRepository>().To<BetSlipRepository>();
			container.Bind<IBetSlipMapper>().To<BetSlipMapper>();
			container.Bind<IRiskManagement>().To<RiskManagement>();
			container.Bind<IDashboardManager>().To<DashboardManager>();
		}
		 
	}
}