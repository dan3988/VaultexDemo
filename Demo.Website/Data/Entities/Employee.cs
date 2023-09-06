using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Data.Entities;

[PrimaryKey(nameof(EmployeeId))]
public sealed record Employee
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int EmployeeId { get; set; }

	[Required, ForeignKey(nameof(Organisation))]
	public required string OrganisationNumber { get; set; }

	[JsonIgnore]
	public Organisation? Organisation { get; private set; }

	[Required, MinLength(2), MaxLength(50)]
	public required string FirstName { get; set; }

	[Required, MinLength(2), MaxLength(50)]
	public required string LastName { get; set; }
}
