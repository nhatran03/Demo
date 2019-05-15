namespace Demo.Domain.Entities
{
	public interface IEntity<TPrimary>
	{
		TPrimary Id { get; set; }

		bool IsTransient();
	}
}
