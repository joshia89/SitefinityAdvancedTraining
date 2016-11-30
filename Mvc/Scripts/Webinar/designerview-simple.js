angular.module('designer').requires.push('sfSelectors');

angular.module('designer')
    .controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;
        $scope.itemType = "Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar";

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    if ($scope.properties.StartTime.PropertyValue && !($scope.properties.StartTime.PropertyValue instanceof Date)) {
                        var startDate = $scope.properties.StartTime.PropertyValue;
                        // This parsing is specific for UK dates. It may be different depending on your website culture.
                        // Dealing with dates is always a complex matter in the programming :)
                        $scope.properties.StartTime.PropertyValue = new Date(startDate.split('/')[2], startDate.split('/')[1] - 1, startDate.split('/')[0]);
                    }

                    if ($scope.properties.EndTime.PropertyValue && !($scope.properties.EndTime.PropertyValue instanceof Date)) {
                        var endDate = $scope.properties.EndTime.PropertyValue;
                        $scope.properties.EndTime.PropertyValue = new Date(endDate.split('/')[2], endDate.split('/')[1] - 1, endDate.split('/')[0]);
                    }
                }
            }, function (data) {
                $scope.feedback.showError = true;

                if (data) {
                    $scope.feedback.errorMessage = data.Detail;
                }
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });

        $scope.$watch('properties.SelectedItem.PropertyValue', function (newValue, oldValue) {
            if (newValue) {
                $scope.selectedItem = JSON.parse(newValue);
            }
        });

        $scope.$watch('selectedItem', function (newValue, oldValue) {
            if (newValue) {
                $scope.properties.SelectedItem.PropertyValue = JSON.stringify(newValue);
            }
        });

    }]);