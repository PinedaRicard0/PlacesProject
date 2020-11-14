$(document).ready(function () {
    $('#inpCode').val("");
    let error = $('#isError').val();
    let editing = $('#isEditing').val();
    //An error when creating a region
    if (error == 'True' && editing == 'False') {
        $('#createRegionModal').modal('show');
    }
    //An error when editing
    if (error == 'True' && editing == 'True') {
        $('#editRegionModal').modal('show');
    }
    //Editing a region
    if (error == 'False' && editing == 'True') {
        $('#editRegionModal').modal('show');
    }
});


//functions related to regions action

function onCloseCreateModal() {
    if (window.location.href.includes('CreateRegion')) {
        window.location.href = $('#labelIndex').text();
    }
    else {
        $('#inpName').val("");
        $('#inpCode').val("");
        $(".text-danger").each(function () {
            $(this).html("");
        });
    }
};

function onCloseEditModal() {
    if (window.location.href.includes('EditRegion')) {
        window.location.href = $('#labelIndex').text();
    }
};

function onDeleteBtn(regionId, regionName) {
    $('#toDeleteRegion').val(regionId);
    $('#msgDeleteRegion').html(`¿Realmente quiere eliminar la región <b>${regionName}</b>? `);
    $('#deleteRegionModal').modal('show');
}

function onConfirmRegionDelete(){
    let url = $('#labelDelete').text();
    let id = $('#toDeleteRegion').val();
    url = `${url}?regionId=${id}`;
    window.location.href = url;
}

function onCloseDeleteModal() {
    $('#toDeleteRegion').val("");
}

//functions related with municipalities action