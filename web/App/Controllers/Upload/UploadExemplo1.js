App.controller('UploadExemplo1Controller', ['$scope', '$location', '$window', 'httpService', 'config', 'util',
function ($scope, $location, $window, httpService, config, util) {


    $scope.urlAction = config.baseUrl + "api/upload/uploadDocument";
    $scope.init = function () {

    }
    $scope.init();
}]);