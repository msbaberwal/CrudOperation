var ContactsController = function (ContactsService) {

    var init = function () {
        $(".js-cancel-contact").click(deleteContact);
    };
    var deleteContact = function (e) {
        var link = $(e.target);
        if (confirm("Are you sure you want to delete this contact ?")) {
            ContactsService.deleteContacts(link, done, fail);
        }
    };



    var done = function () {
        alert("Deleted successfully !");
        window.location.href = '/home/index';
    }

    var fail = function () {
        alert("somethings wrong !");
    };

    return {
        init: init
    };


}(ContactsService);