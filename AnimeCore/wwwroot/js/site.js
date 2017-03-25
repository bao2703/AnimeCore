var app = angular.module("app", []);

app.controller("movieController", movieController);

var movieController = function($scope, $http) {
    $http.get("https://localhost:44308/api/Movie").then(function(response) {
        $scope.movies = response.data;
    });
};