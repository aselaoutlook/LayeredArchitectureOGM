(function () {
    'use strict';

    angular
        .module('app')
        .controller('StTypeViewModel', StTypeViewModel);

    StTypeViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function StTypeViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.StType = {
            "StTypeId": "",
            "Name": "",
            "Description": "",            
            "IsActive": "false",
            "RowCount": ""
        };

        $scope.StTypes = {};

        $scope.$watch("StTypes", function () {
            $scope.StType.RowCount = $scope.StTypes.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.StType.StTypeId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.StType.Name,
                Description: $scope.StType.Description,                
                IsActive: $scope.StType.IsActive 
            }

            $http({
                method: "POST", data: postData, url: "/Api/StTypeApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.StTypes = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {

            var putData = {
                StTypeId: $scope.StType.StTypeId,
                Name: $scope.StType.Name,
                Description: $scope.StType.Description,
                IsActive: $scope.StType.IsActive 
            }

            $http({
                method: "PUT", data: putData, url: "/Api/StTypeApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.StTypes = response;
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

        $scope.LoadById = function (StTypeId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/StTypeApi?StTypeId=" + StTypeId
            }).then(function successCallback(data, status, headers, config) {
                $scope.StType = data.data;
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
                Restangular.all('StTypeApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (stTypes) {
                    params.total(stTypes.paging.totalRecordCount);
                    $defer.resolve(stTypes);
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
            $scope.frmCreateStType.$setPristine();
            $scope.frmCreateStType.$setUntouched();
            $scope.StType = {
                "StTypeId": "",
                "Name": "",
                "Description": "",
                "IsActive": "false"
            };
        }
    }
})();