using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Data.Entities;

[PrimaryKey(nameof(OrganisationNumber))]
public sealed record Organisation
{
	[Required]
	public required string OrganisationNumber { get; set; }

	[Required]
	public required string OrganisationName { get; set; }

	[Required]
	public required string AddressLine1 { get; set; }

	public string? AddressLine2 { get; set; }

	public string? AddressLine3 { get; set; }

	[Required]
	public required string Town { get; set; }

	[Required]
	public required string Postcode { get; set; }
}
