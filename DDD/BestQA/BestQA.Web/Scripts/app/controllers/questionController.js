angular.module("bestQA").controller('questionController', ['$scope', 'blockUI', 'ngTableParams', 'questionService',
    function ($scope, blockUI, ngTableParams, questionService) {
    $scope.init = function () {
        var a = 0;
        $scope.resetPageVariables();
        $scope.initPageModel();
        $scope.getQuestions();
    }

    $scope.resetPageVariables = function () {
        $scope.loadSuccessfull = false;
        $scope.loadError = false;
        $scope.noQuestionsFound = false;
    }
    $scope.initPageModel = function () {
        $scope.questions = [];
    }
    $scope.getQuestions = function () {
        blockUI.start('Loading...');
        $scope.gridParams = {
            PageNumber: 1,
            PageSize: 10,
            SortColumn: "CreatedTime",
            SortOrder: "desc"
        }

        $scope.tableParams = new ngTableParams(
        {
            page: $scope.gridParams.PageNumber,
            count: $scope.gridParams.PageSize
        },
        {
            total: 0, // length of data
            getData: function ($defer, params) {

                for (var i in params.sorting()) {
                    $scope.gridParams.SortColumn = i;
                    $scope.gridParams.SortOrder = params.sorting()[i];
                }

                var paramToPost = {
                    PageNumber: $scope.tableParams.page(),
                    PageSize: $scope.tableParams.count(),
                    SortColumn: $scope.gridParams.SortColumn,
                    SortOrder: $scope.gridParams.SortOrder,
                    SearchTerm: $scope.gridParams.SearchTerm
                };

                questionService.getQuestions(paramToPost)
                    .success(function (gridData) {

                        $defer.resolve(gridData.Data);
                        params.total(gridData.Count);

                        blockUI.stop();
                        $scope.loadSuccessfull = true;

                        if (gridData.data.length == 0)
                            $scope.noQuestionsFound = true;

                        $scope.questions = gridData.data;
                    })
                    .error(function () {
                        blockUI.stop();
                        $scope.loadError = true;
                    });
            }
        }
    );
    }
}]);