using Demo.Website.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Newtonsoft.Json;

namespace Demo.Website.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	private const string SampleData = """
		[
			{
				"EmployeeId": 1,
				"OrganisationNumber": "09740322",
				"FirstName": "Janet",
				"LastName": "Smith"
			},
			{
				"EmployeeId": 2,
				"OrganisationNumber": "09740322",
				"FirstName": "Frank",
				"LastName": "Bloswick"
			},
			{
				"EmployeeId": 3,
				"OrganisationNumber": "09740322",
				"FirstName": "Tonya",
				"LastName": "Bazinaw"
			},
			{
				"EmployeeId": 4,
				"OrganisationNumber": "09740322",
				"FirstName": "Mike",
				"LastName": "St. Onge"
			},
			{
				"EmployeeId": 5,
				"OrganisationNumber": "09740322",
				"FirstName": "Jackie",
				"LastName": "Jones"
			},
			{
				"EmployeeId": 6,
				"OrganisationNumber": "09740322",
				"FirstName": "Darren",
				"LastName": "Tillbrooke"
			},
			{
				"EmployeeId": 7,
				"OrganisationNumber": "09740322",
				"FirstName": "Stephanie",
				"LastName": "Holsinger"
			},
			{
				"EmployeeId": 8,
				"OrganisationNumber": "09740322",
				"FirstName": "Rene",
				"LastName": "Hughey"
			},
			{
				"EmployeeId": 9,
				"OrganisationNumber": "09740322",
				"FirstName": "Robert",
				"LastName": "Rogers"
			},
			{
				"EmployeeId": 10,
				"OrganisationNumber": "09740322",
				"FirstName": "Richard",
				"LastName": "LaPine"
			},
			{
				"EmployeeId": 11,
				"OrganisationNumber": "09740322",
				"FirstName": "Kathy",
				"LastName": "Summerfield"
			},
			{
				"EmployeeId": 12,
				"OrganisationNumber": "09740322",
				"FirstName": "Kathy",
				"LastName": "Bodwin"
			},
			{
				"EmployeeId": 13,
				"OrganisationNumber": "00002065",
				"FirstName": "Mitch",
				"LastName": "Krause"
			},
			{
				"EmployeeId": 14,
				"OrganisationNumber": "00002065",
				"FirstName": "George",
				"LastName": "Dow"
			},
			{
				"EmployeeId": 15,
				"OrganisationNumber": "00002065",
				"FirstName": "Jack",
				"LastName": "Malone"
			},
			{
				"EmployeeId": 16,
				"OrganisationNumber": "00002065",
				"FirstName": "Bill",
				"LastName": "Schweiz"
			},
			{
				"EmployeeId": 17,
				"OrganisationNumber": "00002065",
				"FirstName": "Mark",
				"LastName": "Gunter"
			},
			{
				"EmployeeId": 18,
				"OrganisationNumber": "00002065",
				"FirstName": "Bob",
				"LastName": "Anderson"
			},
			{
				"EmployeeId": 19,
				"OrganisationNumber": "00002065",
				"FirstName": "Scott",
				"LastName": "Simpson"
			},
			{
				"EmployeeId": 20,
				"OrganisationNumber": "00002065",
				"FirstName": "Phil",
				"LastName": "Dingman"
			},
			{
				"EmployeeId": 21,
				"OrganisationNumber": "00002065",
				"FirstName": "Chad",
				"LastName": "Leiker"
			},
			{
				"EmployeeId": 22,
				"OrganisationNumber": "00002065",
				"FirstName": "Ian",
				"LastName": "Benson"
			},
			{
				"EmployeeId": 23,
				"OrganisationNumber": "00002065",
				"FirstName": "Nicole",
				"LastName": "Lane"
			},
			{
				"EmployeeId": 24,
				"OrganisationNumber": "00002065",
				"FirstName": "Steve",
				"LastName": "Lundeen"
			},
			{
				"EmployeeId": 25,
				"OrganisationNumber": "00002065",
				"FirstName": "Erica",
				"LastName": "Black"
			},
			{
				"EmployeeId": 26,
				"OrganisationNumber": "00002065",
				"FirstName": "Xenos",
				"LastName": "Mathis"
			},
			{
				"EmployeeId": 27,
				"OrganisationNumber": "00002065",
				"FirstName": "Kyle",
				"LastName": "Good"
			},
			{
				"EmployeeId": 28,
				"OrganisationNumber": "00002065",
				"FirstName": "Raja",
				"LastName": "Dejesus"
			},
			{
				"EmployeeId": 29,
				"OrganisationNumber": "00002065",
				"FirstName": "Timothy",
				"LastName": "Frazier"
			},
			{
				"EmployeeId": 30,
				"OrganisationNumber": "00002065",
				"FirstName": "Francine",
				"LastName": "Morrison"
			},
			{
				"EmployeeId": 31,
				"OrganisationNumber": "SC095237",
				"FirstName": "Avram",
				"LastName": "Pate"
			},
			{
				"EmployeeId": 32,
				"OrganisationNumber": "SC095237",
				"FirstName": "Hammett",
				"LastName": "Coffey"
			},
			{
				"EmployeeId": 33,
				"OrganisationNumber": "SC095237",
				"FirstName": "Hasad",
				"LastName": "Wise"
			},
			{
				"EmployeeId": 34,
				"OrganisationNumber": "SC095237",
				"FirstName": "Cullen",
				"LastName": "Riddle"
			},
			{
				"EmployeeId": 35,
				"OrganisationNumber": "SC095237",
				"FirstName": "Kato",
				"LastName": "Delgado"
			},
			{
				"EmployeeId": 36,
				"OrganisationNumber": "SC095237",
				"FirstName": "Todd",
				"LastName": "Wright"
			},
			{
				"EmployeeId": 37,
				"OrganisationNumber": "SC095237",
				"FirstName": "Troy",
				"LastName": "Mccoy"
			},
			{
				"EmployeeId": 38,
				"OrganisationNumber": "SC095237",
				"FirstName": "Gil",
				"LastName": "Duncan"
			},
			{
				"EmployeeId": 39,
				"OrganisationNumber": "SC095237",
				"FirstName": "Lionel",
				"LastName": "Espinoza"
			},
			{
				"EmployeeId": 40,
				"OrganisationNumber": "SC095237",
				"FirstName": "Victor",
				"LastName": "Merrill"
			},
			{
				"EmployeeId": 41,
				"OrganisationNumber": "SC001111",
				"FirstName": "Gennifer",
				"LastName": "Vance"
			},
			{
				"EmployeeId": 42,
				"OrganisationNumber": "SC001111",
				"FirstName": "Chancellor",
				"LastName": "Warner"
			},
			{
				"EmployeeId": 43,
				"OrganisationNumber": "SC001111",
				"FirstName": "Davis",
				"LastName": "Wolf"
			},
			{
				"EmployeeId": 44,
				"OrganisationNumber": "00966425",
				"FirstName": "Carlos",
				"LastName": "Clarke"
			},
			{
				"EmployeeId": 45,
				"OrganisationNumber": "00966425",
				"FirstName": "Dolan",
				"LastName": "Mercado"
			},
			{
				"EmployeeId": 46,
				"OrganisationNumber": "00966425",
				"FirstName": "Helen",
				"LastName": "Guthrie"
			},
			{
				"EmployeeId": 47,
				"OrganisationNumber": "00966425",
				"FirstName": "Elmo",
				"LastName": "Douglas"
			},
			{
				"EmployeeId": 48,
				"OrganisationNumber": "00966425",
				"FirstName": "Kane",
				"LastName": "Rice"
			},
			{
				"EmployeeId": 49,
				"OrganisationNumber": "00966425",
				"FirstName": "Colt",
				"LastName": "Rowland"
			},
			{
				"EmployeeId": 50,
				"OrganisationNumber": "00966425",
				"FirstName": "John",
				"LastName": "Rose"
			},
			{
				"EmployeeId": 51,
				"OrganisationNumber": "00966425",
				"FirstName": "Alfonso",
				"LastName": "Hopkins"
			},
			{
				"EmployeeId": 52,
				"OrganisationNumber": "00966425",
				"FirstName": "Ida",
				"LastName": "Watts"
			},
			{
				"EmployeeId": 53,
				"OrganisationNumber": "00966425",
				"FirstName": "Jennifer",
				"LastName": "Coleman"
			},
			{
				"EmployeeId": 54,
				"OrganisationNumber": "00966425",
				"FirstName": "Ciaran",
				"LastName": "Newton"
			},
			{
				"EmployeeId": 55,
				"OrganisationNumber": "00966425",
				"FirstName": "Hiram",
				"LastName": "Carrillo"
			},
			{
				"EmployeeId": 56,
				"OrganisationNumber": "00966425",
				"FirstName": "Devin",
				"LastName": "Russell"
			},
			{
				"EmployeeId": 57,
				"OrganisationNumber": "00966425",
				"FirstName": "Arsenio",
				"LastName": "Jensen"
			},
			{
				"EmployeeId": 58,
				"OrganisationNumber": "00966425",
				"FirstName": "Otto",
				"LastName": "Gibbs"
			},
			{
				"EmployeeId": 59,
				"OrganisationNumber": "00966425",
				"FirstName": "Hiram",
				"LastName": "Vega"
			},
			{
				"EmployeeId": 60,
				"OrganisationNumber": "SC327000",
				"FirstName": "Jarrod",
				"LastName": "Randolph"
			},
			{
				"EmployeeId": 61,
				"OrganisationNumber": "SC327000",
				"FirstName": "Josiah",
				"LastName": "Gates"
			},
			{
				"EmployeeId": 62,
				"OrganisationNumber": "SC327000",
				"FirstName": "Brandon",
				"LastName": "Stanley"
			},
			{
				"EmployeeId": 63,
				"OrganisationNumber": "SC327000",
				"FirstName": "Kennedy",
				"LastName": "Nunez"
			},
			{
				"EmployeeId": 64,
				"OrganisationNumber": "SC327000",
				"FirstName": "Lewis",
				"LastName": "Sanchez"
			},
			{
				"EmployeeId": 65,
				"OrganisationNumber": "SC327000",
				"FirstName": "Kassie",
				"LastName": "Chaney"
			},
			{
				"EmployeeId": 66,
				"OrganisationNumber": "SC327000",
				"FirstName": "Lance",
				"LastName": "Knox"
			},
			{
				"EmployeeId": 67,
				"OrganisationNumber": "SC327000",
				"FirstName": "Lamar",
				"LastName": "Harrison"
			},
			{
				"EmployeeId": 68,
				"OrganisationNumber": "SC327000",
				"FirstName": "Honorato",
				"LastName": "Montgomery"
			},
			{
				"EmployeeId": 69,
				"OrganisationNumber": "00014259",
				"FirstName": "Lisa",
				"LastName": "Nielsen"
			},
			{
				"EmployeeId": 70,
				"OrganisationNumber": "00014259",
				"FirstName": "Layla",
				"LastName": "Barr"
			},
			{
				"EmployeeId": 71,
				"OrganisationNumber": "00014259",
				"FirstName": "Nancy",
				"LastName": "Mcclain"
			},
			{
				"EmployeeId": 72,
				"OrganisationNumber": "00014259",
				"FirstName": "Kato",
				"LastName": "Delgado"
			},
			{
				"EmployeeId": 73,
				"OrganisationNumber": "00014259",
				"FirstName": "Todd",
				"LastName": "Wright"
			},
			{
				"EmployeeId": 74,
				"OrganisationNumber": "00014259",
				"FirstName": "Troy",
				"LastName": "Mccoy"
			},
			{
				"EmployeeId": 75,
				"OrganisationNumber": "00014259",
				"FirstName": "Gil",
				"LastName": "Duncan"
			},
			{
				"EmployeeId": 76,
				"OrganisationNumber": "00014259",
				"FirstName": "Lionel",
				"LastName": "Espinoza"
			}
		]
		""";

	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		var sampleData = JsonConvert.DeserializeObject<Employee[]>(SampleData)!;
		builder.HasData(sampleData);
	}
}
