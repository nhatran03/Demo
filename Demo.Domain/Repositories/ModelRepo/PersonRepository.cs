using Demo.Model.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Demo.Domain.Repositories.ModelRepo
{
	public class PersonRepository : GenericRepository<Person>, IPersonRepository
	{
		public PersonRepository(DbContext context)
			:base(context)
		{

		}

		public override IEnumerable<Person> GetAll()
		{
			return _entities.Set<Person>()
				.Include(x => x.Country)
				.AsEnumerable();
		}
		public Person GetById(long Id)
		{
			return _dbset.Include(x => x.Country)
				.Where(x => x.Id == Id)
				.FirstOrDefault();
		}
	}
}
