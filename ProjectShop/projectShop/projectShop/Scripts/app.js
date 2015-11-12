var ViewModel = function () {
    var self = this;
    self.adwords = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.newAdwords =
        {

         
            Name: ko.observable(),
            Url: ko.observable(),
            Image: ko.observable(),
        }

    var adwordsUri = '/api/adwords/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllAdwords() {
        ajaxHelper(adwordsUri, 'GET').done(function (data) {

            self.adwords(data);
        });
    }

    self.getAdwordDetail = function (item) {
        ajaxHelper(adwordsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    getAllAdwords();


};

ko.applyBindings(new ViewModel());
