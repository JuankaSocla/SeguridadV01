var angularFormsApp_01 = angular.module('angularFormsApp_01', ['ngAnimate', 'ui.bootstrap']);

angularFormsApp_01.filter('ID_SIST', function () {
    return function (input, uppercase) {
        var out = [];
        for (var i = 0; i < input.length; i++) {
            if (input[i].ID_SIST == uppercase)
            {
                out.push(input[i]);
            }
        }
        return out;
    }
});

angularFormsApp_01.filter('DI_OPCI', function () {
    return function (input, uppercase) {
        var out = [];
        for (var i = 0; i < input.length; i++) {
            if (input[i].ID_OPCI_SUPE == uppercase) {
                out.push(input[i]);
            }
        }
        return out;
    }
});

angularFormsApp_01.controller('efBaseController', function ($scope) {

    $scope.oneAtATime = true;

    $scope.groups = [
      {
          title: 'Dynamic Group Header - 1',
          content: 'Dynamic Group Body - 1'
      },
      {
          title: 'Dynamic Group Header - 2',
          content: 'Dynamic Group Body - 2'
      }
    ];

    var sDE_SIST = [];
    var sID_OPCI_SUPE_ARR = [];
    var sDI_OPCI_ARR = [];

    var data = "{CO_USUA:'" + $("#hiCO_USUA").val() + "',ID_OPCI:'" + 0 + "'}";
    var ingresar = $.ajax({
        url: "../../Base/fn_MENU",
        type: "POST",
        contentType: "application/json",
        data: data,
        async: false,
        success: function (response) {
            var sID_OPCI;
            var nID_OPCI = 0;
            var sID_OPCI_SUPE;
            var nID_OPCI_SUPE = 0;
            var sDI_OPCI;
            var nDI_OPCI = 0;

            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    sID_OPCI = response[i].SEGU_OPCI[0].ID_OPCI;
                    sID_OPCI_SUPE = response[i].SEGU_OPCI[0].ID_OPCI_SUPE;
                    sDI_OPCI = response[i].SEGU_OPCI[0].DI_OPCI;
                    if (sID_OPCI == "0") {
                        sDE_SIST[nID_OPCI] = {
                            DE_SIST : response[i].DE_SIST,
                            ID_SIST: response[i].ID_SIST,
                            IMG_SIST: response[i].IMG_SIST,
                        };
                        nID_OPCI = nID_OPCI + 1;
                    }
                    if (sID_OPCI_SUPE == null) {
                        sID_OPCI_SUPE_ARR[nID_OPCI_SUPE] = {
                            ID_SIST: response[i].ID_SIST,
                            ID_OPCI : response[i].SEGU_OPCI[0].ID_OPCI,
                            NO_OPCI : response[i].SEGU_OPCI[0].NO_OPCI
                        };
                        nID_OPCI_SUPE = nID_OPCI_SUPE + 1;
                    }
                    if (sDI_OPCI != "") {
                        sDI_OPCI_ARR[nDI_OPCI] = {
                            ID_SIST: response[i].ID_SIST,
                            ID_OPCI: response[i].SEGU_OPCI[0].ID_OPCI,
                            ID_OPCI_SUPE: response[i].SEGU_OPCI[0].ID_OPCI_SUPE,
                            NO_OPCI: response[i].SEGU_OPCI[0].NO_OPCI,
                            DI_OPCI: response[i].SEGU_OPCI[0].DI_OPCI,
                            DI_OPCI_RAZOR: response[i].SEGU_OPCI[0].DI_OPCI_RAZOR
                        }
                        nDI_OPCI = nDI_OPCI + 1;
                    }
                }
            }
            
        },
        error: function (request, status, error) {
            alert("error : " + error);
            alert("status : " + status);
            alert("request : " + request);
            //window.location.href = "Home/Base";
            alert("error en Pantalla Base");
        }
    });
    
    $scope.Login_opci = function (ID_OPCI, DI_OPCI) {
        //debugger;
        if (DI_OPCI != "") {
            document.getElementById("hiRE_PAGE_00").src = DI_OPCI;
        }
        else {
            document.getElementById("hiRE_PAGE_00").src = "http://matricula.upc.edu.pe/";
        }
        
    };

    $scope.Login_modu = function (ID_OPCI) {
        //debugger;
        isFirstOpen = true;
        var s;
    };

    $scope.items = sDE_SIST;
    $scope.items_tree = sID_OPCI_SUPE_ARR;
    $scope.items_tree_01 = sDI_OPCI_ARR;

    $scope.addItem = function () {
        var newItemNo = $scope.items.length + 1;
        $scope.items.push('Item ' + newItemNo);
    };

    $scope.status = {
        isFirstOpen: true,
        isFirstDisabled: false
    };

});

