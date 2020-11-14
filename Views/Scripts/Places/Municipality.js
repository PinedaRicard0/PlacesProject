$(document).ready(function () {
    let error = $('#isError').val();
    let editing = $('#isEditing').val();
    if (error == 'False') {
        $('#inpCode').val("");
    }
    //An error when creating a municipality
    if (error == 'True' && editing == 'False') {
        $('#createMunicipalityModal').modal('show');
    }
    //An error when editing
    if (error == 'True' && editing == 'True') {
        $('#editMunicipalityModal').modal('show');
    }
    //Editing a municipality
    if (error == 'False' && editing == 'True') {
        $('#editMunicipalityModal').modal('show');
    }
});

function onCloseCreateModal() {
    if (window.location.href.includes('CreateMunicipality')) {
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

function onDeleteBtn(municipalityId, municipalityName) {
    $('#toDeleteMunicipality').val(municipalityId);
    $('#msgDeleteMunicipality').html(`¿Realmente quiere eliminar el municipio <b>${municipalityName}</b>? `);
    $('#deleteMunicipalityModal').modal('show');
}

function onConfirmMunicipalityDelete() {
    let url = $('#labelDelete').text();
    let id = $('#toDeleteMunicipality').val();
    url = `${url}?municipalityId=${id}`;
    window.location.href = url;
}

function onCloseDeleteModal() {
    $('#toDeleteMunicipality').val("");
}

function onCloseEditModal() {
    if (window.location.href.includes('EditMunicipality')) {
        window.location.href = $('#labelIndex').text();
    }
};