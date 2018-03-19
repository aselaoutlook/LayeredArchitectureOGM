(function () {
    'use strict';

    angular
        .module('app')
        .controller('GoalCategoryViewModel', GoalCategoryViewModel);

    GoalCategoryViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function GoalCategoryViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.GoalCategory = {
            "GoalCategoryId": "",
            "DepartmentId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.Department = {
            "DepartmentId": "",
            "Name": ""
        };

        $scope.GoalCategorys = {};

        $scope.$watch("GoalCategorys", function () {
            $scope.GoalCategory.RowCount = $scope.GoalCategorys.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.GoalCategory.GoalCategoryId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                DepartmentId: $scope.GoalCategory.DepartmentId.DepartmentId,
                Name: $scope.GoalCategory.Name
            }

            $http({
                method: "POST", data: postData, url: "/Api/GoalCategoryApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.GoalCategorys = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var postData = {
                GoalCategoryId: $scope.GoalCategory.GoalCategoryId,
                DepartmentId: $scope.GoalCategory.DepartmentId.DepartmentId,
                Name: $scope.GoalCategory.Name
            }

            $http({
                method: "PUT", data: postData, url: "/Api/GoalCategoryApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.GoalCategorys = response;
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

        $scope.LoadById = function (GoalCategoryId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/GoalCategoryApi?GoalCategoryId=" + GoalCategoryId
            }).then(function successCallback(data, status, headers, config) {
                $scope.GoalCategory = data.data;
                $scope.GoalCategory.DepartmentId = data.data.Department;
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
                Restangular.all('GoalCategoryApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (goalCategories) {
                    params.total(goalCategories.paging.totalRecordCount);
                    $defer.resolve(goalCategories);
                    $scope.LoadDepartments();
                    cfpLoadingBar.complete();
                }, function (response) {
                    $scope.HandleErrors(response);
                });
            }
        });

        $scope.LoadDepartments = function () {
            $http({
                method: "GET", url: "/api/DepartmentApi/GetAllDepartments"
            }).then(function successCallback(data, status, headers, config) {
                $scope.Department = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

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
            $scope.frmCreateGoalCategory.$setPristine();
            $scope.frmCreateGoalCategory.$setUntouched();
            $scope.GoalCategory = {
                "GoalCategoryId": "",
                "DepartmentId": "",
                "Name": ""
            };
        }
    }
})();