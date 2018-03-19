(function () {
    'use strict';

    angular
        .module('app')
        .controller('PillarViewModel', PillarViewModel);

    PillarViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function PillarViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.Pillar = {
            "PillarId": "",
            "Name": "",
            "Description": "",
            "StTypeId": "",
            "SequenceNumber": "",
            "IsActive": "false",
            "RowCount": ""
        };

        $scope.StType = {
            "StTypeId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.Pillars = {};

        $scope.$watch("Pillars", function () {
            $scope.Pillar.RowCount = $scope.Pillars.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Pillar.PillarId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.Pillar.Name,
                Description: $scope.Pillar.Description,
                StTypeId: $scope.Pillar.StTypeId.StTypeId,
                SequenceNumber: $scope.Pillar.SequenceNumber,
                IsActive: $scope.Pillar.IsActive
            }

            $http({
                method: "POST", data: postData, url: "/Api/PillarApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Pillars = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                PillarId: $scope.Pillar.PillarId,
                Name: $scope.Pillar.Name,
                Description: $scope.Pillar.Description,
                StTypeId: $scope.Pillar.StTypeId.StTypeId,
                SequenceNumber: $scope.Pillar.SequenceNumber,
                IsActive: $scope.Pillar.IsActive
            }

            $http({
                method: "PUT", data: putData, url: "/Api/PillarApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Pillars = response;
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

        $scope.LoadById = function (PillarId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/PillarApi?PillarId=" + PillarId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Pillar = data.data;
                $scope.Pillar.StTypeId = data.data.StType;
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
                Restangular.all('PillarApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (pillars) {
                    params.total(pillars.paging.totalRecordCount);
                    $defer.resolve(pillars);
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
            $scope.frmCreatePillar.$setPristine();
            $scope.frmCreatePillar.$setUntouched();
            $scope.Pillar = {
                "PillarId": "",
                "Name": "",
                "Description": "",
                "StTypeId": "",
                "SequenceNumber": "",
                "IsActive": "false"
            };
        }
    }
})();