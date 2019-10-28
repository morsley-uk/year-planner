var Information = (function($) {

    "strict on";

    var _entity;
    var _entityId;
    var _url;
    
    var _seconds = 30;

    function initialise() {

        if (typeof _entityId === "undefined") return;
        if (_entityId.length === 0) return;

        if (typeof _url === "undefined") return;
        if (_url.length === 0) return;

        _entity = $('#' + _entityId);

        if (_entity.length === 0) return;

        setInterval(_timer, 1000);

        _getInformation();

    }

    //initialise();

    function _timer() {

        _seconds--;

        //_entity.html(_seconds);

        if (_seconds > 0) return;

        _seconds = 30;

        _getInformation();

    }

    function _getInformation() {

        $.ajax({
            dataType: "json",
            url: _url,
            success: _success,
            fail: _fail
        });

    }

    function _success(value) {

        var result = "<dl >";

        result += "<dt>Assembly</dt>";
        result += "<dd>";
        result += "<b>Name</b>: " + value.assemblyFullName;
        result += "<span>|</span>";
        result += "<b>Version</b>: " + value.assemblyVersion;
        result += "<span>|</span>";
        result += "<b>Location</b>: " + value.assemblyLocation;
        result += "</dd>";

        result += "<dt>Framework</dt>";
        result += "<dd>";
        result += "<b>Name</b>: " + value.assemblyFrameworkName;
        result += "<span>|</span>";
        result += "<b>Version</b>: " + value.environmentVersion;
        result += "</dd>";

        result += "<dt>Machine</dt>";
        result += "<dd>";
        result += "<b>Name</b>: " + value.environmentMachineName;
        result += "<span>|</span>";
        result += "<b>Current Directory</b>: " + value.environmentCurrentDirectory;
        result += "</dd>";

        result += "<dt>Operating System</dt>";
        result += "<dd>";
        result += "<b>Version</b>: " + value.environmentOSVersion;
        result += "</dd>";

        result += "</dl>";

        $('#' + _entityId).html(result);
    }

    function _fail(value) {

    }

    var inner = function () {

        this.setEntityId = function (value) {
            _entityId = value;
            initialise();
        };

        this.setUrl = function (value) {
            _url = value;
            initialise();
        };

    };

    return inner;

})(jQuery);