
angular.module('listaTelefonica').controller('novoContatoCtrl',
    function ($scope, contatoApi, operadoras, serialGenerator, $location) {

        $scope.operadoras = operadoras.data;

        $scope.adicionarContato = function (contato) {

            contatoApi.gravarContato(contato).success(function (data, status) {
                $scope.message = status;
                delete $scope.contato;
                $scope.contatoForm.$setPristine();
                $location.path('/contatos');
            })
        };
    }
);