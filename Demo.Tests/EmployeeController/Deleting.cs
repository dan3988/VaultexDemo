using System.Net;

using Demo.Website.Controllers.Models;

namespace Demo.Tests.EmployeeController;

public static class Deleting
{
	[Test]
	public static async Task CanDeleteEmployees()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "John",
			LastName = "Doe"
		};

		int id;

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Employee", model))
			id = await response.Content.ReadAsAsync<int>();

		using (var response = await client.DeleteAsync($"/api/Employee/{id}"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.GetAsync($"/api/Employee/{id}"))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public static async Task ReturnsNotFoundWhenAttemptingToDeleteEmployeeThatDoesNotExist()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "John",
			LastName = "Doe"
		};

		using var client = Testing.GetClient();
		using var response = await client.DeleteAsync($"/api/Employee/{int.MaxValue}");

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}
}
