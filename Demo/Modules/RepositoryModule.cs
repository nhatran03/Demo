using Autofac;
using System.Reflection;

namespace Demo.Modules
{
	public class RepositoryModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("Demo.Domain"))
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}