
angular.module('listaTelefonica').controller('contatoCtrl',
    function ($scope, uppercaseFilter, dateFilter, contatos, contatoApi) {

        $scope.pagina = "contatos";

        $scope.contatos = contatos.data;

        $scope.apagarContatos = function (contatos) {
            // reatribui apenas os contatos selecionados
            contatos.forEach(function (contato) {
                if (contato.selecionado) {
                    contatoApi.excluirContato(contato.id);
                }
            });

        };

        $scope.algumContatoSelecionado = function (contatos) {

            return contatos.some(function (contato) {
                return contato.selecionado;
            });

        };

        $scope.ordenar = function (campo) {
            $scope.campoOrdenacao = campo;
            $scope.direcaoOrdenacao = !$scope.direcaoOrdenacao;
        }
    }
);