'use strict';
App.factory('authServiceInterceptor', ['$q', '$location', '$window', '$injector', '$cookieStore', 'config', function ($q, $location, $window, $injector, $cookieStore, config) {

    var util = $injector.get('util');
    return {

        
        'request': function request(req) {
            var token = util.getToken(config.tokenKey);

            var headers = {};
            if (token) {
                headers = angular.copy(req.headers);
                headers.Authorization = 'Bearer ' + token;
            }
            if (token) {
                req.headers = headers;
            }
            return req;
        },
        'response': function (response) {
            return response;
            var token = sessionStorage.getItem(config.tokenKey);
        },
        'responseError': function (rejection) {
            if (rejection.status === 401) {
                $window.location.href = config.baseUrl + config.loginPage;
            }
            return $q.reject(rejection);
        },
        getToken: function () {


            return null;
        }
    };
}]);