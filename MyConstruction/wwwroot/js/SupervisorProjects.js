var ProjectTable;

$(document).ready(function () {
    ProjectTable = $("#projectTable").DataTable({

        "ajax": {
            "url": "/getProjects"
        },

        "columns": [
            { "data": "name" },
            { "data": "address" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a class="btn btn-primary" href="/Supervisor/Projects/SiteUpdate/${data}">Add Update</a>
                    `
                }

            }
        ]




    });
});