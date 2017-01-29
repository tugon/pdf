App.factory('authService', ['$http', '$window', '$cookieStore', 'config', 'httpService', 'util',
    function ($http, $window, $cookieStore, config, httpService, util) {
        return {
            login: function (loginData, returnUrl) {
                httpService.post("Token", loginData, 'application/x-www-form-urlencoded').success(function (response) {

                    util.setToken(response.access_token,response.expires_in);
                    $window.location.href = config.baseUrl + config.entryPage;
                }).error(function (response) {
                    var error = response;
                });
            },
            logout: function () {
                httpService.post("api/account/Logout").success(function (response) {
                    var result = response;
                    $window.location.href = config.baseUrl + config.loginPage;
                    util.removeToken(config.tokenKey);
                }).error(function (response) {
                    var error = response;
                })
            },
            isLogged: function () {
                var token = util.getToken(config.tokenKey);
                //if (!token) {
                //token = util.getCookie("token");
                //if (token)
                    //util.setToken(token);
                //}
                return token !== null;
            }


        };
    }]);