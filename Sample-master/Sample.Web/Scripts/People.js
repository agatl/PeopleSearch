$(document).on('change keyup paste input', '#txtSearch', function (e) {
    e.preventDefault();
    $('#hdnSearch').val($('#txtSearch').val());
    var query = $('#txtSearch').val();
    var url = '/Home/GetPeopleSearch?q=' + query;
    $.ajax({
        url: url,
        type: 'GET',
        cache: false,
        success: function (result) {
            $('#divLoad').show();
            setTimeout(function () {
                $('#divPeople').html(result);
                $('#divLoad').hide();
            }, 200);
        }
    });
})
