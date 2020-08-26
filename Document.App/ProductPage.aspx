<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Document.App.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./Js/uikit/uikit.theme.css" rel="stylesheet" />
    <link href="./Js/jquery/chosen.css" rel="stylesheet" />
    <script src="./Js/uikit/uikit.js"></script>
    <script src="./Js/jquery/jquery-3.4.1.min.js"></script>
    <script src="./Js/jquery/chosen.jquery.js"></script>
    <script src="./Js/uikit/uikit-icons.js"></script>
    <script src="./Js/Editor.js"></script>
    <script src="./Js/page/Page.Product.js"></script>
    <script src="./Js/Class/M.Product.js"></script>
    <script src="./Js/modal/M.Modal.Cart.js"></script>
    <!-- #include file="/Controls/CartModal.html"  -->
</head>
<body>
    <input id="meObject" runat="server" type="hidden" />
<nav class="uk-navbar uk-height-1-5">
    <div class="uk-padding-bottom">
        <div class="uk-navbar-left">
            <h2 class="uk-position-left uk-text-primary">Garment Shop</h2>
            <h2 class="uk-position-left uk-text-secondary">Visit for trendy garments</h2>
            <span id="cartToolTip" class="uk-margin-right uk-margin uk-text-center uk-cursor-pointer uk-position-bottom-right" uk-tooltip="Open Cart" title="" aria-expanded="false">
                <button id="cartButton" class="uk-button uk-button-mini uk-icon-button">
                    <div id="cartValue" class="uk-position-top uk-text-danger uk-text-bolder uk-h6"></div>
                    <span class="uk-icon" uk-icon="cart"></span>
                </button>
            </span>
        </div>
    </div>
</nav>

    <div class="uk-height-4-5 uk-padding-small uk-background-default uk-overflow-auto">
        <div class="uk-margin-auto uk-width-1-1 uk-padding-bottom uk-height-1-1">
            <div class="uk-flex uk-flex-wrap uk-width-1-1">
                <div class="uk-width-1-4@s uk-background-default uk-position-relative"> 
                    <div height="200"><img id="imageCard" class="uk-padding-small-right" data-src="" uk-img></div>
                    <div class="uk-flex uk-flex-wrap uk-width-1-1">
                        <div class="uk-width-4-5"><h2 id="productPrice" class="uk-text-bolder uk-text-secondary uk-margin-remove">Price</h2></div>
                        <div id="productSize" class="uk-padding-right uk-width-1-5 uk-margin-small uk-text-danger uk-text-bolder"></div>
                    </div>

                </div>
                <div class=" uk-padding-left uk-width-3-4@s uk-background-muted">
                    <div id="productName" class="uk-flex uk-flex-wrap uk-width-1-1 uk-text-bolder uk-h2">
                        Name
                    </div>
                    <div class="uk-flex uk-flex-wrap uk-width-1-1">
                        <div id="divSize" class="uk-width-1-3@s uk-flex">
                            <label class="uk-width-1-5 uk-form-label">Color</label>
                            <div class="uk-width-4-5 uk-margin-small-left">
                                <select id="colorDropDownList" data-placeholder="Select Color" class="chosen-select"></select>
                            </div>
                        </div>
                    </div>
                    <div class="uk-margin uk-flex uk-flex-wrap uk-width-1-1">
                        <div id="divColor" class=" uk-width-1-3@s uk-flex">
                            <label class="uk-width-1-5 uk-form-label">Size</label>
                            <div class="uk-width-4-5 uk-margin-small-left">
                                <select id="sizeDropDownList" data-placeholder="Select Size" class="chosen-select"></select>
                            </div>
                        </div>
                    </div>
                    <div class="uk-margin uk-width-1-1 uk-flex uk-flex-wrap">
                        <div class="uk-flex uk-width-1-3@s">
                            <a class="uk-button uk-button-secondary" id="buttonAddToCart">Add To Cart</a>
                        </div>
                        <div class="uk-flex uk-width-1-3@s">
                            <button id="buttonRemoveFromCart" class="uk-button uk-button-secondary uk-margin-right" disabled="">Remove From Cart</button>
                        </div>
                        <div class="uk-flex uk-width-1-3@s">
                            <a class="uk-button uk-button-primary" id="nextProduct">Next>></a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</body>
</html>
