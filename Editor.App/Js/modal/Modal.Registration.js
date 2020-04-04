(Modal.Registration = (function ($) {

    var _modal,
        $modal;



    var _init = function () {

        _modal = UIkit.modal($modal);

    };
        
    var _show = function () {

        _init();


    };

    return {
        "show": _show
    };


})(jQuery));