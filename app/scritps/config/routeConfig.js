angular.module('listaTelefonica').config(function ($routeProvider) {

    $routeProvider.when('/contatos', {
        templateUrl: 'views/contatos.html',
        controller: 'contatoCtrl',
        resolve: {
            contatos: function (contatoApi) {
                return contatoApi.listarContatos();
            }
        }
    })
        .when('/novoContato', {
            templateUrl: 'views/novoContato.html',
            controller: 'novoContatoCtrl',
            resolve: {

                operadoras: function (operadoraApi) {
                    return operadoraApi.listarOperadoras();
                }
            }
        })
        .when('/detalhesContato/:id', {
            templateUrl: 'views/detalhesContato.html',
            controller: 'detalhesContatoCtrl',
            resolve: {
                contato: function (contatoApi, $route) {
                    return contatoApi.recuperarContato($route.current.params.id);
                }
            }
        })
        .otherwise({ redirectTo: '/contatos' });


});