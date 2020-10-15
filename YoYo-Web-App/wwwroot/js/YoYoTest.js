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
                                <div>
                                    <span title="warn" style="cursor: pointer;" class="badge badge-secondary badge-pill" style='margin-left: 30%;' id='`+ ATHLETES[i].id + 'warn' + `' onclick='warn(` + ATHLETES[i].id + `)'">warn</span>
                                    <span title="stop" style="cursor: pointer;" class="badge badge-danger badge-pill id='`+ ATHLETES[i].id + 'stop' + `' onclick='stop(` + ATHLETES[i].id + `)'">Stop</span>
                                </div
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

    var cumilativeTimes = $.map(FITNESSRATINGS, function (fitnessRating) { return (parseInt(fitnessRating.commulativeTime.toString().split(':')[0]) * 60 + parseInt(fitnessRating.commulativeTime.toString().split(':')[1])); });
    var totalTime = Math.max(cumilativeTimes);
    for (i = 0; i <= FITNESSRATINGS.length; i++) {
        setTimeout(function (fitnessRating) {
            drawCircleProgress(totalTime, fitnessRating);
            $("#shuttleValue").text(FITNESSRATINGS[i + 1].levelTime + " S");
            $("#totalTimeValue").text(FITNESSRATINGS[i].commulativeTime + " M");
            $("#totalDistanceValue").text(FITNESSRATINGS[i].accumulatedShuttleDistance + " M");
        }, FITNESSRATINGS[i] * 1000, FITNESSRATINGS[i]);
    }

    canvas = $('#circle').circleProgress(circlesettings);
}

function drawCircleProgress(totalTime, fitnessRating) {
    var commulativeTime = parseInt(fitnessRating.commulativeTime.toString().split(':')[0]) * 60 + parseInt(fitnessRating.commulativeTime.toString().split(':')[1]);
    var value = (commulativeTime / totalTime) * 100;
    canvas = $('#circle').circleProgress({ value: value });
    var obj = $('#circle').data('circle-progress');
    var ctx = obj.ctx;
    var s = obj.size;
    ctx.font = "bold " + s / 15 + "px sans-serif";
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillStyle = '#000000';
    ctx.fillText(fitnessRating.speed + "Km/h", s / 2, s / 2 + 30);

    ctx.font = "bold " + s / 10 + "px sans-serif";
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillStyle = '#808080';
    ctx.fillText("Shuttle " + fitnessRating.shuttleNo, s / 2, s / 2);

    ctx.font = "bold " + s / 10 + "px sans-serif";
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillStyle = '#808080';
    ctx.fillText("Level " + fitnessRating.speedLevel, s / 2, s / 2 - 30);
    ctx.restore();
}

function stop(athlete) {
    var id = athlete.id;
}

function warn(athlete) {

}

function getBaseUrl() {
    return "api/";
}