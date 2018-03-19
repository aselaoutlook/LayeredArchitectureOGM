/*
This function will fixed the WebGrid Style issue (unwrapped pager link style issue)
*/
function gridPagerStyleFixer() {
    var currentPage = $(".gridFooter td").contents().filter(function () {
        if (this.nodeType === 3) {
            return $.trim(this.textContent) !== "";
        }
        return false;
    }).get(0);

    $(currentPage).wrap('<span class="current" />');
    $(".gridFooter .current").text($.trim($(".gridFooter .current").text()));
}

//Load OpenBusinessUnitModel model
function OpenEditBusinessUnitModel(businessUnitId, name, description, isActive) {
    $('#txtEditBusinessUnitName').val(name);
    $('#txtEditBusinessUnitDetails').val(description);
    //$('#ddlEditSector').val(sectorId).attr("selected", "selected");
    $('#hdnBusinessUnitID').val(businessUnitId);

    if (isActive == "true") {
        $("#chkIsActive").prop("checked", true);
    }
    else {
        $("#chkIsActive").prop("checked", false);
    }

    document.getElementById("update").className = "btn btn-default btn-modal-footer";
    document.getElementById("update").disabled = false;
    $("#errorupdate").css('display', 'none');
    $("#successupdate").css('display', 'none');
    $('#EditBusinessUnitModel').modal('show');

    return false;
}