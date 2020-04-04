<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditorPage.aspx.cs" Inherits="Editor.App.EditorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./Js/uikit/uikit.theme.css" rel="stylesheet" />
    <script src="./Js/uikit/uikit.js"></script>
    <script src="./Js/jquery/jquery-3.4.1.min.js"></script>
    <script src="./Js/uikit/uikit-icons.js"></script>

    <!-- Include Quill stylesheet -->
    <link href="https://cdn.quilljs.com/1.0.0/quill.snow.css" rel="stylesheet"/>

    <!-- Include the Quill library -->
    <script src="https://cdn.quilljs.com/1.0.0/quill.js"></script>

    <script src="./Js/page/Page.Editor.js"></script>



</head>
<body>


<nav class="uk-height-1-5 uk-background-default">
     <div id="name" class="uk-flex">
         <div class="uk-width-1-5 uk-padding-top uk-padding-small-left">
            <input name="editorName" type="text" class="uk-input uk-h3" style = "height:50px ; border:0; padding-left:1px"/>
        </div>

        <div class="uk-width-4-5">
            <div class="uk-flex uk-position-top-right uk-padding">
                <div id="present">
                    <button id="btnPresent" class="uk-button uk-width-small uk-button-secondary uk-margin-right" name="SignUp">Present</button>
                </div>

                <div id="share">
                    <button id="btnShare" class="uk-button uk-width-small uk-button-primary" name="SignUp">Share</button>
                </div>
            </div>
        </div>
    </div>
    

</nav>

<div class="uk-height-4-5">
    <div class="uk-margin-auto uk-width-3-4 uk-padding-bottom uk-height-1-1">
        <div id="editorContainer" class="uk-editor-height uk-background-default"></div>
    </div>
</div>




</body>
</html>


