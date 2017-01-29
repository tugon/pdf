App.factory('httpService', ['$http', '$window', '$cookieStore', '$location', 'config', 'util',
    function ($http, $window, $cookieStore, $location, config, util) {
        config.baseUrlApi = $location.protocol() + "://" + $location.host() + ($location.port() ? ":" + $location.port() : "") + "/";
        return {

            post: function (url, obj, contentType) {
                if (contentType)
                    return $http.post(config.baseUrlApi + url, $.param(obj), { headers: { 'Content-Type': contentType } });
                return $http.post(config.baseUrlApi + url, obj);
            },

            get: function (url, obj) {
                if (obj) {
                    if (typeof (obj) === "object")
                        return $http.get(config.baseUrlApi + url, { params: obj });
                    return $http.get(config.baseUrlApi + url + "/" + obj);
                } else
                    return $http.get(config.baseUrlApi + url);
            },

            http: function (url, method, data, contentType) {
                return $http({
                    url: config.baseUrlApi + url,
                    method: method,
                    params: data,
                    headers: contentType ? { 'Content-Type': contentType } : { 'Content-Type': 'application/json' }
                });
            },
            postFile: function (urlAction, files, obj) {
                var data = new FormData();
                if (obj) {
                    data.append("model", angular.toJson(obj));
                }
                if (files.length > 0) {

                    for (i = 0; i < files.length; i++) {
                        data.append("file" + i, files[i]);
                    }
                }
                return $http.post(urlAction, data, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                });
            },
            setToken: function (token, expires) {
                sessionStorage.setItem(config.tokenKey, token);
                util.setToken(config.tokenKey, token, expires);
            },

            redirect: function (url) {
                $window.location.href = url;
            }
        };
    }]);


