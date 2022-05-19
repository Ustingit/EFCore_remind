using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore2DBFirst
{
	[Table("Company")] //analog of modelBuilder.Entity<Company>().ToTable("Company"); through fluent-API
	public class Company
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public CompanyType? Type { get; set; }

		[Column("juriName")] //analog of modelBuilder.Entity<Company>().Property(u => u.JuridicalName).HasColumnName("juriName"); in fluent-API
		public string? JuridicalName { get; set; }

		public IEnumerable<User> Users { get; set; } = new List<User>();

		[NotMapped]
		public int CountOfEmployees => Users.Count();

	}

	public enum CompanyType
	{
		Small = 0,
		Medium = 1,
		Big = 2
	}
}
