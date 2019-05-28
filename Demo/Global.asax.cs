using Autofac;
using Autofac.Integration.Mvc;
using Demo.Modules;
using System.Web.Mvc;

namespace Demo
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			var builder = new Autofac.ContainerBuilder();

			//AreaRegistration.RegisterAllAreas();
			//FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			//RouteConfig.RegisterRoutes(RouteTable.Routes);
			//BundleConfig.RegisterBundles(BundleTable.Bundles);

			builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

			builder.RegisterModule(new RepositoryModule());
			builder.RegisterModule(new ServiceModule());
			builder.RegisterModule(new EFModule());

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
    }
}
