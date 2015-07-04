'use strict';

/* Services */
angular.module('app')
    .factory("GoalService", ['Goal', '$http', '$q', function (Goal, $http, $q) {
        var service = {};
        var goals = [];
        service.getGoals = function () {
            return goals;
        };

        service.getGoal = function (name) {
            var result = null;
            angular.forEach(service.getGoals(), function (goal) {
                if (goal.name === name) result = angular.copy(goal);
            });
            return result;
        };

        service.updateGoal = function (goal) {
            angular.forEach(goals, function (e, index) {
                if (e.name === goal.name) {
                    goals[index] = goal;
                }
            });
            return goal;
        };

        service.addGoal = function (goal) {
            //if (goal.name) {
            //    goals.push(goal);
            //    return goal;
            //}
            if (goal.name) {
                var goalToSave = angular.copy(goal);
                goal._id = goal.name;
                return $http.post("/goalmanagement/add", goalToSave)
                            .then(function (response) {
                                return goal
                            });
            }
        }

        service.deleteGoal = function (goalName) {
            var goalIndex;
            angular.forEach(goals, function (e, index) {
                if (e.name === goalName) {
                    goalIndex = index;
                }
            });
            if (goalIndex >= 0) goals.splice(goalIndex, 1);
        };

        var setupInitialGoals = function () {
            goals.push(
                new Goal({
                    name: "jumpingJacks",
                    title: "Jumping Jacks",
                    description: "A jumping jack or star jump, also called side-straddle hop is a physical jumping goal."
                }));

            goals.push(
               new Goal({
                   name: "wallSit",
                   title: "Wall Sit",
                   description: "A wall sit, also known as a Roman Chair, is an goal done to strengthen the quadriceps muscles."
               }));
        };

        var init = function () {
            setupInitialGoals();
        };

        init();

        return service;
    }]);



angular.module('GoalBuilder')
    .factory("GoalBuilderService", ['GoalService', 'Goal', function (GoalService, Goal) {
        var service = {};
        var buildingGoal;
        var newGoal;
        service.startBuilding = function (name) {
            //We are going to edit an existing goal
            if (name) {
                buildingGoal = GoalService.getGoal(name);
                newGoal = false;
            }
            else {
                buildingGoal = new Goal({});
                newGoal = true;
            }
            return buildingGoal;
        };

        service.save = function () {
            var goal = newGoal ? GoalService.addGoal(buildingGoal)
                                : GoalService.updateGoal(buildingGoal);
            newGoal = false;
            return goal;
        };

        service.delete = function () {
            GoalService.deleteGoal(buildingGoal.name);
        };

        service.canDeleteGoal = function () {
            return !newGoal;
        }

        return service;
    }]);
