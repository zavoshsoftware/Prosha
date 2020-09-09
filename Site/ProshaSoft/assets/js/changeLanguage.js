function languageChanged(langInput) {
    setCookie("MyLanguageCookieName", langInput, 365, null);
    window.location.reload();
}
$(document).ready(function () {
    var cultureVal = getCookie("MyLanguageCookieName");
    if (cultureVal.includes("fa")) {
        $('#us-flag').css('opacity', '0.5');
        $('#iran-flag').css('opacity', '1');
        document.getElementById('style-ltr').disabled = true;

        document.getElementById('style-rtl').disabled = false;
        //document.getElementById('bootstrap-rtl').disabled = false;
        
    }
    else {
        $('#iran-flag').css('opacity', '0.5');
        $('#us-flag').css('opacity', '1');
        document.getElementById('style-ltr').disabled = false;

        //document.getElementById('style-rtl').disabled = true;
        //document.getElementById('bootstrap-rtl').disabled = true;
       
    }
});

function setCookie(name, value, exdays, path) {
    var today = new Date();
    var expiry = new Date(today.getTime() + 30 * 24 * 3600 * 1000); // plus 30 days
    document.cookie = name + "=" + value + "; path=/; expires=" + expiry.toGMTString();
   
}
function getCookie(name) {
    var i, x, y, cookies = document.cookie.split(";");
    for (i = 0; i < cookies.length; i++) {
        x = cookies[i].substr(0, cookies[i].indexOf("="));
        y = cookies[i].substr(cookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x === name) {
            return unescape(y);
        }
    }
}