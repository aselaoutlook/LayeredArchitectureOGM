(function () {
    'use strict';

    angular
        .module('app')
        .controller('GoalViewModel', GoalViewModel);

    GoalViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr'];

    function GoalViewModel($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.Goal = {
            "GoalId": "",
            "PillarId": "",
            "Name": "",
            "StartDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "EndDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "RationaleNotes": "",
            "Target": "",
            "PrimaryOwnerId": "",
            "SecondryOwnerId": "",
            "SequenceNumber": "",
            "IsActive": "false",
            "RowCount": ""
        };

        $scope.Pillar = {
            "PillarId": "",
            "Name": "",
            "RowCount": ""
        };

        $scope.Owners = {
            "UserId": "",
            "FirstName": "",
            "LastName": "",
            "MiddleInitial": "",
            "RowCount": ""
        };

        //$scope.Goal = {};

        $scope.$watch("Goal", function () {
            $scope.Goal.RowCount = $scope.Goal.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Goal.GoalId == '' || angular.isUndefined($scope.Goal.GoalId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                PillarId: $scope.Goal.PillarId.PillarId,
                Name: $scope.Goal.Name,
                StartDate: $scope.Goal.StartDate,
                EndDate: $scope.Goal.EndDate,
                RationaleNotes: $scope.Goal.RationaleNotes,
                Target: $scope.Goal.Target,
                PrimaryOwnerId: $scope.Goal.PrimaryOwnerId.UserId,
                SecondryOwnerId: $scope.Goal.SecondryOwnerId.UserId,
                SequenceNumber: $scope.Goal.SequenceNumber,
                IsActive: $scope.Goal.IsActive
            }

            $http({
                method: "POST", data: postData, url: "/Api/GoalApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Goal = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var putData = {
                GoalId: $scope.Goal.GoalId,
                PillarId: $scope.Goal.PillarId.PillarId,
                Name: $scope.Goal.Name,
                StartDate: $scope.Goal.StartDate,
                EndDate: $scope.Goal.EndDate,
                RationaleNotes: $scope.Goal.RationaleNotes,
                Target: $scope.Goal.Target,
                PrimaryOwnerId: $scope.Goal.PrimaryOwnerId.UserId,
                SecondryOwnerId: $scope.Goal.SecondryOwnerId.UserId,
                SequenceNumber: $scope.Goal.SequenceNumber,
                IsActive: $scope.Goal.IsActive
            }

            $http({
                method: "PUT", data: putData, url: "/Api/GoalApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Goal = response;
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

        $scope.LoadById = function (GoalId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/GoalApi?GoalId=" + GoalId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Goal = data.data;
                $scope.Goal.PillarId = data.data.Pillar;
                $scope.Goal.PrimaryOwnerId = data.data.PrimaryOwner;
                $scope.Goal.SecondryOwnerId = data.data.SecondryOwner;
                $scope.Goal.StartDate = new Date($filter('date')($scope.Goal.StartDate, 'yyyy-MM-dd'));
                $scope.Goal.EndDate = new Date($filter('date')($scope.Goal.EndDate, 'yyyy-MM-dd'));
               
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadPillars = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/PillarApi/GetAllPillarsByOrganization"
            }).then(function successCallback(data, status, headers, config) {
                $scope.Pillar = data.data;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadActiveGoalOwners = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/OwnersApi/GetActiveGoalOwnersByOrganization"
            }).then(function successCallback(data, status, headers, config) {
                $scope.Owners = data.data;
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
                $scope.LoadPillars();
                $scope.LoadActiveGoalOwners();
                Restangular.all('GoalApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (goals) {
                    params.total(goals.paging.totalRecordCount);
                    $defer.resolve(goals);
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
            $scope.frmCreateGoal.$setPristine();
            $scope.frmCreateGoal.$setUntouched();
            $scope.Goal = {
                "GoalId": "",
                "PillarId": "",
                "Name": "",
                "StartDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "EndDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "RationaleNotes": "",
                "Target": "",
                "PrimaryOwnerId": "",
                "SecondryOwnerId": "",
                "SequenceNumber": "",
                "IsActive": "false",
                "RowCount": ""
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