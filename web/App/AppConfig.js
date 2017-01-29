

App.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    var defaultRoute = {
        templateUrl: '/Home/Home',
        controller: 'HomeController'
    }

    $routeProvider.when('/', defaultRoute)
    .when('/', defaultRoute)
    .when('/app', defaultRoute)
    .when('/home', defaultRoute)
    .when('/home/index', defaultRoute)
    .when('/app/contact', { templateUrl: '/pdf', controller: 'PdfController' })
    .when('/app/Upload/', { templateUrl: '/Upload', controller: 'UploadController' })
    .when('/app/Email/', { templateUrl: '/Email', controller: 'EmailController' })
    .when('/app/Upload/Exemplo1', { templateUrl: '/Upload/Exemplo1', controller: 'UploadExemplo1Controller' })
    .when('/app/Upload/Exemplo2', { templateUrl: '/Upload/Exemplo2', controller: 'UploadExemplo2Controller' })
    .otherwise(
       { templateUrl: '/Home/Home' }
    );

    $httpProvider.interceptors.push('authServiceInterceptor');

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: true
    }).hashPrefix('/');
}]);
