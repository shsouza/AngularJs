angular.module('listaTelefonica').directive('uiAlert', function() {
    
    
    return {
        
        templateUrl : 'views/alert.html',
        restrict : 'E',
        scope : {
            title : '@',
            message : '='
        },
        transclude : true      
    }
    
    
});