<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Editor.App.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="./Js/uikit/uikit.theme.css" rel="stylesheet" />
    <script src="./Js/uikit/uikit.js"></script>
    <script src="./Js/jquery/jquery-3.4.1.min.js"></script>
    <script src="./Js/uikit/uikit-icons.js"></script>
    <script src="./Js/modal/Modal.Registration.js"></script>
    <!-- #include file="~/Controls/UserRegistration.html" -->

</head>
<body class="uk-height-1-1">
    <div class="uk-flex uk-height-1-1 uk-flex-middle uk-text-center uk-overflow-auto">
        <div id="container" class="uk-container">
        <div class="uk-card uk-card-default uk-width-large@s uk-padding uk-background-muted">
            <form method="post" id="loginForm" autopostback="false" runat="server" class="uk-form uk-padding-small uk-margin-small-top uk-padding-remove-vertical">
                <fieldset class="uk-fieldset uk-padding-small uk-padding-remove-vertical">
                    <div id="MessageBox" class="uk-margin-remove-bottom" runat="server" ></div>

                    <div class="uk-padding-remove-left uk-margin-small-buttom">
                        <div class="uk-text-left">Email:</div>
                        <div>
                            <input name="txtEmail" type="text" id="txtEmail" aria-label="Email" runat="server" class="uk-input uk-form-danger" onkeypress=""/>
                        </div>
                    </div>

                    <div class="uk-padding-remove-left uk-margin-small">
                        <div class="uk-text-left">Password:</div>
                        <div>
                            <input name="txtPassword" type="password" id="txtPassword" runat="server" aria-label="Passwod" maxlength="50" class="uk-input" onkeypress=""/>
                        </div>
                    </div>

                    <div class="uk-flex uk-flex-between">
                        <asp:Button ID="btnSignIn" class="uk-button uk-button-primary uk-width-1-1@l" name="SignIn" runat="server" Text="LogIn" OnClick="btnLogin" />
                    </div>
                </fieldset>
            </form>
            <div class="uk-padding">
                <button id="btnSignUp" class="uk-button uk-button-secondary uk-width-1-1@l" name="SignUp" >SignUp</button>
            </div>

        </div>

        </div>
    </div>
</body>
</html>
