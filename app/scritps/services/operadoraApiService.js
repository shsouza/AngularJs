angular.module('listaTelefonica').service('operadoraApi', function($http, config) {
    
    var _getOperadoras = function() {
        return $http.get(config.baseUrl + '/operadora');
    }
    
    return {
        
        listarOperadoras : _getOperadoras
    }
    
})