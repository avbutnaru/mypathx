'use strict';

/* Model classes */
angular.module('app')
    .factory('Goal', function () {
        function Goal(args) {
            this.name = args.name;
            this.title = args.title;
            this.description = args.description;
        }
        return Goal;
    });
