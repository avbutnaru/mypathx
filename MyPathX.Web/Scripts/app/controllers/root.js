'use strict';

angular.module('app')
  .controller('RootController', ['$scope', '$modal', function ($scope, $modal) {
      $scope.$on('$routeChangeSuccess', function (e, current,previous) {
          $scope.currentRoute = current;
      });

  }]);
