

Editor = new function () {

    var
        toolbar = "#toolbar",
        editorContainer = "#editorContainer";

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

        var quill = new Quill(editorContainer, {
            modules: {
                toolbar: toolbarOptions
            },
            theme: 'snow'
        });


    };

    var _initControls = function () {

    };


    return {
        Start: start,
        Init: _initEditor
    };
};

window.onload = function () {

    var url = window.location.toString();
    Editor.Start();

}