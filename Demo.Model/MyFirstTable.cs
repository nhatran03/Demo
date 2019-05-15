using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Model
{
	[Table("MyFirstTable")]
	public class MyFirstTable
	{
		public const int MaxNamelength = 50;
		[Key]
		public int Id { get; set; }
		[StringLength(MaxNamelength)]
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
