﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditorNavMenu.ascx.cs" Inherits="Editor.App.Controls.EditorNavMenu" %>
<div id="menuEditor" runat="server"><a onmouseup="(function(){(event.which==3) ? event.preventDefault() : window.open('/editor','_self');})();"><span class="uk-icon" uk-icon="user"></span>Create New Document</a></div>