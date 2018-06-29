var interval;
var pts = 0;
var lightsOff = false;

$("#lights").click(() => {
    lightsOff = !lightsOff;
    $('#overlay').fadeToggle(1000); /* Choose desired delay */
    if (!lightsOff)
        setTimeout((function () {
            $("#lights").removeClass('highlight');
        }).bind(this), 1000); /* Same delay */
    else
        $("#lights").addClass('highlight');
})

$("#play").click(() => {
    window.stop();
    console.log("test");
    $("#balloons").css("visibility", "visible");
    $(".minigame").css("visibility", "visible");
    interval = setInterval(createBalloon, 1000);
    $('#background').fadeToggle(1000);
    // $("body").css("background", "linear-gradient(to bottom, #00c3ff, #ffff1c)");
});

$("#exit").click(() => {
    clearInterval(interval);
    pts = 0;
    $("#pts").html(pts);
    $('#background').fadeToggle(1000);
    // $("body").css("background-image", "linear-gradient(to bottom, #64b3f4, #c2e59c)");
    $("#balloons").css("visibility", "hidden");
    $(".minigame").css("visibility", "hidden");
    $(".balloon").remove();
});

$("#balloons").on("click", ".balloon", ev => {
    ev.target.remove();
    $("#pts").html(++pts);
});

function createBalloon() {
    var balloon = document.createElement("img");
    balloon.src = "balloons/" + (Math.floor(Math.random() * 4) + 1) + ".png";
    balloon.classList.add("balloon");
    balloon.style.left = Math.floor(Math.random() * 95) + "%";
    $("#balloons").append(balloon);
    setTimeout(() => {
        balloon.style.bottom = "100%";
    }, 100);

}