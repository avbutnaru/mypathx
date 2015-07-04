'use strict';

angular.module('GoalBuilder')
  .controller('GoalsNavController', ['$scope', 'GoalService', 'GoalBuilderService', function ($scope, GoalService, GoalBuilderService) {
      $scope.addGoal = function (goal) {
          GoalBuilderService.addGoal(goal);
      }
      var init = function () {
          $scope.goals = GoalService.getGoals();
      };
      init();
  }]);

angular.module('GoalBuilder')
  .controller('GoalListController', ['$scope', 'GoalService', '$location', function ($scope, GoalService, $location) {
      $scope.goto = function (goal) {
          $location.path('/builder/goals/' + goal.name);
      }
      var init = function () {
          $scope.goals = GoalService.getGoals();
      };
      init();
  }]);

angular.module('GoalBuilder')
  .controller('GoalDetailController', ['$scope', 'GoalService', '$routeParams', 'GoalBuilderService', '$location', function ($scope, GoalService, $routeParams, GoalBuilderService, $location) {

      $scope.save = function () {
          $scope.submitted = true;      // Will force validations
          if ($scope.formGoal.$invalid) return;
          $scope.goal = GoalBuilderService.save();
          $scope.formGoal.$setPristine();
          $scope.submitted = false;
      };

      $scope.hasError = function (modelController, error) {
          return (modelController.$dirty || $scope.submitted) && error;
      };

      $scope.reset = function () {
          $scope.goal = GoalBuilderService.startBuilding($routeParams.id);
          $scope.formGoal.$setPristine();
          $scope.submitted = false;      // Will force validations
      };

      $scope.canDeleteGoal = function () {
          return GoalBuilderService.canDeleteGoal();
      }

      $scope.deleteGoal = function () {
          GoalBuilderService.delete();
          $location.path('/builder/goals/');
      };

      var init = function () {
          $scope.goal = GoalBuilderService.startBuilding($routeParams.id);
      };

      init();
  }]);