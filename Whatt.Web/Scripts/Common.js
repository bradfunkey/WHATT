if (!window.Whatt) {
    window.Whatt = {};
}

(function (window) {
    "use strict";

    var Whatt = window.Whatt;

    Whatt.namespace = function (namespace, global, value) {
        var go;
        go = function (object, properties) {
            if (properties.length) {
                var propertyToDefine = properties.shift();
                if (typeof object[propertyToDefine] === 'undefined') {
                    object[propertyToDefine] = value || {};
                }
                go(object[propertyToDefine], properties);
            }
        };
        go(global || window, namespace.split('.'));
    };

    Whatt.resolve = function (namespace, root) {
        var path = namespace.split('.');

        root = root || window;
        return path.reduce(function (prev, curr) {
            return (prev == void 0) ? null : prev[curr];
        }, root);
    };

    if (!String.prototype.namespace) {
        String.prototype.namespace = function (root, value) {
            Whatt.namespace(this, root, value);
        };
    }

    if (!String.prototype.resolve) {
        String.prototype.resolve = function (root) {
            return Whatt.resolve(this, root);
        };
    }

}(window));

