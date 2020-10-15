var FITNESSRATINGS = [];
var ATHLETES = [];
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: getBaseUrl() + "BeepTest/GetFitnessRatings",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            FITNESSRATINGS = result;
        },
        error: function (error) {
            alert("Internal Server Error");
        }
    });

    $.ajax({
        type: "GET",
        url: getBaseUrl() + "BeepTest/GetAthletes",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            ATHLETES = result;

            $.each(ATHLETES, function (i) {
                var li = $('#AthletesList')
                    .append(`<li class="list-group-item d-flex justify-content-between align-items-center">
                    `+ ATHLETES[i].id + '. ' + ATHLETES[i].name + `
                    <button class="badge badge-secondary badge-pill id='`+ATHLETES[i].id + 'warn' + `' onclick='warn(` + ATHLETES[i].id + `)'">warn</button>
                    <button class="badge badge-danger badge-pill id='`+ATHLETES[i].id + 'stop' + `' onclick='stop(` + ATHLETES[i].id + `)'">Stop</button>
                         </li>`);
            });
        },
        error: function (error) {
            alert("Internal Server Error");
        }
    });
});

function showLoader() {
    $('#playButton').toggle();
    var start = new Date;
    var circlesettings = {
        value: 0,
        size: 150,
        animation: false,
        fill: {
            gradient: ['#ffcccb', '#ff5f43']
        }
    };
    var intervalId = setInterval(function () {
        circlesettings.value = (new Date - start) / 1000;
        var value = circlesettings.value / 10;
        if (value <= 1) {
            canvas = $('#circle').circleProgress({ value: value });
            var obj = $('#circle').data('circle-progress'),
                ctx = obj.ctx,
                s = obj.size;
            ctx.font = "bold " + s / 15 + "px sans-serif";
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillStyle = '#000000';
            ctx.fillText("14Km/h", s / 2, s / 2 + 30);

            ctx.font = "bold " + s / 10 + "px sans-serif";
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillStyle = '#808080';
            ctx.fillText("Shuttle 5", s / 2, s / 2);

            ctx.font = "bold " + s / 10 + "px sans-serif";
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillStyle = '#808080';
            ctx.fillText("Level 12", s / 2, s / 2 - 30);
            ctx.restore();
        } else {
            clearInterval(intervalId);
        }

    }, 1000);

    canvas = $('#circle').circleProgress(circlesettings);
}

function stop(athlete) {
    var id = athlete.id;
}

function warn(athlete) {

}

function getBaseUrl() {
    return "api/";
}