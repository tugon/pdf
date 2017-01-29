App.controller('EmailController', ['$scope', 'emailService', 'config',
function ($scope, emailService, config) {

    $scope.message = {
        name: "",
        content: "",
        recipients: []
    }

    $scope.send = function () {
        $scope.error = "";
        $scope.success = "";
        emailService.send($scope.message).then(
            function (response) {
                $scope.success="Message sent";

                $scope.message = {
                    name: "",
                    content: "",
                    recipients: []
                }
            },
            function (error) {
                $scope.error = error;
                $scope.success = "";
            }
        );
    }

    $scope.add = function () {
        if ($scope.email)
            $scope.message.recipients.push({ email: $scope.email });
        $scope.email = "";
    }

    $scope.remove = function (index) {
        $scope.message.recipients.splice(index, 1);
    }
}]);