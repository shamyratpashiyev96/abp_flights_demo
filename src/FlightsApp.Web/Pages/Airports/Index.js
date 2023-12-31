$(function () {
    var l = abp.localization.getResource('FlightsApp');

    var createModal = new abp.ModalManager(abp.appPath + "Airports/CreateModal");
    var editModal = new abp.ModalManager(abp.appPath + "Airports/EditModal");

    var dataTable = $('#AirportsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(flightsApp.airports.airport.getList),
            columnDefs: [
                {
                    title: l('City'),
                    data: "city"
                },
                {
                    title: l('Code'),
                    data: "code",
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
                {
                    title: l('Actions'),
                    rowAction: {
                        items:[
                            {
                                text: l('Update'),
                                visible: abp.auth.isGranted("FlightsApp.Airports.Update"),
                                action: function(data){
                                    editModal.open({id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted("FlightsApp.Airports.Delete"),
                                confirmMessage: function(data){
                                    return l('AirportDeletionConfirmationMessage', data.record.city, data.record.code);
                                },
                                action: function(data){
                                    flightsApp.airports.airport
                                    .delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted',data.record.city, data.record.code));
                                        dataTable.ajax.reload();
                                    });
                                }
                            }
                        ]
                    }
                },
            ]
        })
    );
    createModal.onResult(function (){
        dataTable.ajax.reload();
    });

    editModal.onResult(function (){
        dataTable.ajax.reload();
    });

    $('#NewAirportButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});