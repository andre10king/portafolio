
var testApp = angular.module("articuloModule", []);

testApp.controller("articuloController", function ($scope, $http) {
    $http.get('/api/articuloes').then(function (response) {
        $scope.articulos2 = response.data;
    });



    $scope.delete = function (id) {

        $http.delete('/api/articuloes/' + id)
            .success(function (data) {
                console.log(data);

            })
            .error(function (data) {
                console.log('Error: ' + data);
            });
    };


    $scope.deleteItem = function (a) {
        var index = $scope.articulos2.indexOf(a);
        $scope.articulos2.splice(index, 1);
    };



    $scope.submitForm = function () {
        if ($scope.myForm.$valid) {
            debugger

            var data = {
                /*id: $scope.Id,*/

                descripcion: $scope.Descripcion,
                marca: $scope.Marca,
                cantidad: $scope.Cantidad,
                precio: $scope.precio
            };
            $http.post('/api/articuloes', data).then(function (response) {
             
                console.log(response.data);
                $scope.articulos2.push(response.data);
           
                window.location.reload();
               


            });




            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'guardado con exito',
                showConfirmButton: false,
                timer: 1500
            })
        }
        else {

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Porfavor llenar todos los campos!',
                footer: '<a href="">Why do I have this issue?</a>'
            })

        }
    };







    //$scope.addItem = function () {
    //    var data = {
    //        /*id: $scope.Id,*/

    //        descripcion: $scope.Descripcion,
    //        marca: $scope.Marca,
    //        cantidad: $scope.Cantidad,
    //        precio: $scope.precio
    //    };

    //    $scope.articulos2.push(data);
     
    //};




});




