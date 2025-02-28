﻿// https://raw.githubusercontent.com/kennyki/angular-pagedown/master/angular-pagedown.js

// adapted from http://stackoverflow.com/a/20957476/940030
angular.module("ui.pagedown", [])
.directive("pagedownEditor", function ($compile, $timeout, $window, $q) {
    var nextId = 0;
    var converter = Markdown.getSanitizingConverter();

    converter.hooks.chain("preBlockGamut", function (text, rbg) {
        return text.replace(/^ {0,3}""" *\n((?:.*?\n)+?) {0,3}""" *$/gm, function (whole, inner) {
            return "<blockquote>" + rbg(inner) + "</blockquote>\n";
        });
    });

    return {
        restrict: "E",
        scope: {
            content: "=",
            showPreview: "@",
            help: "&",
            insertImage: "&"
        },
        controller: function($scope) {
            $scope.togglePreview = function() {
                $scope.showPreview = !$scope.showPreview;
            }
        },
        link: function (scope, element, attrs) {

            var editorUniqueId;

            if (attrs.id == null) {
                editorUniqueId = nextId++;
            } else {
                editorUniqueId = attrs.id;
            }

            // just hide the preview, we still need it for "onPreviewRefresh" hook
            var previewHiddenStyle = scope.showPreview == "false" ? "display: none" : "";

            var newElement = $compile(
                '<div>' +
                    '<div class="wmd-panel">' +
                            '<div id="wmd-button-bar-' + editorUniqueId + '"></div>' +
                            '<textarea class="wmd-input" id="wmd-input-' + editorUniqueId + '" ng-model="content"></textarea>' +
                    '</div>' +
                    '<div class="toggle-preview">' +
                        '<toggle ng-click="togglePreview()">' +
                            '<span ng-show="!showPreview">' +
                                '<span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>Hide Preview' +
                            '</span>' +
                            '<span ng-show="showPreview">' +
                                '<span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>Show Preview' +
                            '</span>' +
                    '</toggle>' +
                    '</div>' +
                    '<div ng-hide="showPreview" id="wmd-preview-' + editorUniqueId + '" class="pagedown-preview wmd-panel wmd-preview" style="' + previewHiddenStyle + '"></div>' +
                '</div>')(scope);

            // html() doesn't work
            element.append(newElement);

            var help = angular.isFunction(scope.help) ? scope.help : function () {
                // redirect to the guide by default
                $window.open("http://daringfireball.net/projects/markdown/syntax", "_blank");
            };

            var editor = new Markdown.Editor(converter, "-" + editorUniqueId, {
                handler: help
            });

            var editorElement = angular.element(document.getElementById("wmd-input-" + editorUniqueId));

            editor.hooks.chain("onPreviewRefresh", function () {
                // wire up changes caused by user interaction with the pagedown controls
                // and do within $apply
                $timeout(function () {
                    scope.content = editorElement.val();
                });
            });

            if (angular.isFunction(scope.insertImage)) {
                editor.hooks.set("insertImageDialog", function (callback) {
                    // expect it to return a promise or a url string
                    var result = scope.insertImage();

                    // Note that you cannot call the callback directly from the hook; you have to wait for the current scope to be exited.
                    // https://code.google.com/p/pagedown/wiki/PageDown#insertImageDialog
                    $timeout(function () {
                        if (!result) {
                            // must be null to indicate failure
                            callback(null);
                        } else {
                            // safe way to handle either string or promise
                            $q.when(result).then(
                                function success(imgUrl) {
                                    callback(imgUrl);
                                },
                                function error(reason) {
                                    callback(null);
                                }
                            );
                        }
                    });

                    return true;
                });
            }

            editor.run();
        }
    }
})
.directive("pagedownViewer", function ($compile, $sce) {
    var converter = Markdown.getSanitizingConverter();

    return {
        restrict: "E",
        scope: {
            content: "="
        },
        link: function (scope, element, attrs) {
            var unwatch;
            var run = function run() {
                // stop continuing and watching if scope or the content is unreachable
                if (!scope || (scope.content == undefined || scope.content == null) && unwatch) {
                    unwatch();
                    return;
                }

                scope.sanitizedContent = $sce.trustAsHtml(converter.makeHtml(scope.content));
            };

            unwatch = scope.$watch("content", run);

            run();

            //var newElementHtml = "<pre ng-bind-html='sanitizedContent'></pre>";
            var newElementHtml = "<preview ng-bind-html='sanitizedContent'></preview>";
            var newElement = $compile(newElementHtml)(scope);

            element.append(newElement);
        }
    }
});