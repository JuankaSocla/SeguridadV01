(function () {
    //alert("dddd");
})();

var app = angular.module('angularFormsApp_02', ['ngGrid', 'ngAnimate', 'ui.bootstrap']);

app.controller('efUsuarioController', function ($scope, $http, $uibModal) {
    //debugger;
    //alert("zzzzaaa");

    $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };

    $scope.totalServerItems = 0;
    $scope.pagingOptions = {
        pageSizes: [15, 30, 45, 60],
        pageSize: 15,
        currentPage: 1
    };

    $scope.setPagingData = function (data, page, pageSize) {
        //debugger;
        var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
        //$scope.dataLoaded = true;
        $scope.myData = pagedData;
        $scope.totalServerItems = data.length;
        if (!$scope.$$phase) {
            $scope.$apply();
        }

    };

    $scope.getPagedDataAsync = function (pageSize, page, searchText) {
        //debugger;
        setTimeout(function () {

            var data;
            if (searchText) {
                var ft = searchText.toLowerCase();

                //$scope.dataLoaded = false;
                var data01 = "{CO_USUA : '" + $("#txtCOD_USUA").val() + "'}";

                var enter = $.ajax({
                    url: "../../../Usuario/fn_Listar",
                    type: "POST",
                    contentType: "application/json",
                    data: data01,
                    async: false,
                    success: function (response) {
                        data = response.filter(function (item) {
                            return JSON.stringify(item).toLowerCase().indexOf(ft) != -1;
                        });
                        $scope.setPagingData(data, page, pageSize);

                    },
                    error: function (request, status, error) {
                        alert("fail pantalla inicial");
                    }
                });
            } else {

                var data01 = "{CO_USUA : '" + $("#txtCOD_USUA").val() + "'}";
                //$scope.dataLoaded = false;
                var enter = $.ajax({
                    url: "../../../Usuario/fn_Listar",
                    type: "POST",
                    contentType: "application/json",
                    data: data01,
                    async: false,
                    success: function (response) {
                        $scope.setPagingData(response, page, pageSize);
                    },
                    error: function (request, status, error) {
                        alert("fail pantalla inicial");
                    }
                });
            }
        }, 100);
    };

    $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

    $scope.$watch('pagingOptions', function (newVal, oldVal) {
        //if (newVal !== oldVal && newVal.currentPage !== oldVal.currentPage) {
        if (newVal !== oldVal) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    $scope.$watch('filterOptions', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    $scope.Consultar = function (CO_USUA) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalUsuario.html',
            controller: 'ModalUsuarioCtrl',
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
        //alert("CO_USUA " + CO_USUA);
    }

    $scope.gridOptions = {
        data: 'myData',
        columnDefs: [
                    {
                      field: 'CO_USUA',
                      displayName: '',
                      name : 'Action',
                      cellEditableCondition: false,
                      width: "40px",
                      cellTemplate: '<button type="button" style="background-color:#EEEEEE;border:1px solid black;" class="btn fa fa-search" ng-click="Consultar(row.entity.CO_USUA)">'
                    },
                    { field: 'CO_USUA', displayName: 'Usuario', width: "*" },
                    { field: 'PERSONA[0].NO_USUA_COMP', displayName: 'Persona', width: "**", enableCellEdit: false },
                    { field: 'SEGU_ROLE[0].NO_ROLE', displayName: 'Rol', width: "*" },
                    { field: 'SEGU_ROLE[0].DE_ROLE', displayName: 'Descripción', width: "**" }
                    
                    
        ],
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        //plugins: [new ngGridCsvExportPlugin()],
    };
    
});

app.controller('ModalUsuarioCtrl', function ($scope, $uibModalInstance) {

});