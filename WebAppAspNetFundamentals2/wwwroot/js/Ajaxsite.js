////document.getElementById("showAllPeople").
////    addEventListener("click", ShowAll);

//document.getElementById("showDetail").
//    addEventListener("click", DetailPerson);

//document.getElementById("deletePerson").
//    addEventListener("click", DeletePerson);


function ShowAll() {
     
    $.get("AjaxShowAll", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        $("#AjaxResult").html(data);
    });
}

function DetailPerson() {
 
    console.log("id: ", document.getElementById("keyId"));
      
    $.post("DetailPerson",
        {
            id: document.getElementById("keyId").value
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            $("#AjaxResult").html(data);
        }
    );
}

function DeletePerson() {
  
    console.log("id: ", document.getElementById("keyId"));
       
    $.post("Delete",
        {
            id: document.getElementById("keyId").value
        },
        function (data, status) {
           /* alert("Data: " + data + "\nStatus: " + status);*/
            $("#AjaxResult").text("has been removed");
        }
    ).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("jqXHR", jqXHR);
        console.log("textStatus", textStatus);
        console.log("errorThrown", errorThrown);
        if (jqXHR.status == 404) {
            $("#AjaxResult").text("Person not found.\nwas not able to delete.")
        }
        else {
            alert("Status: " + jqXHR.status);
        }
    });
}


