angular.module('listaTelefonica').service('contatoApi', function($http, config, $route) {
    
    var _getContatos = function() {
        return $http.get(config.baseUrl + '/contato');
    }
    
    var _postContato = function(contato) {
        return $http.post(config.baseUrl + '/contato', contato);
    }
    
    var _getContato = function(id) {
        return $http.get(config.baseUrl + '/contato/' + id);
    }
    
    var _deleteContato = function(id) {
        return $http.delete(config.baseUrl + '/contato/' + id)
    }
    
    return {
        
        listarContatos : _getContatos,
        gravarContato : _postContato,
        recuperarContato : _getContato,
        excluirContato : _deleteContato        
    }
    
})