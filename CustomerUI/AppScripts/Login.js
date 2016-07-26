var module = angular.module('myloginApp', []);

module.controller('AccountController', function ($scope, $http, LoginService) {

    // Get customer list
    $http.get("/api/customerapi")
    .success(function (response) {
        $scope.Login = response
    });
    // Initial 
    // $scope.edit = true;
    $scope.error = false;
    $scope.incomplete = false;
    $scope.UserM = {
        UserName: '',
        Password: '',
        RememberMe: false
    }

    //Check is Form Valid or Not // Here LoginForm is our form Name
    //$scope.$watch('LoginForm.$valid', function (newVal) {
    //    $scope.IsFormValid = newVal;
    //});

    // Update or add new one  
    $scope.PostUser = function () {
        $.get("api/loginapi",
                     $("#LoginForm").serialize(),
                     function (value) {

                         // Refresh list
                         $http.get("/api/loginapi").success(function (response) {
                             $scope.Login = response
                         });

                         alert("Login successfully.");
                     },
                     "json"
               );
    };

    $scope.UserLogin = function () {
        $scope.Submitted = true;
        //if ($scope.IsFormValid) {
        LoginService.GetUser($scope.UserM).then(function (d) {
                if (d.data.UserName != null) {
                    $scope.IsLogedIn = true;
                    $scope.Message = "Successfully login done. Welcome " + d.data.FullName;
                    window.location.href = "/Home/Index";
                }
                else {
                    alert('Invalid Credential!');
                }
            });
       // }
    };

});

module.factory('LoginService', function ($http) {
    var fac = {};
    fac.GetUser = function (d) {
        return $http({
            url: '/Account/UserLogin',
            method: 'POST',            
            data: d,
            headers: {'content-type':'application/json'}
        });
    };
    return fac;
});   