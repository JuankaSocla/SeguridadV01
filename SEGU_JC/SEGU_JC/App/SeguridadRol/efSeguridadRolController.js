(function () {

})();

var app = angular.module('angularFormsApp_03', ['ngGrid', 'ngAnimate', 'ui.bootstrap']);

app.controller('efSeguridadRolController', function ($scope, $http, $uibModal) {
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

                var enter = $.ajax({
                    url: "../../../SeguridadRol/fn_Listar",
                    type: "POST",
                    contentType: "application/json",
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

                var enter = $.ajax({
                    url: "../../../SeguridadRol/fn_Listar",
                    type: "POST",
                    contentType: "application/json",
                    
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

    $scope.Consultar = function (ID_ROLE, CO_ROLE, NO_ROLE) {
        
        $("#hiID_ROLE").val(ID_ROLE);
        $("#hiCO_ROLE").val(CO_ROLE);
        $("#hiNO_ROLE").val(NO_ROLE);
        
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            //windowTemplateUrl: 'myModalSeguridadRol.html',
            templateUrl: 'myModalSeguridadRol.html',
            controller: 'ModalSeguridadRolCtrl',
            windowClass: 'custom-css-class',
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });

    }

    $scope.gridOptions = {
        data: 'myData',
        columnDefs: [
                    {
                        field: 'ID_ROLE',
                        displayName: '',
                        name: 'Action',
                        cellEditableCondition: false,
                        width: "40px",
                        cellTemplate: '<button type="button" style="background-color:#EEEEEE;border:1px solid black;" class="btn fa fa-search" ng-click="Consultar(row.entity.ID_ROLE,row.entity.CO_ROLE,row.entity.NO_ROLE)">'
                    },
                    { field: 'CO_ROLE', displayName: 'CODIGO', width: "*" },
                    { field: 'NO_ROLE', displayName: 'ROL', width: "**" },
                    { field: 'DE_ROLE', displayName: 'USUARIO', width: "**" },
        ],
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        //plugins: [new ngGridCsvExportPlugin()],
    };
});

app.controller('ModalSeguridadRolCtrl', function ($scope, $uibModalInstance) {

    $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };

    $scope.totalServerItems = 0;
    $scope.pagingOptions = {
        pageSizes: [10, 15, 20, 25],
        pageSize: 10,
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
                var data01 = "{ID_ROLE : '" + $("#hiID_ROLE").val() + "'}";
                var enter = $.ajax({
                    url: "../../../SeguridadRol/fn_Listar_Rol",
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
                        alert("fail Cargar los Roles");
                    }
                });
            } else {
                var data01 = "{ID_ROLE : '" + $("#hiID_ROLE").val() + "'}";
                var enter = $.ajax({
                    url: "../../../SeguridadRol/fn_Listar_Rol",
                    type: "POST",
                    contentType: "application/json",
                    data: data01,
                    async: false,
                    success: function (response) {
                        $scope.setPagingData(response, page, pageSize);
                    },
                    error: function (request, status, error) {
                        alert("fail Cargar los Roles");
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

    $scope.toggle = function (value) {
        //do something usefull here, you have the name and the new value of dude. Write it to a db or else. 

    }

    $scope.gridOptions_Rol = {
        data: 'myData',
        columnDefs: [
                    {
                        field: 'DE_SELE_01',
                        displayName: '',
                        name: 'Action',
                        cellEditableCondition: false,
                        width: "30px",
                        cellTemplate: '<input type="checkbox" ng-model="row.entity.DE_SELE_01" ng-click="toggle(row.entity.DE_SELE_01)" style="background-color:#EEEEEE;border:1px solid black;" >'
                    },
                    { field: 'SEGU_SIST[0].CO_SIST', displayName: 'Rol', width: "*" },
                    { field: 'SEGU_SIST[0].DE_SIST', displayName: 'SISTEMA', width: "**" },
        ],
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        //plugins: [new ngGridCsvExportPlugin()],
    };

    //$("#CO_ROLE").val("");
    //$("#NO_ROLE").val("");

    var data02 = "{CO_ROLE : '" + $("#hiCO_ROLE").val() + "', NO_ROLE : '" + $("#hiNO_ROLE").val() + "'}";
    var enter = $.ajax({
        url: "../../../SeguridadRol/fn_ENCO_ROLE",
        type: "POST",
        contentType: "application/json",
        data: data02,
        async: false,
        success: function (response) {
            if (response.length > 0) {
                debugger;
                var sCO_ROLE = response[0].CO_ROLE;
                var sNO_ROLE = response[0].NO_ROLE;
                var sDE_ROLE = response[0].DE_ROLE;
                $scope.CO_ROLE = sCO_ROLE;
                $scope.NO_ROLE = sNO_ROLE;
                $scope.DE_ROLE = sDE_ROLE;
                expect(element(by.model('CO_ROLE')).getAttribute()).toBeFalsy();

                //expect(element(by.css('button')).getAttribute('disabled')).toBeFalsy();

                //$("#CO_ROLE").val(sCO_ROLE);
                //$("#nom_rol").val(sNO_ROLE);
            }
           
        },
        error: function (request, status, error) {
            alert("fail Cargar los Roles");
        }
    });

    //$scope.ok = function () {
    //    //$uibModalInstance.close($scope.selected.item);
    //    $uibModalInstance.close();
    //};

    //$scope.cancel = function () {
    //    $uibModalInstance.dismiss('cancel');
    //};

});
