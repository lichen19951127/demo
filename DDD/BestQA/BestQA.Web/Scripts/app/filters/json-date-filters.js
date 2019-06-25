angular.module("bestQA").filter("jsonDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});