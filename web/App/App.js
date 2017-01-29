var App = angular.module("App",
    [
        "angularFileUpload",
        "fileUpload",
        "ngAnimate",
        "ngAria",
        "ngCookies",
        "ngMessages",
        "ngSanitize",
        "ui.bootstrap",
        "ui.sortable",
        "ngRoute",
        "LocalStorageModule",
    ]);

App.factory('config', [function () {
    return {
        baseUrl: baseUrl,
        //baseUrl: baseUrlApi,
    }
}]);


