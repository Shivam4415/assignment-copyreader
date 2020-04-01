<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditorPage.aspx.cs" Inherits="Editor.App.EditorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./Js/uikit/uikit.theme.css" rel="stylesheet" />
    <script src="./Js/uikit/uikit.js"></script>
    <script src="./Js/jquery/jquery-3.4.1.min.js"></script>
    <script src="./Js/uikit/uikit-icons.js"></script>
</head>
<body>
<nav class="uk-navbar uk-height-1-5 uk-background-default">
    <div class="uk-padding-bottom">
        <div class="uk-navbar-left">
            <ul class="uk-navbar-nav">
                <li class="uk-active"><a href="#">Active</a></li>
                <li>
                    <a href="#">Parent</a>
                    <div class="uk-navbar-dropdown">
                    </div>
                </li>
                <li><a href="#">Item</a></li>
            </ul>
        </div>
    </div>
</nav>

<div class="uk-height-4-5">
    <div class="uk-margin-auto uk-width-3-4 uk-padding-bottom uk-height-1-1">
        <fieldset class="uk-fieldset uk-height-1-1">
            <div class="uk-height-1-1">
                <textarea class="uk-height-1-1 uk-textarea uk-resize-none uk-background-default uk-overflow-hidden"></textarea>
            </div>
        </fieldset>
    </div>
</div>

</body>
</html>
