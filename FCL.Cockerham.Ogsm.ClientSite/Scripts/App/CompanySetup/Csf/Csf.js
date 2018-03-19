(function () {
    'use strict';

    angular
        .module('app')
        .controller('CsfViewModel', CsfViewModel);

    CsfViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function CsfViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar,  toastr) {
        var vm = this;
        $scope.Csf = {
            "CsfId": "",
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

        $scope.Csfs = {};

        $scope.$watch("Csfs", function () {
            $scope.Csf.RowCount = $scope.Csfs.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Csf.CsfId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.Csf.Name,
                Description: $scope.Csf.Description,
                StTypeId: $scope.Csf.StTypeId.StTypeId,
                SequenceNumber: $scope.Csf.SequenceNumber,
                IsActive: $scope.Csf.IsActive
            }

            $http({
                method: "POST", data: postData, url: "/Api/CsfApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Csfs = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                CsfId: $scope.Csf.CsfId,
                Name: $scope.Csf.Name,
                Description: $scope.Csf.Description,
                StTypeId: $scope.Csf.StTypeId.StTypeId,
                SequenceNumber: $scope.Csf.SequenceNumber,
                IsActive: $scope.Csf.IsActive
            }

            $http({
                method: "PUT", data: putData, url: "/Api/CsfApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Csfs = response;
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
        
        $scope.LoadById = function (CsfId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/CsfApi?CsfId=" + CsfId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Csf = data.data;
                $scope.Csf.StTypeId = data.data.StType;
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
                Restangular.all('CsfApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (csfs) {
                    params.total(csfs.paging.totalRecordCount);
                    $defer.resolve(csfs);
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
            $scope.frmCreateCsf.$setPristine();
            $scope.frmCreateCsf.$setUntouched();
            $scope.Csf = {
                "CsfId": "",
                "Name": "",
                "Description": "",
                "StTypeId": "",
                "SequenceNumber": "",
                "IsActive": "false"
            };
        }
    }
})();