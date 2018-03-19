(function () {
    'use strict';

    angular
        .module('app')
        .controller('GoalAssessmentController', GoalAssessmentController);

    GoalAssessmentController.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr'];

    function GoalAssessmentController($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.GoalTargets = {
            "GoalId": "",
            "PillarId": "",
            "Name": "",
            "StartDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "EndDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "RationaleNotes": "",
            "Target": "",
            "TargetDesc": "",
            "PrimaryOwnerId": "",
            "SecondryOwnerId": "",
            "GoalTargets": [{
                "GoalTargetId": "",
                "GoalId": "",
                "OrganizationId": "",
                "YearName": "",
                "YearValue": "",
                "StartDate": "",
                "EndDate": "",
                "IsActive": "",
                "Results": ""
            }],
            "IsActive": "false",
            "RowCount": ""
        };

        $scope.Pillar = {
            "PillarId": "",
            "Name": ""
        };

        //$scope.GoalCategory = {
        //    "GoalCategoryId": "",
        //    "Name": ""
        //};

        $scope.Goal = {
            "GoalId": "",
            "Name": ""
        };

        //$scope.GoalTargets = {};

        $scope.Update = function () {
            var putData = {
                GoalId: $scope.GoalTargets.GoalId,
                PillarId: $scope.GoalTargets.PillarId.PillarId,
                Name: $scope.GoalTargets.Name,
                StartDate: $scope.GoalTargets.StartDate,
                EndDate: $scope.GoalTargets.EndDate,
                RationaleNotes: $scope.GoalTargets.RationaleNotes,
                Target: $scope.GoalTargets.Target,
                TargetDesc: $scope.GoalTargets.TargetDesc,
                PrimaryOwnerId: $scope.GoalTargets.PrimaryOwnerId.UserId,
                SecondryOwnerId: $scope.GoalTargets.SecondryOwnerId.UserId,
                GoalTargets: $scope.GoalTargets.GoalTargets,
                IsActive: $scope.GoalTargets.IsActive
            }

            $http({
                method: "PUT", data: putData, url: "/api/GoalApi/UpdateGoalTargets"
            }).then(function successCallback(response, status, headers, config) {
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

        $scope.LoadById = function () {
            if (!angular.isUndefined($scope.Goal.GoalId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/Api/GoalApi?GoalId=" + $scope.Goal.GoalId.GoalId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.GoalTargets = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.GoalTargets = {};
            }
        }

        $scope.LoadPillars = function () {
            $http({
                method: "GET", url: "/api/PillarApi/GetAllPillarsByOrganization"
            }).then(function successCallback(data, status, headers, config) {
                $scope.Pillar = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadGoal = function () {

            if (!angular.isUndefined($scope.Pillar.PillarId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/GoalApi/GetGoalByPillarId?PillarId=" + $scope.Pillar.PillarId.PillarId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.Goal = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.Goal = {};
            }
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

        $scope.LoadPillars();

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
                "IsActive": "false",
                "RowCount": ""
            };
        }

    }
})();
