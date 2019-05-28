using Autofac;
using Demo.Domain.Uow;
using Demo.EntityFramework;
using System.Data.Entity;

namespace Demo.Modules
{
	public class EFModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule(new RepositoryModule());

			builder.RegisterType(typeof(LabDbContext)).As(typeof(DbContext)).AsImplementedInterfaces();
			builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
		}
	}
}