angular.module('bestQA').directive('post', function() {
    return {
        restrict: 'EA',
        templateUrl: '/template/post',
        scope: {
            post: '=content',
            pageMode: '@'
        },
        controller: ["$scope", "$timeout", "blockUI", "questionService", function ($scope, $timeout, blockUi, questionService) {
            $scope.initPost = function(post) {
                if ($scope.pageMode == 'create')
                    $scope.enableEdit(post);
            }
            $scope.editCancel = function(post) {
                $scope.disableEdit();
                $scope.scrollTo();
            }
            $scope.enableEdit = function(post) {
                post.editing = true;
            }
            $scope.disableEdit = function(post) {
                post.editing = false;
            }
            $scope.saveChanges = function(post) {
                blockUi.start('Saving...');

                if (post.Id == '')
                    $scope.create(post);
                else
                    $scope.update(post);
            }
            // todo : merge the create and update methods.
            $scope.create = function (post) {

                post.validationErrors = [];
                post.serverError = false;

                questionService.create(post)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.validationErrors == null) {
                            $scope.successOnSave = true;
                            window.location = '/Question/Details/' + response.data;
                        } else {
                            post.validationErrors = response.validationErrors;
                        }
                    })
                    .error(function () {
                        blockUi.stop();
                        $scope.serverError = true;
                    });
            },
            $scope.update = function (post) {

                post.validationErrors = [];
                post.serverError = false;
                post.successOnSave = false;

                questionService.edit(post)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.validationErrors == null) {

                            $scope.post = response.data;
                            $scope.disableEdit($scope.post);

                            $scope.post.successOnSave = true;
                            $timeout(function () { $scope.post.successOnSave = false; }, 1300);

                        } else {
                            post.validationErrors = response.validationErrors;
                        }
                    })
                    .error(function () {
                        blockUi.stop();
                        $scope.serverError = true;
                    });
            }

            $scope.voteAction = function(action,post) {
                post.serverError = false;
                post.successOnSave = false;

                questionService.vote(action, post)
                    .success(function (response) {
                        blockUi.stop();
                        if (response.data == 'success') {
                            $scope.post.successOnSave = true;
                            $timeout(function () { $scope.post.successOnSave = false; }, 1300);

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
                $('html, body').animate({ scrollTop: $('#post-' + id).offset().top - 125 }, 'fast');
            }
        }]
    }
});