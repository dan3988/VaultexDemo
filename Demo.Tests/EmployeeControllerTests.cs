using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;

using Demo.Website.Data.Entities;

using Newtonsoft.Json.Linq;

namespace Demo.Tests;

public static class EmployeeControllerTests
{
	[Test]
	public static async Task CanCreateEmployees()
	{
		var createModel = new Employee
		{
			OrganisationNumber = "00014259",
			FirstName = "Test",
			LastName = "User"
		};

		int id;

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Employee", createModel))
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
			Assert.That(response.Content.Headers.ContentType.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));

			id = await response.Content.ReadAsAsync<int>();
		}

		using (var response = await client.GetAsync($"/api/Employee/{id}"))
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
			Assert.That(response.Content.Headers.ContentType.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));

			var employee = await response.Content.ReadAsAsync<Employee>();

			Assert.Multiple(() =>
			{
				Assert.That(employee.EmployeeId, Is.EqualTo(id));
				Assert.That(employee.OrganisationNumber, Is.EqualTo("00014259"));
				Assert.That(employee.FirstName, Is.EqualTo("Test"));
				Assert.That(employee.LastName, Is.EqualTo("User"));
			});
		}
	}
}