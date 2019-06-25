angular.module('bestQA').directive('answer', function() {
    return {
        restrict: 'EA',
        templateUrl: '/template/answer',
        scope: {
            answer: '=content',
            pageMode: '@',
            postId:'@'
        },
        controller: ["$scope", "$timeout", "blockUI", "answerService", function ($scope, $timeout, blockUi, answerService) {
            $scope.init = function(answer) {
                if ($scope.pageMode == 'create') {
                    $scope.enableEdit(answer);
                }
            }
           
            $scope.editCancel = function(answer) {
                $scope.disableEdit();
                $scope.scrollTo();
            }
            $scope.enableEdit = function(answer) {
                $scope.editing = true;
            }
            $scope.disableEdit = function(answer) {
                $scope.editing = false;
            }
            $scope.saveChanges = function(answer) {
                blockUi.start('Saving...');

                if (answer.Id == undefined || answer.Id == '')
                    $scope.create(answer);
                else
                    $scope.update(answer);
            }
            // todo : merge the create and update methods.
            $scope.create = function (answer) {

                answer.validationErrors = [];
                answer.serverError = false;
                    answer.postId = $scope.postId;

                answerService.create(answer)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.validationErrors == null) {
                            $scope.successOnSave = true;
                        } else {
                            answer.validationErrors = response.validationErrors;
                        }
                    })
                    .error(function () {
                        blockUi.stop();
                        $scope.serverError = true;
                    });
            },
            $scope.update = function (answer) {

                answer.validationErrors = [];
                answer.serverError = false;
                answer.successOnSave = false;

                answerService.edit(answer)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.validationErrors == null) {

                            $scope.answer = response.data;
                            $scope.disableEdit($scope.answer);

                            $scope.answer.successOnSave = true;
                            $timeout(function () { $scope.answer.successOnSave = false; }, 1300);

                        } else {
                            answer.validationErrors = response.validationErrors;
                        }
                    })
                    .error(function () {
                        blockUi.stop();
                        $scope.serverError = true;
                    });
            }

            $scope.voteAction = function(action,answer) {
                answer.serverError = false;
                answer.successOnSave = false;

                answerService.vote(action, answer)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.data == 'success') {
                            $scope.answer.successOnSave = true;
                            $timeout(function () { $scope.answer.successOnSave = false; }, 1300);

                        } else {
                            $scope.serverError = true;
                        }
                    })
                    .error(function () {
                        blockUi.stop();
                        $scope.serverError = true;
                    });
            }
            $scope.scrollTo = function (id) {
                $('html, body').animate({ scrollTop: $('#answer-' + id).offset().top - 125 }, 'fast');
            }
        }]
    }
});