using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Website.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "OrganisationNumber", "AddressLine1", "AddressLine2", "AddressLine3", "OrganisationName", "Postcode", "Town" },
                values: new object[,]
                {
                    { "00002065", "25 Gresham Street", null, null, "LLOYDS BANK PLC", "EC2V 7HN", "London" },
                    { "00014259", "8 Canada Square", null, null, "HSBC BANK PLC", "E14 5HQ", "London" },
                    { "00966425", "1 Basinghall Avenue", null, null, "STANDARD CHARTERED PLC", "EC2V 5DD", "London" },
                    { "09740322", "1 Churchill Place", null, null, "Barclays UK PLC", "E14 5HP", "London" },
                    { "SC001111", "30 St Vincent Place", null, null, "CLYDESDALE BANK PLC", "G1 2HL", "Glasgow" },
                    { "SC095237", "Henry Duncan House", "120 George Street", null, "TSB BANK PLC", "EH2 4LH", "Edinburgh" },
                    { "SC327000", "The Mound", null, null, "BANK OF SCOTLAND PLC", "EH1 1YZ", "Edinburgh" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "OrganisationNumber" },
                values: new object[,]
                {
                    { 1, "Janet", "Smith", "09740322" },
                    { 2, "Frank", "Bloswick", "09740322" },
                    { 3, "Tonya", "Bazinaw", "09740322" },
                    { 4, "Mike", "St. Onge", "09740322" },
                    { 5, "Jackie", "Jones", "09740322" },
                    { 6, "Darren", "Tillbrooke", "09740322" },
                    { 7, "Stephanie", "Holsinger", "09740322" },
                    { 8, "Rene", "Hughey", "09740322" },
                    { 9, "Robert", "Rogers", "09740322" },
                    { 10, "Richard", "LaPine", "09740322" },
                    { 11, "Kathy", "Summerfield", "09740322" },
                    { 12, "Kathy", "Bodwin", "09740322" },
                    { 13, "Mitch", "Krause", "00002065" },
                    { 14, "George", "Dow", "00002065" },
                    { 15, "Jack", "Malone", "00002065" },
                    { 16, "Bill", "Schweiz", "00002065" },
                    { 17, "Mark", "Gunter", "00002065" },
                    { 18, "Bob", "Anderson", "00002065" },
                    { 19, "Scott", "Simpson", "00002065" },
                    { 20, "Phil", "Dingman", "00002065" },
                    { 21, "Chad", "Leiker", "00002065" },
                    { 22, "Ian", "Benson", "00002065" },
                    { 23, "Nicole", "Lane", "00002065" },
                    { 24, "Steve", "Lundeen", "00002065" },
                    { 25, "Erica", "Black", "00002065" },
                    { 26, "Xenos", "Mathis", "00002065" },
                    { 27, "Kyle", "Good", "00002065" },
                    { 28, "Raja", "Dejesus", "00002065" },
                    { 29, "Timothy", "Frazier", "00002065" },
                    { 30, "Francine", "Morrison", "00002065" },
                    { 31, "Avram", "Pate", "SC095237" },
                    { 32, "Hammett", "Coffey", "SC095237" },
                    { 33, "Hasad", "Wise", "SC095237" },
                    { 34, "Cullen", "Riddle", "SC095237" },
                    { 35, "Kato", "Delgado", "SC095237" },
                    { 36, "Todd", "Wright", "SC095237" },
                    { 37, "Troy", "Mccoy", "SC095237" },
                    { 38, "Gil", "Duncan", "SC095237" },
                    { 39, "Lionel", "Espinoza", "SC095237" },
                    { 40, "Victor", "Merrill", "SC095237" },
                    { 41, "Gennifer", "Vance", "SC001111" },
                    { 42, "Chancellor", "Warner", "SC001111" },
                    { 43, "Davis", "Wolf", "SC001111" },
                    { 44, "Carlos", "Clarke", "00966425" },
                    { 45, "Dolan", "Mercado", "00966425" },
                    { 46, "Helen", "Guthrie", "00966425" },
                    { 47, "Elmo", "Douglas", "00966425" },
                    { 48, "Kane", "Rice", "00966425" },
                    { 49, "Colt", "Rowland", "00966425" },
                    { 50, "John", "Rose", "00966425" },
                    { 51, "Alfonso", "Hopkins", "00966425" },
                    { 52, "Ida", "Watts", "00966425" },
                    { 53, "Jennifer", "Coleman", "00966425" },
                    { 54, "Ciaran", "Newton", "00966425" },
                    { 55, "Hiram", "Carrillo", "00966425" },
                    { 56, "Devin", "Russell", "00966425" },
                    { 57, "Arsenio", "Jensen", "00966425" },
                    { 58, "Otto", "Gibbs", "00966425" },
                    { 59, "Hiram", "Vega", "00966425" },
                    { 60, "Jarrod", "Randolph", "SC327000" },
                    { 61, "Josiah", "Gates", "SC327000" },
                    { 62, "Brandon", "Stanley", "SC327000" },
                    { 63, "Kennedy", "Nunez", "SC327000" },
                    { 64, "Lewis", "Sanchez", "SC327000" },
                    { 65, "Kassie", "Chaney", "SC327000" },
                    { 66, "Lance", "Knox", "SC327000" },
                    { 67, "Lamar", "Harrison", "SC327000" },
                    { 68, "Honorato", "Montgomery", "SC327000" },
                    { 69, "Lisa", "Nielsen", "00014259" },
                    { 70, "Layla", "Barr", "00014259" },
                    { 71, "Nancy", "Mcclain", "00014259" },
                    { 72, "Kato", "Delgado", "00014259" },
                    { 73, "Todd", "Wright", "00014259" },
                    { 74, "Troy", "Mccoy", "00014259" },
                    { 75, "Gil", "Duncan", "00014259" },
                    { 76, "Lionel", "Espinoza", "00014259" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "00002065");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "00014259");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "00966425");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "09740322");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "SC001111");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "SC095237");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "OrganisationNumber",
                keyValue: "SC327000");
        }
    }
}
