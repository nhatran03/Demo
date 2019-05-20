namespace Demo.Domain.Entities
{
	public interface IIEntity<TPrimary>
	{
		TPrimary Id { get; set; }

		bool IsTransient();
	}
}
