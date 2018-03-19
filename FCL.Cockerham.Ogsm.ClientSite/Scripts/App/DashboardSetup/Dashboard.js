(function () {
    'use strict';

    var app = angular
                .module('app')
                .controller('DashboardController', DashboardController);

    DashboardController.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr', '$uibModal'];

    function DashboardController($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr, $uibModal) {
        var vm = this;
        $scope.animationsEnabled = true;

        //------------ Dashboard Models ------------//
        $scope.Dashboard = {
            "ddlBusinessUnitId": "",
            "ddlStTypeId": "",
            "ddlPillarId": "",
            //"ddlGoalCategoryId": "",
            "ddlGoalId": "",
            "ddlStrategicDriverId": "",
            "Metric": ""
        };

        $scope.BusinessUnit = {
            "BusinessUnitId": "",
            "Name": ""
        };

        $scope.StType = {
            "StTypeId": "",
            "Name": ""
        };

        $scope.Pillar = {
            "PillarId": "",
            "Name": ""
        };

        //$scope.GoalCategory = {
        //    "GoalCategoryId": "",
        //    "Name": "",
        //};

        $scope.Goal = {
            "GoalId": "",
            "Name": ""
        };

        $scope.Metric = {
            "StrategicDriverId": "",
            "Name": "",
            "Metric": "",
        };

        $scope.StrategicDriverForMetricUpdate = {
            "StrategicDriverId": "",
            "Name": "",
            "PillarId": "",
            "StTypeId": "",
            "StartDate": "",
            "EndDate": "",
            "GoalId": "",
            "Metric": "",
            "MetricTarget": "",
            "IsMetricDefault": "",
            "IsIndexed": "",
            "IsActive": "false",
            "WeightActionPlan": "",
            "WeightMetric": "",
            "OwnerId": "",
            "StrategicDriverTargets": [{
                "StrategicDriverTargetId": "",
                "StrategicDriverId": "",
                "OrganizationId": "",
                "QuaterName": "",
                "QuaterValue": "",
                "BeginDate": "",
                "EndDate": "",
                "IsActive": ""
            }],
            "RowCount": ""
        };

        //------------ Dashboard Action Plan Models ------------//

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
            "DueDate": "",
            "PlannedCost": "",
            "ActualCost": "",
            "Impact": "",
            "ActionStatus": [{
                "ActionStatusId": "",
                "Status": "",
                "colorcode": ""
            }],
            "CalendarEvents": [{
                "Name": "",
                "Description": "",
                "Location": "",
                "DueDate": "",
                "GoalId": "",
                "PillarId": "",
                "StrategicDriverId": ""
            }],
            "ActionPlanComments": [{
                "Comment": ""
            }],
            "RowCount": ""
        };

        $scope.ApActionStatus = {
            "ActionStatusId": "",
            "Status": "",
            "colorcode": "",
        };

        $scope.BusinessUnit = [
            { Name: 'Select BusinessUnit', value: '' }
        ];

        $scope.StType = [
            { Name: 'Select Strategy Type', value: '' }
        ];

        $scope.Pillar = [
           { Name: 'Select Pillar', value: '' }
        ];

        $scope.GoalCategory = [
            { Name: 'Select Goal Category', value: '' }
        ];

        $scope.Goal = [
            { Name: 'Select Goal', value: '' }
        ];

        $scope.StrategicDriver = [
            { Name: 'Select Strategy', value: '' }
        ];

        $scope.LoadStTypes = function () {
            $http({
                //method: "GET", url: "/api/StTypeApi/GetStTypesByBusinessUnitId?BusinessUnitId=" + $scope.Dashboard.BusinessUnitId.BusinessUnitId
                method: "GET", url: "/api/StTypeApi/GetAllStTypes"
            }).then(function successCallback(data, status, headers, config) {
                $scope.StType = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadBusinessUnits = function () {
            if (!angular.isUndefined($scope.Dashboard.StTypeId)) {
                $http({
                    //method: "GET", url: "/api/BusinessUnitApi/GetAllBusinessUnits"
                    method: "GET", url: "/api/BusinessUnitApi/GetBusinessUnitsByStTypeId?StTypeId=" + $scope.Dashboard.StTypeId.StTypeId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.BusinessUnit = data.data;
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.BusinessUnit = {};
            }
        }

        $scope.LoadActionStatus = function () {
            $http({
                method: "GET", url: "/api/ActionPlanApi/GetAllActionStatus"
            }).then(function successCallback(data, status, headers, config) {
                $scope.ApActionStatus = data.data;
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadPillars = function () {
            if (!angular.isUndefined($scope.Dashboard.StTypeId)) {
                $http({
                    method: "GET", url: "/api/PillarApi/GetPillarsByStTypeId?StTypeId=" + $scope.Dashboard.StTypeId.StTypeId
                }).then(function successCallback(data, status, headers, config) {
                    $scope.Pillar = data.data;
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
            } else {
                $scope.Pillar = {};
            }
        }

        $scope.LoadGoal = function () {
            if (!angular.isUndefined($scope.Dashboard.PillarId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/GoalApi/GetGoalByPillarId?PillarId=" + $scope.Dashboard.PillarId.PillarId
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

        //$scope.LoadStrategicDrivers = function () {
        //    if (!angular.isUndefined($scope.Dashboard.GoalId)) {
        //        cfpLoadingBar.start();
        //        $http({
        //            //method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByGoalId?goalId=" + $scope.Dashboard.GoalId.GoalId
        //            method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByLoggedinUser"
        //        }).then(function successCallback(data, status, headers, config) {
        //            $scope.StrategicDriver = data.data;
        //            cfpLoadingBar.complete();
        //        }, function errorCallback(response) {
        //            $scope.HandleErrors(response);
        //        });
        //    } else {
        //        $scope.StrategicDriver = {};
        //        $scope.Dashboard.Metric = "";
        //        $scope.Dashboard.MetricTarget = "";
        //    }
        //}

        $scope.LoadStrategicDrivers = function () {            
                cfpLoadingBar.start();
                $http({
                    //method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByGoalId?goalId=" + $scope.Dashboard.GoalId.GoalId
                    method: "GET", url: "/api/StrategicDriverApi/GetStrategicDriverByLoggedinUser"
                }).then(function successCallback(data, status, headers, config) {
                    $scope.StrategicDriver = data.data;
                    cfpLoadingBar.complete();
                }, function errorCallback(response) {
                    $scope.HandleErrors(response);
                });
        }

        $scope.LoadStrategicDriverById = function () {
            if (!($scope.Dashboard.StrategicDriverId === null)) {
                if (!angular.isUndefined($scope.Dashboard.StrategicDriverId)) {
                    cfpLoadingBar.start();
                    $http({
                        method: "GET", url: "/Api/StrategicDriverApi?StrategicDriverId=" + $scope.Dashboard.StrategicDriverId.StrategicDriverId
                    }).then(function successCallback(data, status, headers, config) {
                        $scope.Dashboard.Metric = data.data["Metric"];
                        $scope.StrategicDriverForMetricUpdate = data.data;
                        $scope.LoadActionPlanGrid();
                        cfpLoadingBar.complete();
                    }, function errorCallback(response) {
                        $scope.Dashboard.Metric = "";
                        $scope.Dashboard.MetricTarget = "";
                    });
                } else {
                    $scope.Dashboard.Metric = "";
                    $scope.Dashboard.MetricTarget = "";
                }
            } else {
                $scope.Dashboard.Metric = "";
                $scope.Dashboard.MetricTarget = "";
            }
        }

        $scope.UpdateStrategicDriverTargets = function () {
            var putData = {
                StrategicDriverId: $scope.StrategicDriverForMetricUpdate.StrategicDriverId,
                Name: $scope.StrategicDriverForMetricUpdate.Name,
                PillarId: $scope.StrategicDriverForMetricUpdate.PillarId.PillarId,
                StartDate: $scope.StrategicDriverForMetricUpdate.StartDate,
                EndDate: $scope.StrategicDriverForMetricUpdate.EndDate,
                GoalId: $scope.StrategicDriverForMetricUpdate.GoalId.GoalId,
                Metric: $scope.StrategicDriverForMetricUpdate.Metric,
                MetricTarget: $scope.StrategicDriverForMetricUpdate.MetricTarget,
                IsMetricDefault: $scope.StrategicDriverForMetricUpdate.IsMetricDefault,
                IsIndexed: $scope.StrategicDriverForMetricUpdate.IsIndexed,
                IsActive: $scope.StrategicDriverForMetricUpdate.IsActive,
                WeightActionPlan: $scope.StrategicDriverForMetricUpdate.WeightActionPlan,
                WeightMetric: $scope.StrategicDriverForMetricUpdate.WeightMetric,
                StrategicDriverTargets: $scope.StrategicDriverForMetricUpdate.StrategicDriverTargets,
                OwnerId: $scope.StrategicDriverForMetricUpdate.OwnerId.UserId
            }

            $http({
                method: "PUT", data: putData, url: "/api/StrategicDriverApi/UpdateStrategicDriverTargets"
            }).then(function successCallback(response, status, headers, config) {
                $scope.ShowAlert('success', SystemMessages.InfoRecordUpdated);
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadActionPlanGrid = function () {
            $http({
                method: "GET", url: "/api/ActionPlanApi/GetActionPlansByStrategicDriverId?StrategicDriverId=" + $scope.Dashboard.StrategicDriverId.StrategicDriverId
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data
                });
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        };

        $scope.OpenActionPlanEditModal = function (actionPlanId) {
            var editActionPlanModal = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'editActionPlan.html',
                controller: 'ActionPlanModalController',
                size: 'lg',
                backdrop: false,
                resolve: {
                    ActionPlanId: function () {
                        return actionPlanId;
                    }
                }
            });

            editActionPlanModal.result.then(function (response) {
                $scope.LoadActionPlanGrid();
                $scope.ShowAlert('success', SystemMessages.InfoRecordUpdated);
            }, function () {
            });
        }

        //$scope.LoadStTypes();
        $scope.LoadStrategicDrivers();
        $scope.LoadActionStatus();

        $scope.ChangeActionStatus = function (actionPlanId, actionStatus) {
            cfpLoadingBar.start();
            var postData = {
                actionPlanId: actionPlanId,
                actionStatusId: actionStatus.ActionStatusId
            }

            $http({
                method: "PUT", url: "/api/ActionPlanApi/UpdateActionplanStatus?actionPlanId=" + actionPlanId + "&actionStatusId=" + actionStatus.ActionStatusId
            }).then(function successCallback(response, status, headers, config) {
                $scope.ShowAlert('success', SystemMessages.InfoRecordUpdated);
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        };

        $scope.ShowDetailsDiv = function () {
            //if (!angular.isUndefined($scope.Dashboard.GoalId)) {
            if (!angular.isUndefined($scope.Dashboard.StrategicDriverId)) {
                return true;
            } else {
                return false;
            }
        };

        $scope.ShowActionPlanGrid = function () {
            if (!angular.isUndefined($scope.Dashboard.StrategicDriverId)) {
                return true;
            } else {
                return false;
            }
        };

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
    }

    app.directive('actionPlanArea', function () {
        return {
            restrict: 'E',
            templateUrl: '/DashboardSetup/DashboardHomeActionPlanUi'
        };
    });
})();
