Readerdata = (function () {

    var _reader = function (root, data) {
        this.Id = data.Id;
        this.Ordinal = data.Ordinal;
        this.Length = data.Length;
        this.Value = data.Value;
        this.Attributes = data.Attributes;
        this.AttributorSettings = data.AttributorSettings;
        

    };

    _reader.prototype.getData = function (ops) {
        
        //for (let i = 0; i < )
        


    };


        






    _reader.Save = function () {
        var d = $.Deferred();
        $.ajax({
            url: 'api/v1/',
            data: JSON.stringify(_data),
            method: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                return d.resolve(data);
            },
            fail: function (xhr, textStatus, errorThrown) {
                return d.reject(xhr);
            }
        });
        return d.promise();
    };

    return _reader;
})();