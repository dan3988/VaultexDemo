using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;

using Demo.Website.Controllers.Models;
using Demo.Website.Data.Entities;

namespace Demo.Tests;

public static class EmployeeControllerTests
{
	[Test]
	public static async Task CanCreateEmployees()
	{
		var createModel = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "Test",
			LastName = "User"
		};

		int id;

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Employee", createModel))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			id = await response.Content.ReadAsAsync<int>();
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
				Assert.That(employee.FirstName, Is.EqualTo("Test"));
				Assert.That(employee.LastName, Is.EqualTo("User"));
			});
		}
	}

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

		using (var response = await client.DeleteAsync($"/api/Employee/{id}"))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}
}