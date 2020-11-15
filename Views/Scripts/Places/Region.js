$(document).ready(function () {
    let error = $('#isError').val();
    let editing = $('#isEditing').val();
    if (error == 'False') {
        $('#inpCode').val("");
    }
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

function onAddMunicipality(regionId, regionName) {
    $.ajax({
        method: 'GET',
        url: $('#addMunicipalities').text(),
        data: { regionId: regionId , regionName: regionName},
        success: function (res) {
            $('#addMunicipalitiesContainer').html(res);
            $('#addMunicipalityModal').modal('show');
            
        }
    });
}

function onDeleteRegMunBtn(regionName, municipalityId, municipalityName ) {
    $('#toDeleteMunicipality').val(municipalityId);
    $('#msgDeleteRegMun').html(`¿Realmente quieres retirar el municipio <b>${municipalityName}</b> de la región <b>${regionName}</b>? `);
    $('#deleteRegMunModal').modal('show');
}

function onConfirmRegMunDelete(regionId) {
    debugger;
    let url = $('#deleteRegMun').text();
    let idMunicipality = $('#toDeleteMunicipality').val();
    url = `${url}?regionId=${regionId}&&municipalityId=${idMunicipality}`;
    window.location.href = url;
}

function onCloseDeleteRegMunModal() {
    $('#toDeleteMunicipality').val("");
};