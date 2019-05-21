using Demo.Model.Model;

namespace Demo.Domain.Repositories.CountryRepo
{
	public interface ICountryRepository : IGenericRepository<Country>
	{
		Country GetById(long Id);
	}
}
