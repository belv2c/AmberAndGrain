var app = angular.module("AmberAndGrain", ["ngRoute"]);

// first is name of argument, second is actual function
// when you minify a file, name of function gets changed
app.config("$routeProvider", [function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/index.html",
            controller: "HomeController"
        });
}]);