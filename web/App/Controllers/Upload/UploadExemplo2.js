App.controller('UploadExemplo2Controller', ['$scope', 'FileUploader', 'config', function ($scope, FileUploader, config) {
    var uploader = $scope.uploader = new FileUploader({
        url: '/api/upload/UploadDocument'
    });
    uploader.filters.push({
        name: 'syncFilter',
        fn: function (item /*{File|FileLikeObject}*/, options) {
            console.log('syncFilter');
            return this.queue.length < 10;
        }
    });

    uploader.filters.push({
        name: 'asyncFilter',
        fn: function (item /*{File|FileLikeObject}*/, options, deferred) {
            console.log('asyncFilter');
            setTimeout(deferred.resolve, 1e3);
        }
    });
}]);