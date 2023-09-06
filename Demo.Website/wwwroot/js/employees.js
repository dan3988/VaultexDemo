/// <reference types="datatables.net" />

var table = $("table#master-table").DataTable({
	data: [],
	autoWidth: false,
	columns: [
		{
			name: "_id",
			data: "id",
			visible: false
		},
		{
			title: "First Name",
			data: "firstName"
		},
		{
			title: "Last Name",
			data: "lastName"
		},
		{
			title: "Organisation",
			data(row) {
				return row.organisation.organisationName;
			},
			createdCell(cell, cellData, rowData) {
				const a = document.createElement("a");
				a.innerText = cellData;
				a.href = "/Organisation/" + rowData.organisationNumber;

				cell.innerHTML = "";
				cell.appendChild(a);
			}
		}
	]
});

loadData();

async function loadData() {
	const organisations = await rest.get("/api/Organisation");
	const employees = await rest.get("/api/Employee");

	const orgMap = new Map();
	for (const org of organisations)
		orgMap.set(org.organisationNumber, org);

	const data = employees.map(({ employeeId: id, organisationNumber, firstName, lastName }) => {
		return {
			id,
			firstName,
			lastName,
			organisationNumber,
			organisation: orgMap.get(organisationNumber)
		}
	});

	table.rows.add(data).draw();
}