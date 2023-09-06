using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;

using Demo.Website.Controllers.Models;
using Demo.Website.Data.Entities;

namespace Demo.Tests;

public static class OrganisationControllerTests
{
	[Test]
	public static async Task CanCreateOrganisations()
	{
		var model = new OrganisationModel
		{
			OrganisationName = "Test Organisation",
			OrganisationNumber = "CanCreateOrganisations_ID",
			AddressLine1 = "Address Line 1",
			AddressLine2 = "Address Line 2",
			Town = "London",
			Postcode = "SW1A 0AA"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Organisation", model))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.GetAsync("/api/Organisation/CanCreateOrganisations_ID"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			var employee = await response.Content.ReadAsAsync<Organisation>();

			Assert.That(employee, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(employee.OrganisationName, Is.EqualTo("Test Organisation"));
				Assert.That(employee.OrganisationNumber, Is.EqualTo("CanCreateOrganisations_ID"));
				Assert.That(employee.AddressLine1, Is.EqualTo("Address Line 1"));
				Assert.That(employee.AddressLine2, Is.EqualTo("Address Line 2"));
				Assert.That(employee.AddressLine3, Is.Null);
				Assert.That(employee.Town, Is.EqualTo("London"));
				Assert.That(employee.Postcode, Is.EqualTo("SW1A 0AA"));
			});
		}
	}

	[Test]
	public static async Task CanUpdateOrganisations()
	{
		var model = new OrganisationModel
		{
			OrganisationName = "Test Organisation",
			OrganisationNumber = "CanUpdateOrganisations_ID",
			AddressLine1 = "Address Line 1",
			AddressLine2 = "Address Line 2",
			Town = "London",
			Postcode = "SW1A 0AA"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Organisation", model))
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		model.OrganisationName = "New Organisation Name";

		using (var response = await client.PutAsJsonAsync("/api/Organisation", model))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.GetAsync("/api/Organisation/CanUpdateOrganisations_ID"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Not.Null);
				Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(MediaTypeNames.Application.Json));
			});

			var employee = await response.Content.ReadAsAsync<Organisation>();

			Assert.Multiple(() =>
			{
				Assert.That(employee.OrganisationName, Is.EqualTo("New Organisation Name"));
				Assert.That(employee.OrganisationNumber, Is.EqualTo("CanUpdateOrganisations_ID"));
				Assert.That(employee.AddressLine1, Is.EqualTo("Address Line 1"));
				Assert.That(employee.AddressLine2, Is.EqualTo("Address Line 2"));
				Assert.That(employee.AddressLine3, Is.Null);
				Assert.That(employee.Town, Is.EqualTo("London"));
				Assert.That(employee.Postcode, Is.EqualTo("SW1A 0AA"));
			});
		}
	}

	[Test]
	public static async Task CanDeleteOrganisations()
	{
		var model = new OrganisationModel
		{
			OrganisationName = "Test Organisation",
			OrganisationNumber = "CanDeleteOrganisations_ID",
			AddressLine1 = "Address Line 1",
			AddressLine2 = "Address Line 2",
			Town = "London",
			Postcode = "SW1A 0AA"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Organisation", model))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.DeleteAsync("/api/Organisation/CanDeleteOrganisations_ID"))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.DeleteAsync("/api/Organisation/CanDeleteOrganisations_ID"))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
	}

	[Test]
	public static async Task CannotUseDuplicateOrganisationId()
	{
		var model = new OrganisationModel
		{
			OrganisationName = "Test Organisation",
			OrganisationNumber = "CannotUseDuplicateOrganisationId_ID",
			AddressLine1 = "Address Line 1",
			AddressLine2 = "Address Line 2",
			Town = "London",
			Postcode = "SW1A 0AA"
		};

		using var client = Testing.GetClient();

		using (var response = await client.PostAsJsonAsync("/api/Organisation", model))
		{
			Assert.Multiple(() =>
			{
				Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
				Assert.That(response.Content.Headers.ContentType, Is.Null);
				Assert.That(response.Content.Headers.ContentLength, Is.EqualTo(0));
			});
		}

		using (var response = await client.PostAsJsonAsync("/api/Organisation", model))
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
	}
}