
App.factory('emailService', ['httpService',
function (httpService) {
    return {
        apiPath: 'api/SendGrid/',
        get: function (method, param) {
            return httpService.get(this.apiPath + method, param)
        },
        post: function (method, param) {
            return httpService.post(this.apiPath + method, param)
        },
        send: function (message) {
            return this.post('send', message);
        }
    }
}]);

