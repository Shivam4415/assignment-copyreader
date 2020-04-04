﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Editor.App.Document" %>

<%@ Register Src="~/Controls/EditorNavMenu.ascx" TagPrefix="uc1" TagName="EditorNavMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="./Js/uikit/uikit.theme.css" rel="stylesheet" />
    <script src="./Js/uikit/uikit.js"></script>
    <script src="./Js/jquery/jquery-3.4.1.min.js"></script>
    <script src="./Js/uikit/uikit-icons.js"></script>
<%--    <script src="./Js/page/Page.Home.js"></script>--%>
</head>
<body>
<nav class="uk-navbar uk-height-1-3 uk-background-default">
    <div class="uk-padding-bottom">
        <div class="uk-navbar-left">
            <div class="uk-flex uk-flex-between uk-card uk-card-default uk-card-body uk-margin-top">
                <uc1:EditorNavMenu runat="server" id="EditorNavMenu" />
            </div>
        </div>
    </div>
</nav>

<div class="uk-height-2-3 uk-overflow-auto">
    <div class="uk-margin-auto uk-width-1-1 uk-padding-bottom uk-height-1-1">
        <div id="documents"></div>
        <table class="uk-table uk-table-hover uk-table-divider uk-overflow-auto">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Created By</th>
                    <th>Type</th>
                    <th>Created Date</th>
                </tr>
            </thead>
            <tbody id="tableBody">
                <tr>
                    <td>Table Data</td>
                    <td>Table Data</td>
                    <td>Table Data</td>
                    <td>Table Data</td>
                </tr>
            </tbody>
    </table>
    </div>
</div>
</body>
</html>
