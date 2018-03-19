(function () {
    'use strict';

    var app = angular.module('app', [
        'restangular',
        'ngTable',
        'ngAnimate',
        'ui.bootstrap',
        'chieffancypants.loadingBar',
        'toastr'
    ])
    .config(restangularConfig)
    .config(function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = true;
    })
    .config(function (toastrConfig) {
        angular.extend(toastrConfig, {
            autoDismiss: true,
            closeButton: true,
            progressBar: true,
            containerId: 'toast-container',
            maxOpened: 0,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            target: 'body'
        });
    });

    restangularConfig.$inject = ['RestangularProvider'];

    function restangularConfig(RestangularProvider) {
        RestangularProvider.setBaseUrl('/Api');

        RestangularProvider.addResponseInterceptor(function (data, operation, what, url, response, deferred) {

            var extractedData;
            if (operation === "getList") {
                extractedData = data.Items;
                extractedData.paging =
                {
                    pageCount: data.PageCount,
                    pageNo: data.PageNo,
                    pageSize: data.PageSize,
                    totalRecordCount: data.TotalRecordCount
                };
            } else {
                extractedData = data;
            }
            return extractedData;
        });
    };

})();