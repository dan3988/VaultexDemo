using Demo.Website.Controllers.Models;
using Demo.Website.Data.Entities;
using System.Net.Mime;
using System.Net;

namespace Demo.Tests.EmployeeController;

public static class Updating
{
	[Test]
	public static async Task CanUpdateEmployees()
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

		model.LastName = "Smith";

		using (var response = await client.PutAsJsonAsync($"/api/Employee/{id}", model))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.GetAsync($"/api/Employee/{id}"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			var employee = await response.Content.ReadAsAsync<Employee>();

			Assert.Multiple(() =>
			{
				Assert.That(employee.EmployeeId, Is.EqualTo(id));
				Assert.That(employee.OrganisationNumber, Is.EqualTo("00014259"));
				Assert.That(employee.FirstName, Is.EqualTo("John"));
				Assert.That(employee.LastName, Is.EqualTo("Smith"));
			});
		}
	}

	[Test]
	public static async Task ReturnsNotFoundWhenAttemptingToUpdateEmployeeThatDoesNotExist()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "John",
			LastName = "Doe"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PutAsJsonAsync($"/api/Employee/{int.MaxValue}", model))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public static async Task ValidatesMissingOrganisationNumberProperty()
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

		model.OrganisationNumber = null!;

		using (var response = await client.PutAsJsonAsync($"/api/Employee/{id}", model))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public static async Task ValidatesMissingFirstNameProperty()
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

		model.FirstName = null!;

		using (var response = await client.PutAsJsonAsync($"/api/Employee/{id}", model))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public static async Task ValidatesMissingLastNameProperty()
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

		model.LastName = null!;

		using (var response = await client.PutAsJsonAsync($"/api/Employee/{id}", model))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}
}
