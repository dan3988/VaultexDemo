using Demo.Website.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Newtonsoft.Json;

namespace Demo.Website.Data.Configurations;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
	private const string SampleData = """
		[
			{
				"OrganisationName": "Barclays UK PLC",
				"OrganisationNumber": "09740322",
				"AddressLine1": "1 Churchill Place",
				"Town": "London",
				"Postcode": "E14 5HP"
			},
			{
				"OrganisationName": "HSBC BANK PLC",
				"OrganisationNumber": "00014259",
				"AddressLine1": "8 Canada Square",
				"Town": "London",
				"Postcode": "E14 5HQ"
			},
			{
				"OrganisationName": "LLOYDS BANK PLC",
				"OrganisationNumber": "00002065",
				"AddressLine1": "25 Gresham Street",
				"Town": "London",
				"Postcode": "EC2V 7HN"
			},
			{
				"OrganisationName": "TSB BANK PLC",
				"OrganisationNumber": "SC095237",
				"AddressLine1": "Henry Duncan House",
				"AddressLine2": "120 George Street",
				"Town": "Edinburgh",
				"Postcode": "EH2 4LH"
			},
			{
				"OrganisationName": "CLYDESDALE BANK PLC",
				"OrganisationNumber": "SC001111",
				"AddressLine1": "30 St Vincent Place",
				"Town": "Glasgow",
				"Postcode": "G1 2HL"
			},
			{
				"OrganisationName": "STANDARD CHARTERED PLC",
				"OrganisationNumber": "00966425",
				"AddressLine1": "1 Basinghall Avenue",
				"Town": "London",
				"Postcode": "EC2V 5DD"
			},
			{
				"OrganisationName": "BANK OF SCOTLAND PLC",
				"OrganisationNumber": "SC327000",
				"AddressLine1": "The Mound",
				"Town": "Edinburgh",
				"Postcode": "EH1 1YZ"
			}
		]
		""";

	public void Configure(EntityTypeBuilder<Organisation> builder)
	{
		var sampleData = JsonConvert.DeserializeObject<Organisation[]>(SampleData)!;
		builder.HasData(sampleData);
	}
}
