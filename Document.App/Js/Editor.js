(function (window, document, undefined) {

    var M = {
        version: '0.1',
        assert: false, // commented production code contains 'if (M.assert'
        debug: false
    };

    function expose() {
        var oldM = window.M;

        M.noConflict = function () {
            window.M = oldM;
            return this;
        };

        window.M = M;
    }

    // define Mapline as a global M variable, saving the original M to restore later if needed
    if (typeof window !== 'undefined') {
        expose();
    }

 




    (function () {
        // prefix style property names

        // @property TRANSFORM: String
        // Vendor-prefixed fransform style name (e.g. `'webkitTransform'` for WebKit).
        M.DomUtil.TRANSFORM = M.DomUtil.testProp(
            ['transform', 'WebkitTransform', 'OTransform', 'MozTransform', 'msTransform']);


        // webkitTransition comes first because some browser versions that drop vendor prefix don't do
        // the same for the transitionend event, in particular the Android 4.1 stock browser

        // @property TRANSITION: String
        // Vendor-prefixed transform style name.
        var transition = M.DomUtil.TRANSITION = M.DomUtil.testProp(
            ['webkitTransition', 'transition', 'OTransition', 'MozTransition', 'msTransition']);

        M.DomUtil.TRANSITION_END =
            transition === 'webkitTransition' || transition === 'OTransition' ? transition + 'End' : 'transitionend';

        // @function disableTextSelection()
        // Prevents the user from generating `selectstart` DOM events, usually generated
        // when the user drags the mouse through a page with text. Used internally
        // by Leaflet to override the behaviour of any click-and-drag interaction on
        // the map. Affects drag interactions on the whole document.

        // @function enableTextSelection()
        // Cancels the effects of a previous [`M.DomUtil.disableTextSelection`](#domutil-disabletextselection).
        if ('onselectstart' in document) {
            M.DomUtil.disableTextSelection = function () {
                M.DomEvent.on(window, 'selectstart', M.DomEvent.preventDefault);
            };
            M.DomUtil.enableTextSelection = function () {
                M.DomEvent.off(window, 'selectstart', M.DomEvent.preventDefault);
            };

        } else {
            var userSelectProperty = M.DomUtil.testProp(
                ['userSelect', 'WebkitUserSelect', 'OUserSelect', 'MozUserSelect', 'msUserSelect']);

            M.DomUtil.disableTextSelection = function () {
                if (userSelectProperty) {
                    var style = document.documentElement.style;
                    this._userSelect = style[userSelectProperty];
                    style[userSelectProperty] = 'none';
                }
            };
            M.DomUtil.enableTextSelection = function () {
                if (userSelectProperty) {
                    document.documentElement.style[userSelectProperty] = this._userSelect;
                    delete this._userSelect;
                }
            };
        }

        // @function disableImageDrag()
        // As [`M.DomUtil.disableTextSelection`](#domutil-disabletextselection), but
        // for `dragstart` DOM events, usually generated when the user drags an image.
        M.DomUtil.disableImageDrag = function () {
            M.DomEvent.on(window, 'dragstart', M.DomEvent.preventDefault);
        };

        // @function enableImageDrag()
        // Cancels the effects of a previous [`M.DomUtil.disableImageDrag`](#domutil-disabletextselection).
        M.DomUtil.enableImageDrag = function () {
            M.DomEvent.off(window, 'dragstart', M.DomEvent.preventDefault);
        };

        // @function preventOutline(el: HTMLElement)
        // Makes the [outline](https://developer.mozilla.org/docs/Web/CSS/outline)
        // of the element `el` invisible. Used internally by Leaflet to prevent
        // focusable elements from displaying an outline when the user performs a
        // drag interaction on them.
        M.DomUtil.preventOutline = function (element) {
            while (element.tabIndex === -1) {
                element = element.parentNode;
            }
            if (!element || !element.style) {
                return;
            }
            M.DomUtil.restoreOutline();
            this._outlineElement = element;
            this._outlineStyle = element.style.outline;
            element.style.outline = 'none';
            M.DomEvent.on(window, 'keydown', M.DomUtil.restoreOutline, this);
        };

        // @function restoreOutline()
        // Cancels the effects of a previous [`M.DomUtil.preventOutline`]().
        M.DomUtil.restoreOutline = function () {
            if (!this._outlineElement) {
                return;
            }
            this._outlineElement.style.outline = this._outlineStyle;
            delete this._outlineElement;
            delete this._outlineStyle;
            M.DomEvent.off(window, 'keydown', M.DomUtil.restoreOutline, this);
        };
        M.DomUtil.getBrowserForIe = function () {
            //True for all IE
            var _showModal = function () {
                try {
                    UIkit.modal("#upgradeBrowserModal").show();
                }
                catch (e) {
                    $("#upgradeBrowserModal").show().addClass('uk-open');
                }
            };
            var ie = ('ActiveXObject' in window);
            //true for ie version 10 and less than 10
            var ie10 = ((navigator.userAgent.indexOf('MSIE ')) > 0);

            if (ie && ie10) _showModal();

            if (navigator.userAgent.match(/Opera Mini/i)) _showModal();
        };
    })();

}(window, document));

function chr(num) {
    return String.fromCharCode(num);
};