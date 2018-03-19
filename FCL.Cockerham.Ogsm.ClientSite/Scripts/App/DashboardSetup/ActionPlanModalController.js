(function () {
    'use strict';

    var app = angular
          .module('app')
          .controller('ActionPlanModalController', ActionPlanModalController);

    ActionPlanModalController.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr', '$uibModalInstance', 'ActionPlanId'];

    function ActionPlanModalController($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr, $uibModalInstance, ActionPlanId) {

        $scope.ActionPlan = {
            "ActionPlanId": "",
            "GoalId": "",
            "PillarId": "",
            "StrategicDriverId": "",
            "OrganizationId": "",
            "Name": "",
            "ActionPlanOwnerId": "",
            "IsEvent": "",
            "IsCalendarEvent": "",
            "DueDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "PlannedCost": "",
            "ActualCost": "",
            "Impact": "",
            "SequenceNumber": "",
            "CalendarEvents": [{
                "Name": "",
                "Description": "",
                "Location": "",
                "DueDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "GoalId": "",
                "PillarId": "",
                "StrategicDriverId": ""
            }],
            "ActionPlanComments": [{
                "Comment": ""
            }],
            "RowCount": ""
        };

        $scope.ApPillar = {
            "PillarId": "",
            "Name": ""
        };

        $scope.ApGoal = {
            "GoalId": "",
            "Name": ""
        };

        $scope.ApActionPlanOwner = {
            "UserId": "",
            "FirstName": "",
            "LastName": "",
            "MiddleInitial": "",
            "RowCount": ""
        };

        $scope.ApStrategicDriver = {
            "StrategicDriverId": "",
            "Name": "",
            "StartDate": "",
            "EndDate": ""
        };

        $scope.ActionPlanId = ActionPlanId;

        $scope.LoadActionPlanById = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/ActionPlanApi?ActionPlanId=" + $scope.ActionPlanId
            }).then(function successCallback(data, status, headers, config) {
                $scope.ActionPlan = data.data;
                $scope.LoadApPillars();
                $scope.ActionPlan.PillarId = data.data.Pillar;
                $scope.LoadApGoal();
                $scope.ActionPlan.GoalId = data.data.Goal;
                $scope.LoadApStrategicDriver();
                $scope.ActionPlan.StrategicDriverId = data.data.StrategicDriver;
                $scope.LoadApSelectedStrategicDriver();
                $scope.LoadApActiveGoalOwners();
                $scope.ActionPlan.ActionPlanOwnerId = data.data.ActionPlanOwner;
                $scope.ActionPlan.DueDate = new Date($filter('date')($scope.ActionPlan.DueDate, 'yyyy-MM-dd'));
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadApPillars = function () {
            $http({
                method: "GET", url: "/api/PillarApi/GetAllPillarsByOrganization"
            }).then(function successCallback(data, status, headers, config) {
                $scope.ApPillar = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadApGoal = function () {

            if (!angular.isUndefined($scope.ActionPlan.PillarId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/GoalApi/GetGoalByPillarId?PillarId=" + $scope.ActionPlan.PillarId.PillarId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.ApGoal = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.Goal = {};
            }
        }

        $scope.LoadApStrategicDriver = function () {
            if (!angular.isUndefined($scope.ActionPlan.GoalId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByGoalId?goalId=" + $scope.ActionPlan.GoalId.GoalId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.ApStrategicDriver = data.data;
                    $scope.ApStrategicDriver.StartDate = new Date($filter('date')(data.data[0].StartDate, 'yyyy-MM-dd'));
                    $scope.ApStrategicDriver.EndDate = new Date($filter('date')(data.data[0].EndDate, 'yyyy-MM-dd'));
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.ApStrategicDriver = {};
            }
        }

        $scope.LoadApSelectedStrategicDriver = function () {
            if (!angular.isUndefined($scope.ActionPlan.StrategicDriverId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/StrategicDriverApi?StrategicDriverId=" + $scope.ActionPlan.StrategicDriverId.StrategicDriverId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.ApStrategicDriver.StartDate = new Date($filter('date')(data.data.StartDate, 'yyyy-MM-dd'));
                    $scope.ApStrategicDriver.EndDate = new Date($filter('date')(data.data.EndDate, 'yyyy-MM-dd'));
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.ApStrategicDriver = {};
            }
        }

        $scope.LoadApActiveGoalOwners = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/OwnersApi/GetActiveGoalOwnersByOrganization"
            }).then(function successCallback(data, status, headers, config) {
                $scope.ApOwners = data.data;
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Save = function () {
            cfpLoadingBar.start();
            var postData = {
                ActionPlanId: $scope.ActionPlan.ActionPlanId,
                Name: $scope.ActionPlan.Name,
                PillarId: $scope.ActionPlan.PillarId.PillarId,
                GoalId: $scope.ActionPlan.GoalId.GoalId,
                StrategicDriverId: $scope.ActionPlan.StrategicDriverId.StrategicDriverId,
                ActionPlanOwnerId: $scope.ActionPlan.ActionPlanOwnerId.UserId,
                IsEvent: $scope.ActionPlan.IsEvent,
                IsCalendarEvent: $scope.ActionPlan.IsCalendarEvent,
                DueDate: $scope.ActionPlan.DueDate,
                PlannedCost: $scope.ActionPlan.PlannedCost,
                ActualCost: $scope.ActionPlan.ActualCost,
                Impact: $scope.ActionPlan.Impact,
                SequenceNumber: $scope.ActionPlan.SequenceNumber,
                CalendarEvents: [{
                    Name: $scope.ActionPlan.CalendarEvents[0].Name,
                    Description: $scope.ActionPlan.CalendarEvents[0].Description,
                    Location: $scope.ActionPlan.CalendarEvents[0].Location,
                    DueDate: $scope.ActionPlan.DueDate,
                    PillarId: $scope.ActionPlan.PillarId.PillarId,
                    GoalId: $scope.ActionPlan.GoalId.GoalId,
                    StrategicDriverId: $scope.ActionPlan.StrategicDriverId.StrategicDriverId
                }],
                ActionPlanComments: [{
                    Comment: $scope.ActionPlan.ActionPlanComments[0].Comment
                }]
            }
            $http({
                method: "PUT", data: postData, url: "/Api/ActionPlanApi"
            }).then(function successCallback(response, status, headers, config) {
                $scope.ActionPlan = {
                    "ActionPlanId": "",
                    "GoalId": "",
                    "PillarId": "",
                    "StrategicDriverId": "",
                    "OrganizationId": "",
                    "Name": "",
                    "ActionPlanOwnerId": "",
                    "IsEvent": "",
                    "IsCalendarEvent": "",
                    "DueDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                    "PlannedCost": "",
                    "ActualCost": "",
                    "Impact": "",
                    "SequenceNumber": "",
                    "CalendarEvents": [{
                        "Name": "",
                        "Description": "",
                        "Location": "",
                        "DueDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                        "GoalId": "",
                        "PillarId": "",
                        "StrategicDriverId": ""
                    }],
                    "ActionPlanComments": [{
                        "Comment": ""
                    }],
                    "RowCount": ""
                };

                $scope.frmCreateActionPlan.$setUntouched();                
                cfpLoadingBar.complete();
                $uibModalInstance.close(response);
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };

        $scope.popup2 = {
            opened: false
        };

        $scope.LoadActionPlanById();
    }

})();