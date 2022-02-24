/* Cookie manager */
var cookie_manager = cookie_manager || {};
cookie_manager = {
    set_cookie: function (cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        var domain = location.hostname.split('.').reverse()[1] + "." + location.hostname.split('.').reverse()[0];
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/;domain=." + domain;

        if (domain != undefined && domain.indexOf("localhost") > - 1) {
            domain = "localhost";
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/;domain=" + domain;
        }
    },
    get_cookie: function (cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
};