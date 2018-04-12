angular.module("maistuuko").controller('kaupunkiCtrl', ['$scope', 'ravintolaService',
    function ($scope, ravintolaService) {
            $scope.Kaupungit = [];
            $scope.IsBusy = true;
            $scope.Kaupunki = "";
            // haeKaupungit palauttaa ns. promisen -> kutsutaan then, joka palauttaa promisen ->
            // sille kutsutaan then
        ravintolaService.haeKaupungit().then(
            function (result) { /* ok */
                $scope.Kaupungit = result.data;
            },
            function (err) { /* virhe */
                $log.error('Virhe kaupunkinimien latauksessa', err);
            })
            .then(function () { $scope.IsBusy = false; });
    }]);

angular.module("maistuuko").controller('ravintolaCtrl', ['$scope', 'ravintolaService',
    '$routeParams',
        function ($scope, ravintolaService, $routeParams) {
                $scope.IsBusy = true;
                $scope.Ravintolat = [];
                $scope.Kaupunki = $routeParams.Nimi;
                //haetaan ravintolat
            ravintolaService.haeRavintolat($scope.Kaupunki).then(
                function (result) { /* ok */
                    $scope.Ravintolat = result.data;
                },
                function (err) { /* virhe */
                    $log.error('Virhe ravintolatietojen latauksessa', err);
                })
                .then(function () { $scope.IsBusy = false; });
    }]);

angular.module("maistuuko").controller('arviointiCtrl', ['$scope', 'arviointiService',
    '$routeParams', '$window',
        function ($scope, arviointiService, $routeParams, $window) {
                $scope.IsBusy = true;
                $scope.Arvioinnit = [];
                $scope.Ravintola = null;
                $scope.Arviointi = null;
                $scope.Arvio = 3;
                $scope.lisaaArviointi = function () {
                        var lisattava = {
                                RavintolaId: $routeParams.Id,
                                Arvio: $scope.Arvio,
                                Teksti: $scope.Teksti,
                                Aika: new Date()
                        };
                        arviointiService.lisaaArviointi(lisattava).then(
                                function (result) {
                                        $scope.Arviointi = result.data;
                                        $window.location = '#!/arviointi/' + $routeParams.Id;
                                }, function (err) {
                                        $log.error('Virhe ravintola-arvioinnin lisäyksessä', err);
                                });
        };

        //haetaan arvioinnit
                arviointiService.haeArvioinnit($routeParams.Id).then(
                        function (result) { /* ok */
                                $scope.Arvioinnit = result.data;
                        },
                        function (err) { /* virhe */
                                $log.error('Virhe ravintolan arviointitietojen latauksessa', err);
                        }).then();
                //haetaan ravintola
                arviointiService.haeRavintola($routeParams.Id).then(
                        function (result) { /* ok */
                                $scope.Ravintola = result.data;
                        },
                        function (err) { /* virhe */
                                $log.error('Virhe ravintolatietojen latauksessa', err);
                        })
                    .then(function () { $scope.IsBusy = false; });
        }]);