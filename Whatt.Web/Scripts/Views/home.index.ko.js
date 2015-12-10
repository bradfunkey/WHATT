(function ($) {


    var model = Whatt.Web.Models.DashboardModel;
   
    model.riskyPunters = ko.observableArray(mapDictionaryToArray(model.settledCustomerAverageWinDictAlert));
    model.averageStakes = ko.observableArray(mapDictionaryToArray(model.settledCustomerAverageStakeDict));


    ko.applyBindings(model);    

    function mapDictionaryToArray(dictionary) {
        var result = [];
        for (var key in dictionary) {
            if (dictionary.hasOwnProperty(key)) {
                result.push({ key: key, value: dictionary[key] });
            }
        }

        return result;
    }

    $(document).ready(function () {     
    console.log(model);
        

    });

})(jQuery);

