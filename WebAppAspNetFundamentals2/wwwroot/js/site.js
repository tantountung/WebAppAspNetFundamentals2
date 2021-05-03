document.getElementById("showAllPeople").
    addEventListener("click", ShowAll);

document.getElementById("showDetail").
    addEventListener("click", DetailPerson);

document.getElementById("deletePerson").
    addEventListener("click", DeletePerson);


function ShowAll(event) {
    event.preventDefault();
    console.log("OnSubmit Event: ", event);

    var formUrl = event.target.action;
    console.log("formUrl: ", formUrl);

    $.get(formUrl, function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        $("#PeopleTable").replaceWith(data);
    });
}

function DetailPerson(event, id) {
    event.preventDefault();
    console.log("Event: ", event);

    console.log("id: ", document.getElementById("keyId"));

    var anchorUrl = event.target.href;
    console.log("anchorUrl: ", anchorUrl);

    $post(anchorUrl,
        {
            id: document.getElementById("keyId")
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            $("#PeopleTable" + id).replaceWith(data);
        }
    );
}

function DeletePerson(event, id) {
    event.preventDefault();
    console.log("Event: ", event);

    console.log("id: ", document.getElementById("keyId"));

    var deleteUrl = event.target.href;
    console.log("deleteUrl: ", deleteUrl);

    $.post(deleteUrl,
        {
            id: document.getElementById("keyId")
        },
        function (data, status) {
            alert("Data: " + data + "\nStatus: " + status);
            $("#" + data).remove();
        }
    ).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("jqXHR", jqXHR);
        console.log("textStatus", textStatus);
        console.log("errorThrown", errorThrown);
        if (jqXHR.status == 404) {
            alert("Person not found.\nwas not able to delete.")
        }
        else {
            alert("Status: " + jqXHR.status);
        }
    });
}


