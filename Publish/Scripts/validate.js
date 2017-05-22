// JavaScript Document
$("#input-value").keypress(function () {
	
	var intRegex = /[0-9.]/;  	
	if (event.which == 13 || !intRegex.test(String.fromCharCode(event.which)))
    	 event.preventDefault();
	else if ($('#input-value').val().indexOf('.') > 0) {
	    if ($('#input-value').val().length > 17)
	        event.preventDefault();
	}
	else if ($('#input-value').val().length > 14)
	    event.preventDefault();

});

$("form").submit(function (e) {

    var number = $("#input-value").val();
    var isValid = (/(?=.)^\$?(([1-9][0-9]{0,2}(,[0-9]{3})*)|[0-9]+)?(\.[0-9]{1,2})?$/).test(number);

    if(!isValid) {
        $('#msg').text("Invalid number");
        $("#input-value").addClass("error").removeClass("required");
        return false;
    }


    $.ajax({
        type: "POST",
        url: "/Home/Index",
        data: { 'Number': $('#input-value').val() },
        dataType: "json",
        success: function (json) {
            $('.word').text(json);
            $('.result').removeClass('fadeOut').addClass('fadeIn');
        },
        error: function (json) {
            $('#input-value').addClass('error');
        }
    })

    e.preventDefault();
});

function errorFocus(e) {
    if ($(e).hasClass('error')) {
        $(e).addClass("required").removeClass("error");
        $('#msg').text("");
        $('#msg').css("color", "red");
    }
}

$("input").focus(function (x) {
    errorFocus(x.target);
    delay(function () {
        $('.result').removeClass('fadeIn').addClass('fadeOut');
    }, 100);    
});

var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();