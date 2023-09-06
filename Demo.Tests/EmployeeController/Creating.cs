using System.Net;
using System.Net.Mime;

using Demo.Website.Controllers.Models;
using Demo.Website.Data.Entities;

using Newtonsoft.Json.Linq;

namespace Demo.Tests.EmployeeController;

public static class Creating
{
	[Test]
	public static async Task CanCreateEmployee()
	{
		var createModel = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "Test",
			LastName = "User"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Employee", createModel))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			var data = await response.Content.ReadAsAsync<JToken>();

			Assert.That(data.Type, Is.EqualTo(JTokenType.Integer));
		}
	}

	[Test]
	public static async Task CreatedEmployeeCanBeRetrievedById()
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
			id = await response.Content.ReadAsAsync<int>();

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
	public static async Task CreatedEmployeeIsReturnedInRetrieveAll()
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
			id = await response.Content.ReadAsAsync<int>();

		using (var response = await client.GetAsync($"/api/Employee"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			var employees = await response.Content.ReadAsAsync<Employee[]>();
			var employee = employees.FirstOrDefault(v => v.EmployeeId == id);

			Assert.That(employee, Is.Not.Null);
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
	public static async Task ValidatesMissingOrganisationNumberProperty()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = null!,
			FirstName = "John",
			LastName = "Doe"
		};

		using var client = Testing.GetClient();
		using var response = await client.PostAsJsonAsync("/api/Employee", model);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public static async Task ValidatesMissingFirstNameProperty()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = null!,
			LastName = "Doe"
		};

		using var client = Testing.GetClient();
		using var response = await client.PostAsJsonAsync("/api/Employee", model);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}

	[Test]
	public static async Task ValidatesMissingLastNameProperty()
	{
		var model = new EmployeeModel
		{
			OrganisationNumber = "00014259",
			FirstName = "John",
			LastName = null!
		};

		using var client = Testing.GetClient();
		using var response = await client.PostAsJsonAsync("/api/Employee", model);

		Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}
}
