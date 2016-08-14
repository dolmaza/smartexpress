﻿$(function() {

    $("#From, #To").datepicker();

    // prepare the data
    var source =
    {
        dataType: "json",
        dataFields: [
            { name: "ID", type: "number" },
            { name: "ParentID", type: "number" },
            { name: "InvoiceNumber", type: "string" },
            { name: "CompanyName", type: "string" },
            { name: "SenderAddress", type: "string" },
            { name: "ReceiveDate", type: "string" },
            { name: "MessageMode", type: "string" },
            { name: "Quantity", type: "number" },
            { name: "Weigth", type: "number" },
            { name: "UnitPrice", type: "number" },
            { name: "Direction", type: "string" },
            { name: "ReceiverFirstnameLastname", type: "string" },
            { name: "ReceiverTelephoneNumber", type: "string" },
            { name: "ReceiverAddress", type: "string" }

        ],
        hierarchy:
        {
            keyDataField: { name: 'ID' },
            parentDataField: { name: 'ParentID' }
        },
        id: 'ID',
        localData: InvoicesJson


    };
    var dataAdapter = new $.jqx.dataAdapter(source);
    // create Tree Grid
    $("#treeGrid").jqxTreeGrid(
    {
        width: "100%",
        source: dataAdapter,
        sortable: true,
        pageable: false,
        pagerMode: 'advanced',
        ready: function () {
            $("#treeGrid").jqxTreeGrid('expandRow', '2');
        },

        columns: [

            
            { text: "ზედნ. №", dataField: "InvoiceNumber", width: 90 },
            {
                text: "<i class='fa fa-cog'></i>", width: 100, cellsAlign: 'center', align: "center", columnType: 'none', editable: false, sortable: false, dataField: "ParentID", cellsRenderer: function (id, column, parentID) {
                    // render custom column.
                    return "<a href='/admin/invoices/" + id + "/edit/' class='invoice-edit'><i class='fa fa-pencil'></i></a> <a href='/admin/invoices/" + id + "/create' class='invoice-create'><i class='fa fa-plus'></i></a> <a href='/admin/invoices/" + id + "/delete' class='invoice-delete'><i class='fa fa-trash-o'></i></a>";
                }
            },
            { text: "კომპანია", dataField: "CompanyName", width: 100 },
            { text: "მისამართი", dataField: "SenderAddress", width: 100 },
            { text: "მიღ. თარიღი", dataField: "ReceiveDate", width: 100 },
            { text: "რეჟიმი", dataField: "MessageMode", width: 100 },
            { text: "რაოდენობა", dataField: "Quantity", width: 80 },
            { text: "წონა", dataField: "Weigth", width: 60 },
            { text: "ერთ. ფასი", dataField: "UnitPrice", width: 100 },
            { text: "მიმართულება", dataField: "Direction", width: 100 },
            { text: "მიმღ. სახ. გვარი", dataField: "ReceiverFirstnameLastname", width: 150 },
            { text: "მიმღ. ტელ.", dataField: "ReceiverTelephoneNumber", width: 120 },
            { text: "მიმღ. მისამართი", dataField: "ReceiverAddress", width: 120 }
            

        ]

    });

    $("#treeGrid").on("click", ".invoice-delete", function() {
        return confirm(confirmDeleteText);
    })

});