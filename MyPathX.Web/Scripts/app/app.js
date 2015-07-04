'use strict';

angular.module('app', ['ngRoute', 'ngSanitize', 'GoalBuilder', 'ui.bootstrap', 'ngAnimate', 'ngMessages']).
config(function ($routeProvider, $sceDelegateProvider) {
    $routeProvider.when('/builder', {
        redirectTo: '/builder/goals'
    });

    $routeProvider.when('/builder/goals', {
        templateUrl: 'scripts/app/views/goals.html',
        leftNav: 'scripts/app/views/left-nav-main.html',
        topNav: 'scripts/app/views/top-nav.html',
        controller: 'GoalListController'
    });
    $routeProvider.when('/builder/activities', {
        templateUrl: 'scripts/app/views/activities.html',
        leftNav: 'scripts/app/views/left-nav-main.html',
        topNav: 'scripts/app/views/top-nav.html',
        controller:'ActivitiesListController'
});
    $routeProvider.when('/builder/goals/new', {
        templateUrl: 'scripts/app/views/goal.html',
        leftNav: 'scripts/app/views/left-nav-activities.html',
        topNav: 'scripts/app/views/top-nav.html',
        controller: 'GoalDetailController',
        resolve: {
            selectedGoal: ['GoalBuilderService', function (GoalBuilderService) {
                return GoalBuilderService.startBuilding();
            }],
        }
    });
    $routeProvider.when('/builder/goals/:id', {
        templateUrl: 'scripts/app/views/goal.html',
        leftNav: 'scripts/app/views/left-nav-activities.html',
        controller: 'GoalDetailController',
        topNav: 'scripts/app/views/top-nav.html',
        resolve: {
            selectedWorkout: ['GoalBuilderService', '$route', '$location', function (GoalBuilderService, $route, $location) {
                var goal = GoalBuilderService.startBuilding($route.current.params.id);
                if (!goal) {
                    $location.path('/builder/goals');
                }
                return goal;
            }],
        }
    });
    $routeProvider.when('/builder/activities/new', {
        templateUrl: 'scripts/app/views/activity.html',
        controller: 'ActivityDetailController',
        topNav: 'scripts/app/views/top-nav.html'
    });
    $routeProvider.when('/builder/activities/:id', {
        templateUrl: 'scripts/app/views/activity.html',
        controller: 'ActivityDetailController',
        topNav: 'scripts/app/views/top-nav.html'
    });


    $routeProvider.otherwise({ redirectTo: '/builder' });

    $sceDelegateProvider.resourceUrlWhitelist([
      // Allow same origin resource loads.
      'self']);
});

angular.module('GoalBuilder', []);