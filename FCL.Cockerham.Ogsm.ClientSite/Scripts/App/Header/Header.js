(function () {
    'use strict';

    angular
        .module('app')
        .controller('HeaderViewModel', HeaderViewModel);

    HeaderViewModel.$inject = ['$scope', '$http', 'Restangular', 'ngTableParams', 'cfpLoadingBar'];

    function HeaderViewModel($scope, $http, Restangular, ngTableParams, cfpLoadingBar) {
        var vm = this;

        $scope.Header = {
            "UserId": "",
            "FirstName": "",
            "MiddleInitial": "",
            "LastName": "",
            "UserName": "",
            "CompanyLogo": "",
            "UserImage" : ""
        };

        $scope.Header = {};

        $scope.LoadHeaderDetails = function () {
            cfpLoadingBar.start();
            $http({
                method: "GET", url: "/Api/OwnersApi/GetLoggedInUserDetailsForHeader"
            }).then(function successCallback(data, status, headers, config) {
                $scope.Header = data.data;
                cfpLoadingBar.complete();
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

        $scope.LoadHeaderDetails();
    }
})();