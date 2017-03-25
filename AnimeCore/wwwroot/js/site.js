var app = angular.module("app", []);

app.controller("movieController", movieController);

var movieController = function($scope, $http) {
    $http.get("https://localhost:44308/api/Movie").then(function(response) {
        $scope.movies = response.data;
        $scope.propertyName = "name";
        $scope.reverse = false;
        $scope.status = "";
        $scope.release = "2017";

        $scope.movies.forEach(function(movies) {
            if (movies.status === 1) {
                movies.status = "Completed";
            } else {
                movies.status = "Ongoing";
            }
        });
    });
};