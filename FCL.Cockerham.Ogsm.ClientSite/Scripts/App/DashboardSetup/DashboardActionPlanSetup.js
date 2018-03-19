(function () {
    'use strict';

    angular
        .module('app')
        .controller('ActionPlanViewModel', ActionPlanViewModel);

    ActionPlanViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr'];

    function ActionPlanViewModel($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr) {
        var vm = this;
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
        $scope.Pillar = {
            "PillarId": "",
            "Name": ""
        };
        $scope.Goal = {
            "GoalId": "",
            "Name": ""
        };

        $scope.StrategicDriver = {
            "StrategicDriverId": "",
            "Name": ""
        };

        $scope.ActionPlanOwner = {
            "UserId": "",
            "FirstName": "",
            "LastName": "",
            "MiddleInitial": "",
            "RowCount": ""
        };

        //$scope.ActionPlan = {};

        $scope.$watch("ActionPlan", function () {
            $scope.ActionPlan.RowCount = $scope.ActionPlan.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.ActionPlan.ActionPlanId == '' || angular.isUndefined($scope.ActionPlan.ActionPlanId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var actionPlanComment;
            if (angular.isUndefined($scope.ActionPlan.ActionPlanComments)) {
                actionPlanComment = "";
            } else {
                actionPlanComment = $scope.ActionPlan.ActionPlanComments[0].Comment;
            }

            var postData = {
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
                    Comment: actionPlanComment
                }]
            }
            $http({
                method: "POST", data: postData, url: "/Api/ActionPlanApi"
            }).then(function successCallback(response, status, headers, config) {

                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.ActionPlan = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
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

                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.ActionPlan = response;
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

        $scope.LoadById = function (ActionPlanId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/ActionPlanApi?ActionPlanId=" + ActionPlanId
            }).then(function successCallback(data, status, headers, config) {
                $scope.ActionPlan = data.data;
                $scope.ActionPlan.PillarId = data.data.Pillar;
                $scope.LoadGoal();
                $scope.ActionPlan.GoalId = data.data.Goal;
                $scope.LoadStrategicDriver();
                $scope.ActionPlan.StrategicDriverId = data.data.StrategicDriver;
                $scope.LoadSelectedStrategicDriver();
                $scope.ActionPlan.ActionPlanOwnerId = data.data.ActionPlanOwner;
                $scope.StrategicDriver.StartDate = new Date($filter('date')($scope.ActionPlan.StrategicDriver.StartDate, 'yyyy-MM-dd'));
                $scope.StrategicDriver.EndDate = new Date($filter('date')($scope.ActionPlan.StrategicDriver.EndDate, 'yyyy-MM-dd'));
                $scope.ActionPlan.DueDate = new Date($filter('date')($scope.ActionPlan.DueDate, 'yyyy-MM-dd'));
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
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

        $scope.LoadGoal = function () {

            if (!angular.isUndefined($scope.ActionPlan.PillarId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/GoalApi/GetGoalByPillarId?PillarId=" + $scope.ActionPlan.PillarId.PillarId
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

        $scope.LoadStrategicDriver = function () {
            if (!angular.isUndefined($scope.ActionPlan.GoalId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByGoalId?goalId=" + $scope.ActionPlan.GoalId.GoalId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.StrategicDriver = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.StrategicDriver = {};
            }
        }

        $scope.LoadSelectedStrategicDriver = function () {
            if (!angular.isUndefined($scope.ActionPlan.StrategicDriverId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/StrategicDriverApi?StrategicDriverId=" + $scope.ActionPlan.StrategicDriverId.StrategicDriverId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.StrategicDriver.StartDate = data.data.StartDate;
                    $scope.StrategicDriver.EndDate = data.data.EndDate;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.StrategicDriver = {};
            }
        }

        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                cfpLoadingBar.start();
                Restangular.all('ActionPlanApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (businessUnits) {
                    params.total(businessUnits.paging.totalRecordCount);
                    $defer.resolve(businessUnits);
                    $scope.LoadPillars();
                    $scope.LoadActiveGoalOwners();
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
            $scope.frmCreateActionPlan.$setPristine();
            $scope.frmCreateActionPlan.$setUntouched();
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
        }

        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };


        $scope.popup2 = {
            opened: false
        };


    }
})();