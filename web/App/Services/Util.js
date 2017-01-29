
App.factory('util', ['$cookieStore', 'config', function ($cookieStore, config) {
    return {
        stringFormat: function (str) {
            if (arguments.length > 1) {
                result = str.replace(/{[0-9]{1}}/gi, "@pholder@");
                for (var i = 1; i < arguments.length; i++) {
                    result = result.replace(/@pholder@/, arguments[i]);
                }
                for (i = 1; i < arguments.length; i++) {
                    result = result.replace(/@pholder@/, "{" + i + "}");
                }
                return result
            }
            return str;
        },

        getCookie: function (key) {
            if (document.cookie) {
                var hashString = document.cookie.replace(";", "=");
                params = hashString.split("=");
                if (params.indexOf(key) >= 0) {
                    var index = params.indexOf(key);
                    return params[index + 1]
                }

            }
            return "";
        },
        setToken: function (token, expires) {
            //sessionStorage.setItem(config.tokenKey, token);
            var expDate = new Date(expires);
            $cookieStore.put(config.tokenKey, token, { expires: expires })
        },
        getToken: function (token) {
            return $cookieStore.get(config.tokenKey)
        },
        removeToken: function (token) {
            $cookieStore.remove(config.tokenKey)
        }
    }
}]);