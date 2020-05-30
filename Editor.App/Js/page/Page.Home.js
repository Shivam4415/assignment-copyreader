

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

    var _initControls = function () {
        $(".uk-navbar").find(".uk-card").off().on('click', _createNewEditor);
    };

    var _showNotification = function (response) {
        UIkit.notification({
            message: response.responseJSON.Error.Message || 'Try again later.',
            status: 'danger',
            timeout: M._notifyDuration,
            pos: 'top-center'
        });
    };

    var _createTableData = function (data) {

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
        _createTableData(data);

    };


    var _createNewEditor = function (event) {
        event.preventDefault();
        event.stopImmediatePropagation();

        $.ajax({
            url: '/api/v1/editor',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                if (data) {
                    if (data.Id)
                        window.open("editor/" + data.Id + "/", "_self");
                }
                //d.resolve(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                UIkit.notification({
                    message: xhr.responseJSON.Error.Message,
                    status: 'danger',
                    timeout: M._notifyDurationMedium,
                    pos: 'top-center'
                });
                //d.reject(xhr.responseJSON, errorThrown, textStatus);
            }
        });

    };


    //var _open = function (event, row) {
    //    if (row === undefined)
    //        return;

    //    if (row.length != 1)
    //        return;

    //    var dataContext = grid.getDataItem(row)

    //    if (dataContext === undefined)
    //        return;

    //    var url = "/data-set/";
    //    if (dataContext.Object == M.ObjectType.Map) {
    //        url = "/map/";
    //        M.goToMap(event, url + dataContext.Id);
    //    }
    //    else if (dataContext.Object == M.ObjectType.View) {
    //        url = "/view/";
    //        window.open(url + dataContext.Id, ((event && event.ctrlKey) ? "_blank" : "_self"));
    //    }
    //    else if (dataContext.Object == M.ObjectType.Report) {
    //        url = "/report/";
    //        window.open(url + dataContext.Id, ((event && event.ctrlKey) ? "_blank" : "_self"));
    //    }
    //    else if (dataContext.Object == M.ObjectType.Chart) {
    //        url = "/chart/";
    //        window.open(url + dataContext.Id, ((event && event.ctrlKey) ? "_blank" : "_self"));
    //    }
    //    else
    //        window.open(url + dataContext.Id, ((event && event.ctrlKey) ? "_blank" : "_self"));

    //};


    var _getAll = function () {
        return $.ajax({
            url: '/api/v1/editor',
            type: 'GET',
            contentType: 'application/json',
            datatype: 'json',
            success: _getAllHandler,
            failure: _showNotification
        });
    };
   
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
        }).done(function () { M.RealtimeNotificationConsumer.destroy(); });
    };


    return {
        Start: start,
        Create: _createNewEditor,
        Init: _initEditor
    };
};

window.onload = function () {

    var url = window.location.toString();
    Home.Start();

}