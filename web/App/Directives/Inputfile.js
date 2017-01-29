App.directive("inputFile", ['config', 'util', 'httpService',
    function (config, util, httpService) {
        return {
            restrict: 'EA',
            require: ['ngModel'],
            templateUrl: function (elem, attr) {
                var url = config.baseUrl + "App/Directives/templates/inputfile.html";
                return url;
            },
            scope: {
                ngModel: '=',
                urlAction: '@',
                onChange: '=',
                cssClass: '@',
                allowedExtensions: '=',
                label: '@',
                selectText: '@',
                callback: '=',
                allowMultiple: "="
            },

            link: function (scope, element, attrs, ctrl) {
                scope.element = element;
                scope.model = ctrl[0];
                scope.inputFile = $(element).find("input[type='file']");
                if (scope.allowMultiple)
                    scope.inputFile.attr("multiple", "true");

                scope.inputFile.on('change.bs.fileinput', scope.change);
                scope.$watch('model', function (newValue, oldValue) {
                    if (newValue != oldValue) {

                    }

                });
            },

            controller: ['$scope', function ($scope) {

                $scope.files = [];
                $scope.fileInfo = [];


                $scope.upload = function () {
                    httpService.postFile($scope.urlAction || config.baseUrl + "api/upload", $scope.files).success(function (response) {
                        if ($scope.callback)
                            $scope.callback(response)
                    }).error(function (response) {

                    });
                }
                $scope.change = function () {

                    $scope.files.push($scope.inputFile[0].files);
                    $scope.loadData($scope.inputFile[0].files);
                    $scope.model.$setViewValue($scope.files);



                    if ($scope.onChange) {
                        $scope.onChange($scope.files);
                    }
                }

                $scope.loadData = function (files, obj) {
                    var data = new FormData();
                    if (obj) {
                        data.append("model", angular.toJson(obj));
                    }
                    if (files.length > 0) {

                        for (i = 0; i < files.length; i++) {
                            $.each(files, function (index, ob) {
                                $scope.fileInfo.push(ob);
                            });
                            $scope.fileInfo = files[i];
                            data.append("file" + i, files[i]);
                        }
                    }
                }

            }]
        }
    }])