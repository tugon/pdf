App.controller('HomeController', ['$scope', '$location', '$window', 'httpService', 'config', 'util',
function ($scope, $location, $window, httpService, config, util) {

    $scope.generatePdf = function (obj, key) {
        //httpService.redirect("http://google.com.br");
        httpService.redirect(config.baseUrl+"api/pdf/generatePdf");
    }

    $scope.init = function () {

    }
    $scope.init();
}]);