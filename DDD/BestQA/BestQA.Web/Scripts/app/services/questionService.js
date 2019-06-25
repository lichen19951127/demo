angular.module("bestQA").factory("questionService", ['$http', function ($http) {
    return {
        create: function (data) {
            return $http({
                url: '/Question/Create',
                method: 'POST',
                data: data
            });
        },
        edit: function (data) {
            return $http({
                url: '/Question/Edit',
                method: 'POST',
                data: data
            });
        },
        getQuestions: function (data) {
            return $http({
                url: '/Question/Get',
                method: 'POST',
                data: data
            });
        },
        vote: function (action, data) {
            var url = '/Question/' + action;
            return $http({
                url: url,
                method: 'POST',
                data: data
            });
        }
    }
}]);