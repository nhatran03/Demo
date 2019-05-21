using System;
using System.Data.Entity;

namespace Demo.Domain.Uow
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private DbContext dbContext;

		public UnitOfWork(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public int Commit()
		{
			return dbContext.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if(dbContext != null)
				{
					dbContext.Dispose();
					dbContext = null;
				}
			}
		}
	}
}
