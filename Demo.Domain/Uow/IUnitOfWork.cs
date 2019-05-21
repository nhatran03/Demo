using System;

namespace Demo.Domain.Uow
{
	public interface IUnitOfWork : IDisposable
	{
		int Commit();
	}
}
