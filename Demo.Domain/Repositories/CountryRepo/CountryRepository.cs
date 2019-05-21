using Demo.Model.Model;
using System.Data.Entity;
using System.Linq;

namespace Demo.Domain.Repositories.CountryRepo
{
	public class CountryRepository : GenericRepository<Country>, ICountryRepository
	{
		public CountryRepository(DbContext context)
			:base(context)
		{

		}
		public Country GetById(long Id)
		{
			return FindBy(x => x.Id == Id)
				.FirstOrDefault();
		}
	}
}
