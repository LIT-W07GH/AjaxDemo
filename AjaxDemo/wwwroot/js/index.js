$(() => {
    $("#ajax-button").on('click', function () {
        const count = $("#count").val();

        $.get(`/home/getrandompeople?count=${count}`, function (people) {
            people.forEach(person => {
                $("#people").append(`<li>${person.firstName} ${person.lastName} - ${person.age}</li>`);
            });
        });

    });

    $("#reverse").on('click', function () {
        const text = $("#text").val();
        $.get(`/home/reverse`, { text: text }, function (obj) {
            $("#output").html(`<h1>${obj.reversedText}</h1>`);
        });
    });
});