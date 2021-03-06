﻿$(function() {
    $(".Apply-Numeric").numericInput();

    $("#Save").click(function() {
        var url = $(this).attr("href");
        var caption = $("#Caption").val();
        var dictionaryCode = $("#DictionaryCode").val();
        var intCode = $("#IntCode").val();
        var stringCode = $("#StringCode").val();
        var sortVal = $("#SortVal").val();
        var isVisible = $("#IsVisible").is(":checked");


        $.ajax({
            type: "POST",
            url: url,
            data: {
                ParentID: parentID === 0 ? null : parentID,
                Caption: caption,
                DictionaryCode: dictionaryCode,
                IntCode: intCode,
                StringCode: stringCode,
                SortVal: sortVal,
                IsVisible: isVisible
            },
            dataType: "json",
            beforeSend: function () {
                AjaxLoader.ShowLoader();
            },
            success: function (response) {
                AjaxLoader.HideLoader();
                if (response.IsSuccess) {
                    window.parent.location.reload();
                } else {
                    bootbox.alert(response.Data.Message);
                }
            },
            error: function(response) {
                bootbox.alert(abort);
            }
        });

        return false;
    });
});