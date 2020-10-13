$(document).load(function () {

});

function showLoader() {
    $('#playButton').toggle();
    var canvas = $('#circle').circleProgress({
        value: 0.1,
        size: 150,
        fill: {
            gradient: ['#ffcccb', '#ff5f43']
        }
    });
}