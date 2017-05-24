angular.module('EbayCalculations', [])
    .controller('ItemController',
        function($scope, $http) {
            $scope.title = "loading items...";
            $scope.options = [];
            $scope.working = true;
            $scope.items = [];
            $scope.summations = {
                price: 0,
                shippingPaidByBuyer: 0,
                shippingPaidBySeller: 0,
                shippingContainerPrice: 0,
                paypalFee: 0,
                ebayFee: 0
            };

            function resetSummations() {
                $scope.summations = {
                    price: 0,
                    shippingPaidByBuyer: 0,
                    shippingPaidBySeller: 0,
                    shippingContainerPrice: 0,
                    paypalFee: 0,
                    ebayFee: 0
                };
            };

            function calculateSummations() {
                var intId = setInterval(function () {
                    if (!$scope.working) {
                        for (var i = 0, len = $scope.items.length; i < len; i++) {
                            var item = $scope.items[i];

                            $scope.summations.price += item.price;
                            $scope.summations.shippingPaidByBuyer += item.shippingPaidByBuyer;
                            $scope.summations.shippingPaidBySeller += item.shippingPaidBySeller;
                            $scope.summations.shippingContainerPrice += item.shippingContainerPrice;
                            $scope.summations.paypalFee += item.paypalFee;
                            $scope.summations.ebayFee += item.ebayFee;
                        }

                        $scope.$apply();
                        clearInterval(intId);
                    }
                }, 50);
            }

            $scope.getAllItems = function () {
                $scope.working = true;

                $http.get('/api/items', { headers: { Authorization: 'Bearer ' + sessionStorage.accessToken } })
                    .then(function (response, status, headers, config) {
                        $scope.items = response.data;
                        $scope.working = false;
                    }, function (data, status, headers, config) {
                        $scope.title = "Oops... something went wrong";
                        $scope.working = false;
                    });
            };

            $scope.getSummations = function () {
                resetSummations();
                calculateSummations();
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