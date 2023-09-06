﻿/// <reference types="datatables.net" />

var table = $("table#master-table").DataTable({
	data: [],
	columns: [
		{
			title: "Organisation Number",
			data: "organisationNumber",
			width: "12rem",
		},
		{
			title: "Organisation Name",
			data: "organisationName",
		},
		{
			title: "Town",
			data: "town"
		},
		{
			title: "Postcode",
			data: "postcode"
		}
	]
});

loadData();

async function loadData() {
	const data = await rest.get("/api/Organisation");
	table.rows.add(data).draw();
}