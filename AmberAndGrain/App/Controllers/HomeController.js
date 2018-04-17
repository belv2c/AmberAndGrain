app.controller("HomeController", ["$scope", "$http",
    function ($scope, $http) {
        $scope.message = "Hello World";

        $http.get("/api/recipes").then(function (result) {
            $scope.recipes = result.data;
        });
    }
]);