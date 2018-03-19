(function () {
    'use strict';

    angular
        .module('app')
        .controller('GlobalRegionViewModel', GlobalRegionViewModel);

    GlobalRegionViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function GlobalRegionViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.GlobalRegion = {
            "GlobalRegionId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.GlobalRegions = {};

        $scope.$watch("GlobalRegions", function () {
            $scope.GlobalRegion.RowCount = $scope.GlobalRegions.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.GlobalRegion.GlobalRegionId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.GlobalRegion.Name
            }

            $http({
                method: "POST", data: postData, url: "/Api/GlobalRegionApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.GlobalRegions = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            $http({
                method: "PUT", data: $scope.GlobalRegion, url: "/Api/GlobalRegionApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.GlobalRegions = response;
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

        $scope.LoadById = function (GlobalRegionId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/GlobalRegionApi?GlobalRegionId=" + GlobalRegionId
            }).then(function successCallback(data, status, headers, config) {
                $scope.GlobalRegion = data.data;
                cfpLoadingBar.complete();
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
                Restangular.all('GlobalRegionApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (globalRegions) {
                    params.total(globalRegions.paging.totalRecordCount);
                    $defer.resolve(globalRegions);
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
            $scope.frmCreateGlobalRegion.$setPristine();
            $scope.frmCreateGlobalRegion.$setUntouched();
            $scope.GlobalRegion = {
                "GlobalRegionId": "",
                "Name": ""
            };
        }
    }
})();