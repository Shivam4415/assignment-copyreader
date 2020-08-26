﻿//IIFE
M.Page.Product = (function () {

    var $colorDropDownList;
    var $colorDropdown;

    var $sizeDropDownList;
    var $sizeDropDown;

    var $cartValue;
    var $productPrice;
    var $productSize;
    var $productName;
    var $cartToolTip;
    
    var $cartButton;
    var $nextProduct;

    var $imageCard;

    var page = {

        "cartCount": 0,
        "onScreenProduct": 0,
        "cart": [],
        "userId": 0,
        


        //_userId = Me.get().UserId;

        "init": function () {
            page.userId = meObject.value;
            var products = [];

            $imageCard = $("#imageCard");
            $cartButton = $("#cartButton");
            $cartValue = $("#cartValue");
            $productPrice = $("#productPrice");
            $productSize = $("#productSize");
            $productName = $("#productName");
            $cartToolTip = $("#cartToolTip");

            $colorDropDownList = $("#colorDropDownList");
            $sizeDropDownList = $("#sizeDropDownList");
            $buttonRemoveFromCart = $("#buttonRemoveFromCart");        

            $buttonRemoveFromCart.on('click', function () {
                var screenItem = products[page.onScreenProduct];
                var selectedProduct = page.getSelectedProduct(screenItem);
                var removeCartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));
                $buttonRemoveFromCart.attr('disabled', 'disabled');
                page.cart = page.cart.filter(f => {
                    return (!(f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));
                });
                M.Product.RemoveFromCart(removeCartProduct.Id).done(function () {
                    page.cartCount = page.cartCount - parseInt(removeCartProduct.Product.Quantity);
                    $cartValue.text(page.cartCount);
                    UIkit.notification({
                        message: 'This item is successfully removed from your cart.',
                        status: 'danger',
                        timeout: '3000',
                        pos: 'top-center'
                    });
                });
            });

            $buttonAddToCart = $("#buttonAddToCart");
            $buttonAddToCart.on('click', function () {
                var item = {};
                var screenItem = products[page.onScreenProduct];
                var selectedProduct = page.getSelectedProduct(screenItem);
                var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));

                if (M.isNullOrUndefined(cartProduct))
                {
                    item.Id = "";
                    item.UserId = page.userId;
                    item.Product = selectedProduct;
                    page.cart.push(item);
                    M.Product.AddToCart(item).done(function (data) {
                        item.Id = data.Id;
                        $buttonRemoveFromCart.removeAttr('disabled');
                    });
                }
                else
                {
                    cartProduct.Product.Quantity++;
                    cartProduct.Product.Price.Value = cartProduct.Product.Quantity * selectedProduct.Price.Value;
                    M.Product.Update(cartProduct.Id, cartProduct.Product);
                }

                page.cartCount = page.cartCount + 1;
                $cartValue.text(page.cartCount);

                UIkit.notification({
                    message: 'This item is successfully added to your cart. Click on cart icon to see  your product',
                    status: 'primary',
                    timeout: '3000',
                    pos: 'top-center'
                });
            });

            $nextProduct = $("#nextProduct");
            $nextProduct.on('click', function () {
                if (page.onScreenProduct == (products.length - 1))
                {
                    UIkit.notification({
                        message: 'No more product available. Please try again later',
                        status: 'danger',
                        timeout: '3000',
                        pos: 'top-center'
                    });
                    return;
                }

                var selectedProduct = page.getSelectedProduct(products[page.onScreenProduct]);
                var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));

                if (!M.isNullOrUndefined(cartProduct)) {
                    $buttonRemoveFromCart.removeAttr('disabled');
                }
                else
                {
                    $buttonRemoveFromCart.attr('disabled', 'disabled');
                }

                page.onScreenProduct = page.onScreenProduct + 1;
                util.updateUi(products[page.onScreenProduct], page.onScreenProduct);
                util.updateColorDropdown(products[page.onScreenProduct].Color);
                util.updateSizeDropdown(products[page.onScreenProduct].Size);

            });

            $("#saveButton").on('click', function () {
                var _product = [];
                page.cart.forEach(d => {
                    _product.push(d.Product);
                });

                M.Product.Save(page.userId, _product).done(function (response) {
                    UIkit.notification({
                        message: 'Your order is placed successfully. Go to my order section to track your order',
                        status: 'primary',
                        timeout: '3000',
                        pos: 'top-center'
                    });
                    page.cart = [];
                    page.cartCount = 0;
                    $cartValue.text(page.cartCount);
                    UIkit.modal($("#cartModal")).hide();
                });
            });


            $cartButton.on('click', function () {
                M.Modal.Cart.show(page.cart);
            });

            $sizeDropDownList.change(function () {
                var val = $(this).val();
                var size = "";
                Object.keys(M.Size).forEach(key => { if (M.Size[key] == val) { size = key; } });
                $productSize.text(size.substring(0, 1));

                var selectedProduct = page.getSelectedProduct(products[page.onScreenProduct]);
                var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));

                if (!M.isNullOrUndefined(cartProduct)) {
                    $buttonRemoveFromCart.removeAttr('disabled');
                }
                else
                {
                    $buttonRemoveFromCart.attr('disabled', 'disabled');
                }
            });

            $colorDropDownList.change(function () {
                var val = $(this).val();
                var color = "";
                Object.keys(M.Color).forEach(key => { if (M.Color[key] == val) { color = key; } });

                var selectedProduct = page.getSelectedProduct(products[page.onScreenProduct]);
                var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));

                if (!M.isNullOrUndefined(cartProduct)) {
                    $buttonRemoveFromCart.removeAttr('disabled');
                }
                else
                {
                    $buttonRemoveFromCart.attr('disabled', 'disabled');
                }
            });

            action.getAll().done(function (data) {
                 
                data.forEach(d => {
                    var product = new M.Product(d);
                    products.push(product);
                });

                util.updateUi(products[page.onScreenProduct], page.onScreenProduct);

                //Color DropDown
                util.updateColorDropdown(products[page.onScreenProduct].Color);

                //Size Drop Down
                util.updateSizeDropdown(products[page.onScreenProduct].Size);

                var selectedProduct = page.getSelectedProduct(products[page.onScreenProduct]);
                var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] == f.Product.Size[0] && selectedProduct.Color[0] == f.Product.Color[0]));

                if (!M.isNullOrUndefined(cartProduct)) {
                    $buttonRemoveFromCart.removeAttr('disabled');
                }
                else
                {
                    $buttonRemoveFromCart.attr('disabled', 'disabled');
                }

            });

            action.getUserProducts().done(function (data) {
                page.cart = data.filter(f => (f.IsSaved != 1));
                var quantity = 0;
                page.cart.forEach(d => {
                    d.Product.Color[0] = M.Color[d.Product.Color[0]];
                    d.Product.Size[0] = M.Size[d.Product.Size[0]]
                    quantity += d.Product.Quantity;
                });
                page.cartCount = quantity;
                $cartValue.text(page.cartCount);
            });

        },

        "getSelectedProduct": function (screenProduct) {
            var product = {};
            product.Size = [];
            product.Color = [];
            product.Price = {};
            product.Price.Value = $productPrice.val();
            product.Id = screenProduct.Id;
            product.Name = screenProduct.Name;
            product.Quantity = 1;
            product.Size.push(parseInt($sizeDropDownList.val()));
            product.Color.push(parseInt($colorDropDownList.val()));
            return product;
        }
        
        
        
        
        
    };

    var util = {
        "updateUi": function (product, onScreenProduct) {
            $productName.text(product.Name);
            $productPrice.val(product.Price.Value);
            $productPrice.text("Rs." + product.Price.Value / 100);
            $productSize.text(product.Size[0].substring(0, 1));
            $imageCard.attr('data-src', window.location.origin + '/' + product.Source);

        },

        "updateColorDropdown": function (colors, selectedColor) {

            var colorId = 1;
            $colorDropdown = $colorDropDownList.empty();

            colors.forEach(
                color => $colorDropdown.append(new Option(color, M.Color[color]))
            );

            //Object.keys(M.Color).forEach(
            //    key => $colorDropdown.append(new Option(key, M.Color[key]))
            //);

            //$colorDropdown.val(colorId).trigger('change');

            $colorDropdown.chosen("destroy");
            $colorDropdown.chosen({ inherit_select_classes: true, width: "100%", no_results_text: "column not found" }).trigger('chosen:updated');
        },

        "updateSizeDropdown": function (sizes) {
            var sizeId = 1;
            $sizeDropdown = $sizeDropDownList.empty();

            sizes.forEach(
                size => $sizeDropdown.append(new Option(size, M.Size[size]))
            );

            //Object.keys(M.Size).forEach(
            //    key => $sizeDropdown.append(new Option(key, M.Size[key]))
            //);

            //$sizeDropdown.val(sizeId).trigger('change');

            $sizeDropdown.chosen("destroy");
            $sizeDropdown.chosen({ inherit_select_classes: true, width: "100%", no_results_text: "column not found" }).trigger('chosen:updated');


        },

    };

    var action = {
        "getAll": function () {
            var d = $.Deferred();
            $.ajax({
                url: 'api/v1/products',
                type: 'GET',
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    d.resolve(data);
                },
                fail: function (response) {
                    d.reject(response);
                }
            });
            return d.promise();
        },

        "getUserProducts": function () {
            var d = $.Deferred();
            $.ajax({
                url: 'api/v1/products/' + page.userId,
                type: 'GET',
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    d.resolve(data);
                },
                fail: function (response) {
                    d.reject(response);
                }
            });
            return d.promise();

        },

    };

    return {
        "init": page.init,
        "cart": page.cart,
        "cartCount": page.cartCount
    };

})();

window.onload = function () {
    var url = window.location.toString();
    M.Page.Product.init();
};




//var cartProduct = page.cart.find(f => (f.Product.Id == selectedProduct.Id && selectedProduct.Size[0] = f.Product.Size[0] && selectedProduct.Color[0] = f.Product.Color[0]){
//    if (f.Product.Id == selectedProduct.Id)
//{
//    var size = selectedProduct.Size[0] = f.Product.Size[0];
//    var color = selectedProduct.Color[0] = f.Product.Color[0];
//    if(size && color ){
//        return f.Product;
//    }
//}
//});