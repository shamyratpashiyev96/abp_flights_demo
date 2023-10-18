$(function () {
    var l = abp.localization.getResource('FlightsApp');

    var createModal = new abp.ModalManager(abp.appPath + "Passengers/CreateModal");
    var editModal = new abp.ModalManager(abp.appPath + "Passengers/EditModal");

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
                {
                    title: l('Actions'),
                    rowAction: {
                        items:[
                            {
                                text: l('Update'),
                                action: function(data){
                                    editModal.open({id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function(data){
                                    return l('PassengerDeletionConfirmationMessage', data.record.firstName, data.record.lastName);
                                },
                                action: function(data){
                                    flightsApp.passengers.passenger
                                    .delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted',data.record.firstName, data.record.lastName));
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

    $('#NewPassengerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});