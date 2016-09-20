var angularFormsApp = angular.module('angularFormsApp', ["ui.bootstrap"]);

angularFormsApp.controller('efLoginController', function ($scope, $uibModal) {
    
    $scope.Login_pass = function (size) {
        
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.ingresar = function () {

        var customer = {
            CodUsuario: 'usrprdsolnegmo',
            Contrasena: 'S01ucion3s'
        };

        //https://webservicecert.upc.edu.pe/v2/AutenticaUsuario/customer',
        
        //var headers = {};
        //if (token) {
        //    headers.Authorization = 'Bearer ' + token;
        //}

        //var token = "Password: contactowebupc201601";

        //var headers = {};
        //if (token) {
        //    headers.Authorization = 'Username : upc\\usrdescontactoweb01;  ' + token;
        //}

        ////upc\usrdescontactoweb01
        ////contactowebupc201601

        //$.ajax(
        //    {
        //        type: "GET",
        //        url: "",
        //        beforeSend: function (request) {
        //            request.setRequestHeader("Content-Type", "application/json");
        //        },
        //        success: function (data) {
        //            var lista = [];

        //            $.each(
        //                data, function ()
        //                {

        //                }
        //                );

        //        }
        //    }
        //);

        /*
        var codigo = "omakishi";
        var clave = "123456789";
        var alumno = "E201012364";
        //https://upcmovil.upc.edu.pe/UPCBolsaEPG/UPCBolsa.svc/sesiones/inicioadmin
        //http://matriculadeso.upc.edu.pe/UPCBolsaEPG/UPCBolsa.svc/sesiones/inicioadmin
        //var data = "{codigo:'" + $("#nombre").val() + "',clave:'" + $("#pass").val() + "'}";
        var data = "{codigo:'" + codigo + "',clave:'" + clave + "',cod_alumno:'" + alumno + "'}";
        var datos = "{codigo:omakishi,clave:123456789,cod_alumno:E201012364}";
        var webServiceURL = "http://matriculadeso.upc.edu.pe/UPCBolsaEPG/UPCBolsa.svc/sesiones/inicioadmin";

        $.ajax({
            url: webServiceURL,
            type: "POST",
            data:
              {
                  codigo: "omakishi",
                  clave: "123456789",
                  alumno : "E201012364"
              },
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success : OnSuccess,
            error: OnError
        });

        function OnSuccess(data,status)
        {
            debugger;
        }

        function OnError(request, status, error)
        {
            debugger;
            alert(status);
        }
        */
        /* */
        var data = "{CO_USUA:'" + $("#nombre").val() + "',DE_PASS:'" + $("#pass").val() + "'}";
        var enter = $.ajax({
                        url: "../../Home/fn_Ingresa",
                        type: "POST",
                        contentType: "application/json",
                        data: data,
                        success: function (response) {
                            debugger;
                            var sCO_USUA = "";
                            if (response.length > 0) {
                                sCO_USUA = response[0].CO_USUA;
                            }
                            
                            window.location.href = "Home/Base";
                        },
                        error: function (request, status, error) {
                            debugger;
                            //alert("error : " + error);
                            //alert("status : " + status);
                            //alert("request : " + request);
                            //window.location.href = "Home/Base";
                            alert("fail pantalla inicial");
                        }
        });
       
        
    };

});

angularFormsApp.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance) {

    //$scope.items = items;
    //$scope.selected = {
    //    item: $scope.items[0]
    //};

    $scope.ok = function () {
        //$uibModalInstance.close($scope.selected.item);
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
