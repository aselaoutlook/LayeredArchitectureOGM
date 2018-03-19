(function () {
    'use strict';

    angular
        .module('app')
        .controller('FiscalYearViewModel', FiscalYearViewModel);

    FiscalYearViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr'];

    function FiscalYearViewModel($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.FiscalYear = {
            "FiscalYearId": "",
            "StartYear": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "EndYear": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "EvaluationLength": "",
            "Description": "",
            "IsActive": "false",
            "RowCount": ""
        };

        //$scope.FiscalYear = {};

        $scope.$watch("FiscalYear", function () {
            $scope.FiscalYear.RowCount = $scope.FiscalYear.length;
        });
        
        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.FiscalYear.FiscalYearId == '' || angular.isUndefined($scope.FiscalYear.FiscalYearId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                StartYear: $scope.FiscalYear.StartYear,
                EndYear: $scope.FiscalYear.EndYear,
                EvaluationLength: $scope.FiscalYear.EvaluationLength,
                Description: $scope.FiscalYear.Description,
                IsActive: $scope.FiscalYear.IsActive
            }

            $http({
                method: "POST", data: postData, url: "/Api/FiscalYearApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.FiscalYear = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            $http({
                method: "PUT", data: $scope.FiscalYear, url: "/Api/FiscalYearApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.FiscalYear = response;
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

        $scope.LoadById = function (FiscalYearId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/FiscalYearApi?FiscalYearId=" + FiscalYearId
            }).then(function successCallback(data, status, headers, config) {
                $scope.FiscalYear = data.data;
                $scope.FiscalYear.StartYear = new Date($filter('date')($scope.FiscalYear.StartYear, 'yyyy-MM-dd'));
                $scope.FiscalYear.EndYear = new Date($filter('date')($scope.FiscalYear.EndYear, 'yyyy-MM-dd'));
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
                Restangular.all('FiscalYearApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (fiscalYears) {
                    params.total(fiscalYears.paging.totalRecordCount);
                    $defer.resolve(fiscalYears);
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
            $scope.frmCreateFiscalYear.$setPristine();
            $scope.frmCreateFiscalYear.$setUntouched();
            $scope.FiscalYear = {
                "FiscalYearId": "",
                "StartYear": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "EndYear": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "EvaluationLength": "",
                "Description": "",
                "IsActive": "false"
            };
        }               
        
        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };

        $scope.open3 = function () {
            $scope.popup3.opened = true;
        };

        $scope.popup2 = {
            opened: false
        };

        $scope.popup3 = {
            opened: false
        };        
    }
})();