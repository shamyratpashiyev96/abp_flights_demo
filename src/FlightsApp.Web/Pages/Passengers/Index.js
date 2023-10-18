$(function () {
    var l = abp.localization.getResource('FlightsApp');

    var dataTable = $('#PassengersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(flightsApp.passengers.passenger.getList),
            columnDefs: [
                {
                    title: l('FirstName'),
                    data: "firstName"
                },
                {
                    title: l('LastName'),
                    data: "lastName",
                    // render: function (data) {
                    //     return l('Enum:BookType.' + data);
                    // }
                },
                // {
                //     title: l('PublishDate'),
                //     data: "publishDate",
                //     render: function (data) {
                //         return luxon
                //             .DateTime
                //             .fromISO(data, {
                //                 locale: abp.localization.currentCulture.name
                //             }).toLocaleString();
                //     }
                // },
                // {
                //     title: l('Price'),
                //     data: "price"
                // },
                // {
                //     title: l('CreationTime'), data: "creationTime",
                //     render: function (data) {
                //         return luxon
                //             .DateTime
                //             .fromISO(data, {
                //                 locale: abp.localization.currentCulture.name
                //             }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                //     }
                // }
            ]
        })
    );
});