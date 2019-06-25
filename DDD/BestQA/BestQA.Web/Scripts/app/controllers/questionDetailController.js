angular.module("bestQA").controller('questionDetailController', ['$scope', function ($scope) {

    $scope.init = function (data, pageMode) {

        $scope.question = data;
        $scope.pageMode = pageMode;

        $scope.initializePageDownEditor();
    }

    $scope.initializePageDownEditor = function () {
        var converter1 = Markdown.getSanitizingConverter();

        converter1.hooks.chain("preBlockGamut", function (text, rbg) {
            return text.replace(/^ {0,3}""" *\n((?:.*?\n)+?) {0,3}""" *$/gm, function (whole, inner) {
                return "<blockquote>" + rbg(inner) + "</blockquote>\n";
            });
        });

        var editor1 = new Markdown.Editor(converter1);
        editor1.run();
    }
}]);