using Demo.Website.Data.Entities;

namespace Demo.Website.Controllers.Models;

public sealed record OrganisationModel
{
	public required string OrganisationNumber { get; set; }

	public required string OrganisationName { get; set; }

	public required string AddressLine1 { get; set; }

	public string? AddressLine2 { get; set; }

	public string? AddressLine3 { get; set; }

	public required string Town { get; set; }

	public required string Postcode { get; set; }

	public Organisation ToEntity()
	{
		return new()
		{
			OrganisationNumber = OrganisationNumber,
			OrganisationName = OrganisationName,
			AddressLine1 = AddressLine1,
			AddressLine2 = AddressLine2,
			AddressLine3 = AddressLine3,
			Town = Town,
			Postcode = Postcode,
		};
	}
}