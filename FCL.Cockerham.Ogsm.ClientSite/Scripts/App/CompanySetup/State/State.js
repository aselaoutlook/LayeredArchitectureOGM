(function () {
    'use strict';

    angular
        .module('app')
        .controller('StateViewModel', StateViewModel);

    StateViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function StateViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.State = {
            "StateId": "",
            "StateName": "",
            "StateCode": "",
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

        $scope.States = {};
        $scope.Country = {};

        $scope.$watch("States", function () {
            $scope.State.RowCount = $scope.States.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.State.StateId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                GlobalRegionId: $scope.State.GlobalRegionId.GlobalRegionId,
                CountryId: $scope.State.CountryId.CountryId,
                StateName: $scope.State.StateName,
                StateCode: $scope.State.StateCode
            }

            $http({
                method: "POST", data: postData, url: "/Api/StateApi"
            }).then(function successCallback(response, status, headers, config) {

                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.States = response;
                $scope.Country = {};
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                StateId: $scope.State.StateId,
                GlobalRegionId: $scope.State.GlobalRegionId.GlobalRegionId,
                CountryId: $scope.State.CountryId.CountryId,
                StateName: $scope.State.StateName,
                StateCode: $scope.State.StateCode
            }

            $http({
                method: "PUT", data: putData, url: "/Api/StateApi"
            }).then(function successCallback(response, status, headers, config) {

                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.States = response;
                $scope.Country = {};
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

        $scope.LoadById = function (StateId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/StateApi?StateId=" + StateId
            }).then(function successCallback(data, status, headers, config) {
                $scope.State = data.data;
                $scope.State.GlobalRegionId = data.data.Country.GlobalRegion;
                $scope.LoadCountries();
                $scope.State.CountryId = data.data.Country;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadGlobalRegions = function () {
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
            if (!angular.isUndefined($scope.State.GlobalRegionId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/Api/CountryApi/GetCountriesByGlobalRegionId?GrId=" + $scope.State.GlobalRegionId.GlobalRegionId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.Country = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            }
            else {
                $scope.Country = {};
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
                Restangular.all('StateApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (states) {
                    params.total(states.paging.totalRecordCount);
                    $defer.resolve(states);
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
            $scope.frmCreateState.$setPristine();
            $scope.frmCreateState.$setUntouched();
            $scope.State = {
                "StateId": "",
                "StateName": "",
                "StateCode": "",
                "CountryId": "",
                "GlobalRegionId": "",
                "RowCount": ""
            };
            $scope.Country = {};
        }
    }
})();