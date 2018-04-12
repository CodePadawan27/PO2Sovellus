(function () {
    "use strict";
    angular.module("maistuuko", ['ngRoute']);
})();

angular.module("maistuuko").config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
                controller: 'kaupunkiCtrl',
                templateUrl: '/views/Etusivu.html'
        });
        $routeProvider.when('/ravintolat/:Nimi', {
                controller: 'ravintolaCtrl',
                templateUrl: '/views/Ravintolat.html'
    });

    $routeProvider.when('/arviointi/:Id', {
        controller: 'arviointiCtrl',
        templateUrl: '/views/Arvioinnit.html'
    });
    $routeProvider.when('/arviointi/lisaa/:Id', {
        controller: 'arviointiCtrl',
        templateUrl: '/views/LisaaArviointi.html'
    });
        $routeProvider.otherwise({ redirectTo: '/' });
}]);

