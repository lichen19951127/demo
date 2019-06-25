angular.module("bestQA").factory("answerService", ['$http', function ($http) {
    return {
        create: function (data) {
            return $http({
                url: '/Answer/Create',
                method: 'POST',
                data: data
            });
        },
        edit: function (data) {
            return $http({
                url: '/Answer/Edit',
                method: 'POST',
                data: data
            });
        },
        getQuestions: function (data) {
            return $http({
                url: '/Answer/Get',
                method: 'POST',
                data: data
            });
        },
        vote: function (action, data) {
            var url = '/Answer/' + action;
            return $http({
                url: url,
                method: 'POST',
                data: data
            });
        }
    }
}]);