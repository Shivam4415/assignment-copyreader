Share = new function () {

    let modal,
        btnShare;

    var _data = {};

    var init = function () {
        modal = "#shareModal";
        openShareModal = "#btnShare";
        btnShare = "#shareButton";

        $(openShareModal).on('click', _show);

        $(btnShare).on('click', _share);





    };

    var _show = function () {
        UIkit.modal($(modal)).show();
    };

    var _share = function () {

    };



    //Making Function Public
    return {
        Start: init
    };
};

window.onload = function () {

    var url = window.location.toString();
    Share.Start();
};


