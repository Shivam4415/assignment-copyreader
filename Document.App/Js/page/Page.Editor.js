

Editor = new function () {

    const
        toolbar = "#toolbar",
        editorContainer = "#editorContainer",
        btnShare = "#btnShare" ;

    var _change,
        _quill;


    var toolbarOptions = [
        ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
        ['blockquote', 'code-block'],

        [{ 'header': 1 }, { 'header': 2 }],               // custom button values
        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
        [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
        [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
        [{ 'direction': 'rtl' }],                         // text direction

        [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

        [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
        [{ 'font': [] }],
        [{ 'align': [] }],

        ['clean']                                         // remove formatting button
    ];


    var start = function () {
        _initEditor();
        _initControls();
    };

    var _initEditor = function () {
        Delta = Quill.import('delta');

        _quill = new Quill(editorContainer, {
            modules: {
                toolbar: toolbarOptions
            },
            theme: 'snow'
        });

        _change = new Delta();

        _quill.on('text-change', function (Delta) {
            _change = _change.compose(Delta);
        });

        $(btnShare).on('click', _loadDataOnEditor);

        _saveEditorData();

        _getData();


    };

    var _setAutoSaveTimer = function () {


    };

    var _loadDataOnEditor = function (response) {
        if (response === undefined || response === "") {
            _quill.setContents([
                { insert: 'Hello ' },
                { insert: 'World!', attributes: { bold: true } },
                { insert: '\n' }
            ]);
        }
        else {
            _quill.setContents(response);
        }

    };

    var _saveEditorData = function () {
        var contents = _quill.getContents();
        setInterval(function () {
            if (_change.length() > 0) {
                console.log('Contents = ', contents);
                console.log('changes', _change);

                _update(_change.ops);
                var _rData = new ReaderData();
                _rData.getdata();
                _change = new Delta();
            }
        }, 10 * 1000);

    };


    var _onAddHandler = function () {

        console.log("updated");
    };



    var _initControls = function () {

    };

    var _showNotification = function (response) {
        UIkit.notification({
            message: response.responseJSON.Message || 'Try again later.',
            status: 'danger',
            timeout: '3000',
            pos: 'top-center'
        });
    };


    var _update = function (data) {
        return $.ajax({
            url: '/api/v1/editor/' + editorId.value,
            type: 'POST',
            data: JSON.stringify(data),
            success: _onAddHandler,
            error: _showNotification,
            contentType: 'application/json',
            dataType: 'json'
        });

    };

    var _getData = function () {
        return $.ajax({
            url: '/api/v1/editor/' + editorId.value,
            type: 'GET',
            contentType: 'application/json',
            datatype: 'json',
            success: function (data, textStatus, xhr) {
                _loadDataOnEditor(data);
                },
            failure: _showNotification
        });
    };

    return {
        Start: start,
        Init: _initEditor
    };
};

window.onload = function () {

    var url = window.location.toString();
    Editor.Start();

};