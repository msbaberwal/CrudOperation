var ContactsService = function () {
    var deleteContacts = function (link, done, fail) {
        $.ajax({
                url: "/Api/contacts/" + link.attr("data-contact-id"),
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    }

    return {
        deleteContacts: deleteContacts
    }
}();