

Editor = new function () {

    var
        toolbar = "#toolbar",
        editorContainer = "#editorContainer";

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

        _saveEditorData();


    };

    var _setAutoSaveTimer = function () {


    };

    var _saveEditorData = function () {
        var contents = _quill.getContents();
        setInterval(function () {
            if (_change.length() > 0) {
                console.log('Contents = ', contents);
                console.log('changes', _change);

                _update(_change.ops);
                _change = new Delta();
            }
        }, 5 * 1000);

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


    return {
        Start: start,
        Init: _initEditor
    };
};

window.onload = function () {

    var url = window.location.toString();
    Editor.Start();

};