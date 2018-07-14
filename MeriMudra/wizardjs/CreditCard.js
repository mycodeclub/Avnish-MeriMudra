var options = [];

$('.dropdown-menu div').on('click', function (event) {
    //debugger;
    var $target = $(event.currentTarget),
        val = $target.attr('data-value'),
        $inp = $target.find('input'),
        idx;

    if ((idx = options.indexOf(val)) > -1) {
        options.splice(idx, 1);
        setTimeout(function () { $inp.prop('checked', false) }, 0);
    } else {
        options.push(val);
        setTimeout(function () { $inp.prop('checked', true) }, 0);
    }

    $(event.target).blur();

    console.log(options);
    return false;
});

function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}
function eraseCookie(name) {
    document.cookie = name + '=;expires=Thu, 01 Jan 1970 00:00:01 GMT;path=/;localhost:64796;';
    document.cookie = name + '=; Max-Age=-99999999;';
}

function  ValidateDecimal(e, t, suffix) {  // Example :  .. return GLOBAL.AllowNoOnly(event,this)        
    try {
        var charCode = e.which;
        if (charCode == 46) {
            if ($(t).val().indexOf(".") === -1) return true;
        }
        else {
            if ($(t).val().indexOf(".") !== -1) {
                if ($(t).val().split('.')[1].length == suffix && charCode != 8)
                    return false;
            }
        }
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }
    catch (err) {
        alert(err.Description);
    }
}