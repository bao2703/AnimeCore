(function() {
    "use strict";

    angular.module("app", []).controller("movie-controller", controller);

    controller.$inject = ["$scope", "$http"];

    function controller($scope, $http) {
        $http.get("https://localhost:44308/api/Movie").then(function(response) {
            $scope.movies = response.data;
            $scope.propertyName = "name";
            $scope.reverse = false;
            $scope.status = "";
            $scope.release = "";

            $scope.movies.forEach(function(movies) {
                if (movies.status === 1) {
                    movies.status = "Completed";
                } else {
                    movies.status = "Ongoing";
                }
            });
        });

        activate();

        function activate() {}
    }
})();