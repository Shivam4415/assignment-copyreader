

Home = new function () {

    var _tableData;

    var tableBody = "#tableBody";

    var start = function () {
        _getAll();
        _initEditor();
        _initControls();
    };

    var _initEditor = function () {


    };

    var createNewEditor = function () {
        var button = $(this).find('button.uk-icon').attr("uk-icon");
        if (button === "plus") {
            var x = 0;
        }
    };

    var _initControls = function () {
        $(".uk-navbar").find(".uk-card").on('click', createNewEditor);
    };

    var _showNotification = function (response) {
        //$apiKeySpinner.attr('hidden', '');Hide the spinner
        UIkit.notification({
            message: response.responseJSON.Error.Message || 'Try again later.',
            status: 'danger',
            timeout: M._notifyDuration,
            pos: 'top-center'
        });
    };

    var _createTableData = function () {

        var html = '<tr>\
                    <td>{0}</td>\
                    <td>{1}</td>\
                    <td>{2}</td>\
                    <td>{3}</td>\
                    </tr >';
        data.forEach(function (d) {
            $.validator.format(html, [d.Name, d.CreatedBy, d.Type, d.CreatedDate]);
            $(tableBody).append(html);
        });
    };

    var _getAllHandler = function (data) {
        _tabledata = data;
    };

    var _getAll = function () {
        return $.ajax({
            url: '/api/v1/editor',
            type: 'GET',
            success: _getAllHandler,
            failure: _showNotification,
            datatype: 'json' //type of data return from server.
        });
    }
   
    var _add = function (key) {
        return $.ajax({
            url: '/api/v1/editor',
            type: 'POST',
            data: JSON.stringify({
                Name: key
            }),
            success: _onAddHandler,
            error: _showNotification,
            contentType: 'application/json',
            dataType: 'json'
        }).done(function () { M.RealtimeNotificationConsumer.destroy() });
    }


    return {
        Start: start,
        Init: _initEditor
    };
};

window.onload = function () {

    var url = window.location.toString();
    Home.Start();

}