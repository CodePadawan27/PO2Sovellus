angular.module("maistuuko").service('ravintolaService', ['$http', function ($http) {
        this.haeKaupungit = function () {
                return $http.get("/api/kaupungit/");
        };
        this.haeRavintolat = function (ravintolaNimi) {
                return $http.get("/api/" + ravintolaNimi + "/ravintolat");
        };
}]);

angular.module("maistuuko").service('arviointiService', ['$http', function ($http) {
        this.haeArvioinnit = function (id) {
                return $http.get("/api/arvioinnit/" + id);
        };
        this.haeRavintola = function (id) {
                return $http.get("/api/ravintola/" + id);
        };
        this.lisaaArviointi = function (lisattava) {
                var request = $http({
                        method: "post",
                        url: "/api/arvioinnit/",
                        data: lisattava
                });
                return request;
    };
}]);