
function All(event) {
    event.preventDefault();
    console.log("OnSubmit Event: ", event);

    var formUrl = event.target.action;
    console.log("formUrl", formUrl);

    $.get(formUrl, function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        $("#PeopleTable").replaceWith(data);
    });
}

