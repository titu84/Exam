function btnClick(myDiv, myBtn) {
    var x = document.getElementById(myDiv);
    var y = document.getElementById(myBtn);
    x.style.display = 'block';
    y.style.display = 'none';
}
function questionToggle(myPanelBody) {
    var x = document.getElementById(myPanelBody);
    if (x.style.display == 'block') {
        x.style.display = 'none';
    }
    else {
        x.style.display = 'block';
    }
}
function questionsShowFromCurrent() {
    var x = document.getElementsByClassName("qBody");
    var i;
    var disp = 'none'
    if (x.length > 0) {
        for (i = 0; i < x.length; i++) {
            if (x[i].style.display == 'block') {
                disp = 'block';
            }
            x[i].style.display = disp;
        }
    }
}
function questionsShowAll() {
    var x = document.getElementsByClassName("qBody");
    var i;
    var disp = 'block'
    if (x.length > 0) {
        for (i = 0; i < x.length; i++) {
            x[i].style.display = disp;
        }
    }
}
function questionsHideAll() {
    var x = document.getElementsByClassName("qBody");
    var i;
    var disp = 'none'
    if (x.length > 0) {
        for (i = 0; i < x.length; i++) {
            x[i].style.display = disp;
        }
    }
}
$(document).ready(function () {
    $(".item")[0].classList.add('active')
});
var carouselInterval = 5000
$('.carousel').carousel({ interval: carouselInterval });

$(function () {
    $('#myCarousel').carousel({
        interval: carouselInterval,
        pause: "false"
    });
    $('#playButton').click(function () {
        $('#myCarousel').carousel('cycle');
        $('#playButton').removeClass('btn-dafault').addClass('btn-success');
        $('#pauseButton').removeClass('btn-success').addClass('btn-dafault');
    });
    $('#pauseButton').click(function () {
        $('#myCarousel').carousel('pause');
        $('#pauseButton').removeClass('btn-dafault').addClass('btn-success');
        $('#playButton').removeClass('btn-success').addClass('btn-dafault');
    });
    $(".panel").mouseover(function () {
        $('#myCarousel').carousel('pause');
        $('#pauseButton').removeClass('btn-dafault').addClass('btn-success');
        $('#playButton').removeClass('btn-success').addClass('btn-dafault');
    });
    $(".panel").mouseleave(function () {
        $('#myCarousel').carousel('cycle');
        $('#playButton').removeClass('btn-dafault').addClass('btn-success');
        $('#pauseButton').removeClass('btn-success').addClass('btn-dafault');
    });
});

function changeSize(myPanelBody) {
    var x = document.getElementById(myPanelBody);
    if (x.getAttribute("class") == "col-sm-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2") {
        x.setAttribute("class", "col-md-12");
    }
    else {
        x.setAttribute("class", "col-sm-12 col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2");
    }
}