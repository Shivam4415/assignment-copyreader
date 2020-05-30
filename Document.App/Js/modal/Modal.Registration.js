
Registration = new function () {

    var modal,
        btnRegister;

    var init = function () {
            modal = "#registrationModal",
            btnRegister = "#btnSignUp";

        $(btnRegister).on('click', _show);


    };

    var _show = function () {
        UIkit.modal($(modal)).show();
    };


    var _initControls = function () {

    };


    //Making Function Public
    return {
        Start: init
    };
};

window.onload = function () {

    var url = window.location.toString();
    Registration.Start();
};



