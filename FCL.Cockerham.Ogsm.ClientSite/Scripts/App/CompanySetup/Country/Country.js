(function () {
    'use strict';

    angular
        .module('app')
        .controller('CountryViewModel', CountryViewModel);

    CountryViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function CountryViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.Country = {
            "CountryId": "",
            "Name": "",
            "GlobalRegionId": "",
            "RowCount": ""
        };

        $scope.GlobalRegion = {
            "GlobalRegionId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.Countrys = {};

        $scope.$watch("Countrys", function () {
            $scope.Country.RowCount = $scope.Countrys.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Country.CountryId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                GlobalRegionId: $scope.Country.GlobalRegionId.GlobalRegionId,
                Name: $scope.Country.Name
            }

            $http({
                method: "POST", data: postData, url: "/Api/CountryApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Countrys = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                CountryId: $scope.Country.CountryId,
                GlobalRegionId: $scope.Country.GlobalRegionId.GlobalRegionId,
                Name: $scope.Country.Name
            }

            $http({
                method: "PUT", data: putData, url: "/Api/CountryApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Countrys = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordUpdated);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Clear = function () {
            $scope.Reset();
        }   

        $scope.LoadById = function (CountryId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/CountryApi?CountryId=" + CountryId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Country = data.data;
                $scope.Country.GlobalRegionId = data.data.GlobalRegion;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadGlobalRegions = function () {
            $http({
                method: "GET", url: "/Api/GlobalRegionApi/GetAllRegions"
            }).then(function successCallback(data, status, headers, config) {
                $scope.GlobalRegion = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }
        
        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                cfpLoadingBar.start();
                $scope.LoadGlobalRegions();
                Restangular.all('CountryApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (countries) {
                    params.total(countries.paging.totalRecordCount);
                    $defer.resolve(countries);
                    cfpLoadingBar.complete();
                }, function (response) {
                    $scope.HandleErrors(response);
                });
            }
        });

        $scope.ShowAlert = function (type, message) {
            if (type == "success") {
                toastr.success(message, 'Success');
            } else if (type == "info") {
                toastr.info(message, 'Information');
            } else if (type == "error") {
                toastr.error(message, 'Error');
            } else if (type == "warning") {
                toastr.warning(message, 'Warning');
            }
        }

        $scope.HandleErrors = function (response) {
            if (response.status == 401) {
                cfpLoadingBar.complete();
                location.href = "/Login/Account/LogOff";
            }
            else {
                $scope.ShowAlert('danger', response.data.Message);
                cfpLoadingBar.complete();
            }
        }

        $scope.Reset = function () {
            $scope.frmCreateCountry.$setPristine();
            $scope.frmCreateCountry.$setUntouched();
            $scope.Country = {
                "CountryId": "",
                "Name": "",
                "GlobalRegionId": ""
            };
        }
    }
})();