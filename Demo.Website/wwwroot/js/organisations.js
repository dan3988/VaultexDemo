/// <reference types="datatables.net" />

var table = $("table#master-table")
	.on("click", "tbody tr", function () {
		const row = table.row(this).data();
		if (row)
			location = `/Organisation/${row.organisationNumber}`;
	})
	.DataTable({
	data: [],
	autoWidth: false,
	createdRow(row) {
		row.role = "button";
	},
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