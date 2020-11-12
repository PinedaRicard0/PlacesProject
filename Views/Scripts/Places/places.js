function onBtnClick() {
    $.ajax({
        type: 'GET',
        url: $('#actNewRegion').text(),
        cache: false,
        success: function (res) {
            $('#createRegionDiv').html(res);
            $('#createRegionModal').modal('show');
        }
    })
}