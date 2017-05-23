angular.module('EbayCalculations', [])
    .controller('ItemController',
        function($scope, $http) {
            $scope.title = "loading items...";
            $scope.options = [];
            $scope.working = false;
            $scope.items = [];

            $scope.getAllItems = function () {
                $scope.working = true;

                $http.get('/api/items', { headers: { Authorization: 'Bearer ' + sessionStorage.accessToken } })
                    .then(function (response, status, headers, config) {
                        $scope.working = false;
                        $scope.items = response.data;
                    }, function (data, status, headers, config) {
                        $scope.title = "Oops... something went wrong";
                        $scope.working = false;
                    });
            };

            $scope.sendItem = function(option) {
                $scope.working = true;

                $http.post('/api/item', { 'itemId': option.itemId })
                    .success(function(data, status, headers, config) {
                        $scope.success = (data === true);
                        $scope.working = false;
                    }).error(function(data, status, headers, config) {
                        $scope.title = "Oops... something went wrong";
                        $scope.working = false;
                    });
            };
        }
    );