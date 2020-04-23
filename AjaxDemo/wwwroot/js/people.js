$(() => {
    function loadPeople() {
        $("#people-table tbody td").remove();
        $.get('/people/getpeople',
            ppl => {
                ppl.forEach(p => {
                    $("#people-table tbody").append(`
                        <tr>
                         <td>${p.firstName}</td>
                         <td>${p.lastName}</td>
                         <td>${p.age}</td>
                        </tr>`);
                });
            });
    }


    loadPeople();

    $("#add-person").on('click', function () {
        const firstName = $("#first-name").val();
        const lastName = $("#last-name").val();
        const age = $("#age").val();
        const person = {
            firstName: firstName, //could just be firstName
            lastName,
            age
        };
        $.post('/people/addperson', person, function(p) {
            loadPeople();   
        });

        $("#first-name").val('');
        $("#last-name").val('');
        $("#age").val('');
    });
});