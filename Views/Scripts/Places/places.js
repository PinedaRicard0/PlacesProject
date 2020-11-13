$(document).ready(function () {
    let error = $('#isError').val();
    if (error == 'True') {
        $('#createRegionModal').modal('show');
    }
});

function onCloseCreateModal() {
    window.location.href = $('#labelIndex').text();
    //$('#inpName').val("");
    //$('#inpCode').val("");
    //$(".text-danger").each(function () {
    //    $(this).html("");
    //});
};