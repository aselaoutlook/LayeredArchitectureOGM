(function () {
    'use strict';

    var app = angular
                .module('app')
                .controller('OwnerViewModel', OwnerViewModel);

    OwnerViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar', 'toastr'];

    function OwnerViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar, toastr) {
        var vm = this;
        $scope.Owner = {
            "UserId": "",
            "FirstName": "",
            "MiddleInitial": "",
            "LastName": "",
            "UserName": "",
            "Password": "",
            "Email": "",
            "Mobile": "",
            "EmployeeUser": [{
                "BusinessPhone": "",
                "Country": "",
                "AddressOne": "",
                "AddressTwo": "",
                "City": "",
                "State": "",
                "Zip": "",
                "Notes": "",
                "IsViewOnly": "",
                "IsActionPlanOwner": "",
                "IsStrategicDriverOwner": "",
                "IsGoalOwner": "",
                "IsBusinessUnitLead": ""
            }],
            "OwnedEmployeeStrategies": [{
                "StrategicDriverId": "",
                "IsViewOnly": "",
                "IsActionPlanOwner": "",
                "IsStrategicDriverOwner": "",
                "IsGoalOwner": "",
                "IsBusinessUnitLead": ""
            }],
            "IsActive": "false",
            "Image": ""
        };

        $scope.StrategicDriver = {
            "StrategicDriverId": "",
            "Name": "",
            "RowCount": ""
        };


        $scope.StrategicDrivers = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/StrategicDriverApi/GetAllActiveStrategicDrivers"
            }).then(function successCallback(response, status, headers, config) {
                $scope.StrategicDriver = response.data;
                cfpLoadingBar.complete();
            });
        }

        $scope.LoadStrategyEmployees = function () {
            if (!($scope.StrategicDriverId === null)) {
                if (!angular.isUndefined($scope.StrategicDriverId)) {
                    $scope.LoadRecordsByStrategy();
                }
                else {
                    $scope.LoadAllRecords();
                }
            }
            else {
                $scope.LoadAllRecords();
            }
        }

        $scope.Owners = {};

        $scope.$watch("Owners", function () {
            $scope.Owner.RowCount = $scope.Owners.length;
        });

        $scope.Save = function () {
            cfpLoadingBar.start();
            if ($scope.Owner.UserId == '' || angular.isUndefined($scope.Owner.UserId)) {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }

        $scope.Add = function () {
            var postData = {
                FirstName: $scope.Owner.FirstName,
                MiddleInitial: $scope.Owner.MiddleInitial,
                LastName: $scope.Owner.LastName,
                UserName: $scope.Owner.UserName,
                Password: $scope.Owner.Password,
                Email: $scope.Owner.Email,
                Mobile: $scope.Owner.Mobile,
                EmployeeUser: [{
                    BusinessPhone: $scope.Owner.EmployeeUser[0].BusinessPhone,
                    Country: $scope.Owner.EmployeeUser[0].Country,
                    AddressOne: $scope.Owner.EmployeeUser[0].AddressOne,
                    AddressTwo: $scope.Owner.EmployeeUser[0].AddressTwo,
                    City: $scope.Owner.EmployeeUser[0].City,
                    State: $scope.Owner.EmployeeUser[0].State,
                    Zip: $scope.Owner.EmployeeUser[0].Zip,
                    IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
                    IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
                    IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
                    IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
                    IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
                }],
                OwnedEmployeeStrategies: [{
                    StrategicDriverId: $scope.StrategicDriverId.StrategicDriverId,
                    IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
                    IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
                    IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
                    IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
                    IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
                    IsActive: $scope.Owner.IsActive,
                }],
                IsActive: $scope.Owner.IsActive,
                Image: $scope.Image
            }

            $http({
                method: "POST", data: postData, url: "/Api/OwnersApi"
            }).then(function successCallback(response, status, headers, config) {
                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Owners = response;
                $scope.Image = null;
                $scope.ShowAlert('success', SystemMessages.InfoRecordAdded);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.Update = function () {

            //$scope.Owner.Image = $scope.Image
            //$scope.Owner.OwnedEmployeeStrategies = [{
            //    StrategicDriverId: $scope.StrategicDriverId.StrategicDriverId,
            //    IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
            //    IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
            //    IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
            //    IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
            //    IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
            //    IsActive: $scope.Owner.IsActive,
            //}];
            //$scope.Owner
            var postData = "";

            if ($scope.StrategicDriverId === undefined) {
                postData = {
                    UserId: $scope.Owner.UserId,
                    FirstName: $scope.Owner.FirstName,
                    MiddleInitial: $scope.Owner.MiddleInitial,
                    LastName: $scope.Owner.LastName,
                    UserName: $scope.Owner.UserName,
                    Password: $scope.Owner.Password,
                    Email: $scope.Owner.Email,
                    Mobile: $scope.Owner.Mobile,
                    EmployeeUser: [{
                        //EmployeeId: $scope.Owner.EmployeeUser[0].EmployeeId,
                        BusinessPhone: $scope.Owner.EmployeeUser[0].BusinessPhone,
                        Country: $scope.Owner.EmployeeUser[0].Country,
                        AddressOne: $scope.Owner.EmployeeUser[0].AddressOne,
                        AddressTwo: $scope.Owner.EmployeeUser[0].AddressTwo,
                        City: $scope.Owner.EmployeeUser[0].City,
                        State: $scope.Owner.EmployeeUser[0].State,
                        Zip: $scope.Owner.EmployeeUser[0].Zip,
                        IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
                        IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
                        IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
                        IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
                        IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
                    }],
                    
                    IsActive: $scope.Owner.IsActive,
                    Image: $scope.Image
                }
            }
            else {
                postData = {
                    UserId: $scope.Owner.UserId,
                    FirstName: $scope.Owner.FirstName,
                    MiddleInitial: $scope.Owner.MiddleInitial,
                    LastName: $scope.Owner.LastName,
                    UserName: $scope.Owner.UserName,
                    Password: $scope.Owner.Password,
                    Email: $scope.Owner.Email,
                    Mobile: $scope.Owner.Mobile,
                    EmployeeUser: [{
                        //EmployeeId: $scope.Owner.EmployeeUser[0].EmployeeId,
                        BusinessPhone: $scope.Owner.EmployeeUser[0].BusinessPhone,
                        Country: $scope.Owner.EmployeeUser[0].Country,
                        AddressOne: $scope.Owner.EmployeeUser[0].AddressOne,
                        AddressTwo: $scope.Owner.EmployeeUser[0].AddressTwo,
                        City: $scope.Owner.EmployeeUser[0].City,
                        State: $scope.Owner.EmployeeUser[0].State,
                        Zip: $scope.Owner.EmployeeUser[0].Zip,
                        IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
                        IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
                        IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
                        IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
                        IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
                    }],
                    OwnedEmployeeStrategies: [{
                        StrategicDriverId: $scope.StrategicDriverId.StrategicDriverId,
                        IsViewOnly: $scope.Owner.EmployeeUser[0].IsViewOnly,
                        IsActionPlanOwner: $scope.Owner.EmployeeUser[0].IsActionPlanOwner,
                        IsStrategicDriverOwner: $scope.Owner.EmployeeUser[0].IsStrategicDriverOwner,
                        IsGoalOwner: $scope.Owner.EmployeeUser[0].IsGoalOwner,
                        IsBusinessUnitLead: $scope.Owner.EmployeeUser[0].IsBusinessUnitLead,
                        IsActive: $scope.Owner.IsActive,
                    }],
                    IsActive: $scope.Owner.IsActive,
                    Image: $scope.Image
                }
            }

            

            $http({
                method: "PUT", data: postData, url: "/Api/OwnersApi"
            }).then(function successCallback(response, status, headers, config) {

                vm.tableParams = new ngTableParams({
                    page: 1,
                    count: 10
                },
                {
                    dataset: response.data.Items
                });

                $scope.Owners = response;
                $scope.Image = null;
                $scope.ShowAlert('success', SystemMessages.InfoRecordUpdated);
                cfpLoadingBar.complete();
                $scope.Reset();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.person = {
            author: $scope.author,
            category: $scope.category,
            quotes: [{ quote: $scope.quote }]
        };

        $scope.Clear = function () {
            $scope.Reset();
        }

        $scope.LoadById = function (UserId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/OwnersApi?UserId=" + UserId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Owner = data.data;
                $scope.Image = data.data["Image"];
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.LoadByUserIdAndStrategyId = function (UserId) {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/OwnersApi?UserId=" + UserId
            }).then(function successCallback(data, status, headers, config) {
                $scope.Owner = data.data;
                $scope.Image = data.data["Image"];
                cfpLoadingBar.complete();
            }, function errorCallback(response) {
                $scope.HandleErrors(response);
            });
        }

        $scope.ShowEmployeeSearchDiv = function () {
            if (!angular.isUndefined($scope.StrategicDriverId)) {
                return true;
            } else {
                return false;
            }
        };

        vm.clear = function () {
            vm.SearchUsers.settings().dataset = [];
            vm.SearchUsers.reload();
        }

        $scope.search = function () {
            //alert('1');
            //cfpLoadingBar.start();
            //$http({
            //    method: "GET", url: "/Api/OwnersApi/GetUsersForOwnersSearch?SdId=" + $scope.Owner.StrategicDriverId.StrategicDriverId + "&Key=" + $scope.keywords
            //}).then(function successCallback(data, status, headers, config) {
            //    //$scope.status = status;
            //    //$scope.data = data;
            //    //$scope.result = data;
            //    alert('2');
            //    //var self = this;
            //    //var data = [{ name: "Moroni", age: 50 } /*,*/];
            //    //vm.SearchUsers = new ngTableParams({}, { dataset: data });

            //    //var self = this;
            //    //var data1 = [{ name: "Moroni", age: 50 } /*,*/];
            //    alert("<pre>" + data + "</pre>");
            //    vm.SearchUsers = new ngTableParams({}, { dataset: data });

            //}, function errorCallback(response) {
            //    alert('3');
            //    $scope.HandleErrors(response);
            //});
            //alert('4');

            

            vm.SearchUsers = new ngTableParams({
                page: 1,
                count: 10
            },
            {
                counts: [],
                getData: function ($defer, params) {
                    cfpLoadingBar.start();
                    Restangular.all("OwnersApi/GetUsersForOwnersSearch?SdId=" + $scope.StrategicDriverId.StrategicDriverId + "&Key=" + $scope.keywords).getList({
                        //pageNo: params.page(),
                        //pageSize: params.count(),
                        //SdId: $scope.Owner.StrategicDriverId.StrategicDriverId
                    }).then(function (owners) {
                        //params.total(owners.paging.totalRecordCount);
                        $defer.resolve(owners);
                        cfpLoadingBar.complete();
                    }, function (response) {
                        $scope.HandleErrors(response);
                    });
                }
            });

            //alert('6');

            //$http.post($scope.url, { "data": $scope.keywords }).
            //success(function (data, status) {
            //    $scope.status = status;
            //    $scope.data = data;
            //    $scope.result = data;
            //})
            //.
            //error(function (data, status) {
            //    $scope.data = data || "Request failed";
            //    $scope.status = status;
            //});
        };

        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10
        },
        {
            getData: function ($defer, params) {
                cfpLoadingBar.start();
                Restangular.all('OwnersApi').getList({
                    pageNo: params.page(),
                    pageSize: params.count()
                }).then(function (owners) {
                    params.total(owners.paging.totalRecordCount);
                    $defer.resolve(owners);
                    $scope.StrategicDrivers();
                    cfpLoadingBar.complete();
                }, function (response) {
                    $scope.HandleErrors(response);
                });
            }
        });

        $scope.LoadAllRecords = function () {
            vm.tableParams = new ngTableParams({
                page: 1,
                count: 10
            },
            {
                getData: function ($defer, params) {
                    cfpLoadingBar.start();
                    Restangular.all('OwnersApi').getList({
                        pageNo: params.page(),
                        pageSize: params.count()
                    }).then(function (owners) {
                        params.total(owners.paging.totalRecordCount);
                        $defer.resolve(owners);
                        cfpLoadingBar.complete();
                    }, function (response) {
                    });
                }
            });
        }

        $scope.LoadRecordsByStrategy = function () {
            vm.tableParams = new ngTableParams({
                page: 1,
                count: 10
            },
            {
                getData: function ($defer, params) {
                    cfpLoadingBar.start();
                    Restangular.all('OwnersApi/GetAllActiveStrategicDriverEmployees').getList({
                        pageNo: params.page(),
                        pageSize: params.count(),
                        SdId: $scope.StrategicDriverId.StrategicDriverId
                    }).then(function (owners) {
                        params.total(owners.paging.totalRecordCount);
                        $defer.resolve(owners);
                        cfpLoadingBar.complete();
                    }, function (response) {
                    });
                }
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
            $scope.frmCreateOwner.$setPristine();
            $scope.frmCreateOwner.$setUntouched();
            $scope.Owner = {
                "UserId": "",
                "FirstName": "",
                "MiddleInitial": "",
                "LastName": "",
                "UserName": "",
                "Password": "",
                "Email": "",
                "Mobile": "",
                "EmployeeUser": [{
                    "BusinessPhone": "",
                    "Country": "",
                    "AddressOne": "",
                    "AddressTwo": "",
                    "City": "",
                    "State": "",
                    "Zip": "",
                    "Notes": "",
                    "IsViewOnly": "",
                    "IsActionPlanOwner": "",
                    "IsStrategicDriverOwner": "",
                    "IsGoalOwner": "",
                    "IsBusinessUnitLead": ""
                }],
                "IsActive": "false",
                "Image": ""
            };
            $scope.Image = null;
        }

        // upload files 
        var formdata = new FormData();

        $scope.uploadImage = function ($files) {
            cfpLoadingBar.start();
            
            angular.forEach($files, function (value, key) {
                formdata.set(key, value);
            });

            console.log(formdata);

            var request = {
                method: 'POST',
                url: '/Api/OwnersApi/UploadFiles',
                data: formdata,
                headers: {
                    'Content-Type': undefined
                }
            };

            $http(request).success(function (d) {
                $scope.Image = d;
            }).error(function () {
                $scope.ShowAlert('error', 'Failed, Please try again');
            });

            cfpLoadingBar.complete();
        };

        //remove files
        $scope.removeFile = function (event) {
            var name = event.target.id;
            if (name == 'Image')
                $scope.Image = null;

        };
    }

    // ngfiles directive
    app.directive('ngFiles', ['$parse', function ($parse) {
        function fn_link(scope, element, attrs) {
            var onChange = $parse(attrs.ngFiles);
            element.on('change', function (event) {
                onChange(scope, { $files: event.target.files });
            });
        };
        return {
            link: fn_link
        }
    }]);

})();