using Demo.Model;
using System.Data.Entity;

namespace Demo.EntityFramework
{
	public class LabDbContext: DbContext
	{
		public LabDbContext(): base("Default")
		{

		}

		public DbSet<MyFirstTable> MyFirstTable { get; set; }
	}
}
