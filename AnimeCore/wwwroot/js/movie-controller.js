(function() {
    "use strict";
    var app = angular.module("app", ["angularUtils.directives.dirPagination"]);
    app.controller("movie-controller", controller);
    app.filter("status",
        function() {
            return function(data) {
                if (data === 1) {
                    return "Completed";
                }
                return "Ongoing";
            };
        });

    controller.$inject = ["$scope", "$http"];

    function controller($scope, $http) {
        angular.element(document).ready(function() {
            $http.get("https://localhost:44308/api/Movie").then(function(response) {
                $scope.movies = response.data;
                $scope.propertyName = "name";
                $scope.reverse = false;
                $scope.status = "";
                $scope.release = "";
                $scope.genreId = $("#genreId").val();
            });


            activate();

            function activate() {}
        });
    }
})();