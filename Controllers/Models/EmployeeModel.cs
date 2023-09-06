using Demo.Website.Data.Entities;

namespace Demo.Website.Controllers.Models;

public sealed record EmployeeModel
{
	public required string OrganisationNumber { get; set; }

	public required string FirstName { get; set; }

	public required string LastName { get; set; }

	public Employee ToEntity(int id = 0)
	{
		return new()
		{
			EmployeeId = id,
			FirstName = FirstName,
			LastName = LastName,
			OrganisationNumber = OrganisationNumber
		};
	}
}
