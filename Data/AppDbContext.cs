using Demo.Website.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Data;

/// <summary>
/// Represents the application's database context that defines the tables in the database.
/// </summary>
public class AppDbContext : DbContext
{
	//disable nullable warnings since the DbContext constructor will populate them.
#nullable disable
	public DbSet<Organisation> Organisations { get; private set; }

	public DbSet<Employee> Employees { get; private set; }
#nullable restore

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}
}
