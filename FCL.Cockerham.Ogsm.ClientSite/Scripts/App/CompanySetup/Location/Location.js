(function () {
    'use strict';

    angular
        .module('app')
        .controller('LocationViewModel', LocationViewModel);

    LocationViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function LocationViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.Location = {
            "LocationId": "",
            "Name": "",
            "IsGlobal": "",
            "StateId": "",
            "CountryId": "",
            "GlobalRegionId": "",
            "RowCount": ""
        };

        $scope.GlobalRegion = {
            "GlobalRegionId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.Country = {
            "CountryId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.State = {
            "StateId": "",
            "StateName": "",
            "RowCount": ""
        };

        $scope.State = {};
        $scope.Country = {};
        $scope.Location = {};

        $scope.$watch("Locations", function () {
            $scope.Location.RowCount = $scope.Location.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Location.LocationId == '' || angular.isUndefined($scope.Location.LocationId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                GlobalRegionId: $scope.Location.GlobalRegionId.GlobalRegionId,
                CountryId: $scope.Location.CountryId.CountryId,
                StateId: $scope.Location.StateId.StateId,
                Name: $scope.Location.Name,
                IsGlobal: $scope.Location.IsGlobal
            }

            $http({
                method: "POST", data: postData, url: "/Api/LocationApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Locations = response;
                $scope.Country = {};
                $scope.State = {};
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                LocationId: $scope.Location.LocationId,
                GlobalRegionId: $scope.Location.GlobalRegionId.GlobalRegionId,
                CountryId: $scope.Location.CountryId.CountryId,
                StateId: $scope.Location.StateId.StateId,
                Name: $scope.Location.Name,
                IsGlobal: $scope.Location.IsGlobal
            }

            $http({
                method: "PUT", data: putData, url: "/Api/LocationApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Locations = response;
                $scope.Country = {};
                $scope.State = {};
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

        $scope.LoadById = function (LocationId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/LocationApi?LocationId=" + LocationId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Location = data.data;
                $scope.Location.GlobalRegionId = data.data.GlobalRegion;
                $scope.LoadCountries();
                $scope.Location.CountryId = data.data.Country;
                $scope.LoadStates();
                $scope.Location.StateId = data.data.State;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadGlobalRegions = function () {
            $scope.Country = {};
            $scope.State = {};
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/GlobalRegionApi/GetAllRegions"
            }).then(function successCallback(data, status, headers, config) {
                $scope.GlobalRegion = data.data;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadCountries = function () {
            if (!angular.isUndefined($scope.Location.GlobalRegionId)) {
                $scope.State = {};
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/Api/CountryApi/GetCountriesByGlobalRegionId?GrId=" + $scope.Location.GlobalRegionId.GlobalRegionId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.Country = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            }
            else {
                $scope.State = {};
                $scope.Country = {};
            }
        }

        $scope.LoadStates = function () {
            if (!angular.isUndefined($scope.Location.CountryId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/Api/StateApi/GetStatesByCountryId?CountryId=" + $scope.Location.CountryId.CountryId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.State = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.State = {};
            }
        }
                
        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                cfpLoadingBar.start();
                $scope.LoadGlobalRegions();
                Restangular.all('LocationApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (locations) {
                    params.total(locations.paging.totalRecordCount);
                    $defer.resolve(locations);
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
            $scope.frmCreateLocation.$setPristine();
            $scope.frmCreateLocation.$setUntouched();
            $scope.Location = {
                "LocationId": "",
                "Name": "",
                "IsGlobal": "",
                "StateId": "",
                "CountryId": "",
                "GlobalRegionId": "",
                "RowCount": ""
            };
            $scope.Country = {};
            $scope.State = {};
        }
    }
})();