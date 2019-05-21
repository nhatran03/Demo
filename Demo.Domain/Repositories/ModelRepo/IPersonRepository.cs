using Demo.Model.Model;

namespace Demo.Domain.Repositories.ModelRepo
{
	public interface IPersonRepository : IGenericRepository<Person>
	{
		Person GetById(long Id);
	}
}
