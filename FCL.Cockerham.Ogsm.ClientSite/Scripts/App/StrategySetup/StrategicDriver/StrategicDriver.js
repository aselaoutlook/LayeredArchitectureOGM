(function () {
    'use strict';

    angular
        .module('app')
        .controller('StrategicDriverViewModel', StrategicDriverViewModel);

    StrategicDriverViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', '$filter', 'cfpLoadingBar', 'toastr'];

    function StrategicDriverViewModel($scope, $http, Restangular, ngTableParams, $filter, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.StrategicDriver = {
            "StrategicDriverId": "",
            "Name": "",
            "FiscalYearId": "",
            "PillarId": "",
            "StartDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "EndDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
            "GoalId": "",
            "Metric": "",
            "MetricTarget": "",
            "SequenceNumber": "",
            "IsMetricDefault": "",
            "IsIndexed": true,
            "IsActive":false,
            "WeightActionPlan": "35",
            "WeightMetric":"65",
            "OwnerId": "",
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
        //$scope.StType = {
        //    "StTypeId": "",
        //    "Name": ""
        //};
        $scope.FiscalYear = {
            "FiscalYearId": "",
            "StartYear": "",
            "EndYear": ""
        };
        $scope.Owners = {
            "UserId": "",
            "FirstName": "",
            "LastName": "",
            "MiddleInitial": "",
            "RowCount": ""
        };

        //$scope.StrategicDriver = {};

        $scope.$watch("StrategicDriver", function () {
            $scope.StrategicDriver.RowCount = $scope.StrategicDriver.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.StrategicDriver.StrategicDriverId == '' || angular.isUndefined($scope.StrategicDriver.StrategicDriverId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                Name: $scope.StrategicDriver.Name,
                PillarId: $scope.StrategicDriver.PillarId.PillarId,
                //StTypeId: $scope.StrategicDriver.StTypeId.StTypeId,
                FiscalYearId: $scope.StrategicDriver.FiscalYearId.FiscalYearId,
                StartDate: $scope.StrategicDriver.StartDate,
                EndDate: $scope.StrategicDriver.EndDate,
                GoalId: $scope.StrategicDriver.GoalId.GoalId,
                Metric: $scope.StrategicDriver.Metric,
                MetricTarget: $scope.StrategicDriver.MetricTarget,
                IsMetricDefault: $scope.StrategicDriver.IsMetricDefault,
                IsIndexed: $scope.StrategicDriver.IsIndexed,
                IsActive: $scope.StrategicDriver.IsActive,
                WeightActionPlan: $scope.StrategicDriver.WeightActionPlan,
                WeightMetric: $scope.StrategicDriver.WeightMetric,
                SequenceNumber: $scope.StrategicDriver.SequenceNumber,
                OwnerId: $scope.StrategicDriver.OwnerId.UserId
            }
            $http({
                method: "POST", data: postData, url: "/Api/StrategicDriverApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.StrategicDriver = response;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {
            var postData = {
                StrategicDriverId: $scope.StrategicDriver.StrategicDriverId,
                Name: $scope.StrategicDriver.Name,
                PillarId: $scope.StrategicDriver.PillarId.PillarId,
                //StTypeId: $scope.StrategicDriver.StTypeId.StTypeId,
                FiscalYearId: $scope.StrategicDriver.FiscalYearId.FiscalYearId,
                StartDate: $scope.StrategicDriver.StartDate,
                EndDate: $scope.StrategicDriver.EndDate,
                GoalId: $scope.StrategicDriver.GoalId.GoalId,
                Metric: $scope.StrategicDriver.Metric,
                MetricTarget: $scope.StrategicDriver.MetricTarget,
                IsMetricDefault: $scope.StrategicDriver.IsMetricDefault,
                IsIndexed: $scope.StrategicDriver.IsIndexed,
                IsActive: $scope.StrategicDriver.IsActive,
                WeightActionPlan: $scope.StrategicDriver.WeightActionPlan,
                WeightMetric: $scope.StrategicDriver.WeightMetric,
                SequenceNumber: $scope.StrategicDriver.SequenceNumber,
                OwnerId: $scope.StrategicDriver.OwnerId.UserId
            }
            $http({
                method: "PUT", data: postData, url: "/Api/StrategicDriverApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.StrategicDriver = response;
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

        $scope.LoadById = function (StrategicDriverId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/StrategicDriverApi?StrategicDriverId=" + StrategicDriverId
            }).then(function successCallback(data, status, headers, config) {
                $scope.StrategicDriver = data.data;
                $scope.StrategicDriver.FiscalYearId = data.data.FiscalYear;
                $scope.StrategicDriver.PillarId = data.data.Pillar;
                //$scope.StrategicDriver.StTypeId = data.data.StType;
                $scope.LoadGoal();
                $scope.StrategicDriver.GoalId = data.data.Goal;
                $scope.StrategicDriver.OwnerId = data.data.Owner;
                $scope.StrategicDriver.StartDate = new Date($filter('date')($scope.StrategicDriver.StartDate, 'yyyy-MM-dd'));
                $scope.StrategicDriver.EndDate = new Date($filter('date')($scope.StrategicDriver.EndDate, 'yyyy-MM-dd'));
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

        //$scope.LoadStTypes = function () {
        //    $http({
        //        method: "GET", url: "/api/StTypeApi/GetAllStTypes"
        //    }).then(function successCallback(data, status, headers, config) {
        //        $scope.StType = data.data;
        //    }, function errorCallback(response) {
        //        $scope.HandleErrors(response);
        //    });
        //}

        $scope.LoadFiscalYears = function () {
            $http({
                method: "GET", url: "/api/FiscalYearApi/GetAllFiscalYears"
            }).then(function successCallback(data, status, headers, config) {
                $scope.FiscalYear = data.data;
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
   
            if (!angular.isUndefined($scope.StrategicDriver.PillarId)) {
                cfpLoadingBar.start();
                $http({
                    method: "GET", url: "/api/GoalApi/GetGoalByPillarId?PillarId=" + $scope.StrategicDriver.PillarId.PillarId
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
        
        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                cfpLoadingBar.start();
                Restangular.all('StrategicDriverApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (strategicDrivers) {
                    params.total(strategicDrivers.paging.totalRecordCount);
                    $defer.resolve(strategicDrivers);
                    $scope.LoadFiscalYears();
                    $scope.LoadPillars();
                    $scope.LoadActiveGoalOwners();
                    //$scope.LoadStTypes();
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
            $scope.frmCreateStrategicDriver.$setPristine();
            $scope.frmCreateStrategicDriver.$setUntouched();
            $scope.StrategicDriver = {
                "StrategicDriverId": "",
                "Name": "",
                "FiscalYearId": "",
                "PillarId": "",
                //"StTypeId": "",
                "StartDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "EndDate": new Date($filter('date')(new Date(), 'yyyy-MM-dd')),
                "GoalId": "",
                "Metric": "",
                "MetricTarget": "",
                "IsMetricDefault": "",
                "IsIndexed": true,
                "IsActive": false,
                "WeightActionPlan": "35",
                "WeightMetric": "65",
                "OwnerId": "",
                "SequenceNumber": "",
                "RowCount": ""
            };
        }

        $scope.CalculatWeightMetric = function () {
            $scope.StrategicDriver.WeightMetric = (100 - $scope.StrategicDriver.WeightActionPlan);
            
        }

        $scope.CalculatWeightActionPlan = function () {
            $scope.StrategicDriver.WeightActionPlan = (100 - $scope.StrategicDriver.WeightMetric);
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