(function () {
    'use strict';

    angular
        .module('app')
        .controller('BusinessUnitViewModel', BusinessUnitViewModel);

    BusinessUnitViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function BusinessUnitViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.BusinessUnit = {
            "BusinessUnitId": "",
            "Name": "",
            "Location": "",
            "Description": "",
            "StTypeId": "",
            "IsActive": "false",
            "RowCount": ""
        };

        $scope.StType = {
            "StTypeId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.BusinessUnits = {};

        $scope.$watch("BusinessUnits", function () {
            $scope.BusinessUnit.RowCount = $scope.BusinessUnits.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.BusinessUnit.BusinessUnitId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.BusinessUnit.Name,
                Description: $scope.BusinessUnit.Description,
                Location: $scope.BusinessUnit.Location,
                StTypeId: $scope.BusinessUnit.StTypeId.StTypeId,
                IsActive: $scope.BusinessUnit.IsActive
            }

            $http({
                method: "POST", data: postData, url: "/Api/BusinessUnitApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.BusinessUnits = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                BusinessUnitId: $scope.BusinessUnit.BusinessUnitId,
                Name: $scope.BusinessUnit.Name,
                Description: $scope.BusinessUnit.Description,
                Location: $scope.BusinessUnit.Location,
                StTypeId: $scope.BusinessUnit.StTypeId.StTypeId,
                IsActive: $scope.BusinessUnit.IsActive
            }

            $http({
                method: "PUT", data: putData, url: "/Api/BusinessUnitApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.BusinessUnits = response;
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

        $scope.LoadById = function (BusinessUnitId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/BusinessUnitApi?BusinessUnitId=" + BusinessUnitId
            }).then(function successCallback(data, status, headers, config) {
                $scope.BusinessUnit = data.data;
                $scope.BusinessUnit.StTypeId = data.data.StType;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
            
        }

        $scope.LoadStTypes = function () {
            $http({
                method: "GET", url: "/Api/StTypeApi/GetAllStTypes"
            }).then(function successCallback(data, status, headers, config) {
                $scope.StType = data.data;
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
                $scope.LoadStTypes();
                Restangular.all('BusinessUnitApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (businessUnits) {
                    params.total(businessUnits.paging.totalRecordCount);
                    $defer.resolve(businessUnits);
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
            $scope.frmCreateBusinessUnit.$setPristine();
            $scope.frmCreateBusinessUnit.$setUntouched();
            $scope.BusinessUnit = {
                "BusinessUnitId": "",
                "Name": "",
                "Location": "",
                "Description": "",                
                "StTypeId": "",
                "IsActive": "false"
            };
        }
    }
})();
