(function ($) {

    function showModel(settings) {

        var defaults = {
            counter: '#counter',
            mainTemplate: '#itemTemplate',
            url: '/Home/GetLinks?page=',
            putThere: "#puthere",
            userSettings: '#editContainer',
            userLogged: 'username',
            button: 'button',
            fun: function(user,str,adminSettings,author) {
                if (user === author) {
                   return str = str.replace('{containerForAdmin}', adminSettings);
                } else {
                    return str = str.replace('{containerForAdmin}', '');
                }
            }
    }




        if (settings) { $.extend(defaults, settings); }
        $(defaults.counter).val(function(i, oldval) {
            return ++oldval;
        });
        var page =defaults.counter.value;
        var str = $(defaults.mainTemplate).html();
        var admin = $(defaults.userSettings).html();
        var user = document.getElementById(defaults.userLogged).value;
        $.getJSON(defaults.url + page, { get_param: 'value' }, function(data) {
            $.each(data, function (index, element) {
               str= defaults.fun(user, str, admin, element['Author']);
                for (var prop in element) {
                    if (element.hasOwnProperty(prop)) {
                        var property = new RegExp('{' + prop + '}', 'g');
                        str = str.replace(property, element[prop]);
                    }
                }
                $(defaults.putThere).append(str);
                str = $(defaults.mainTemplate).html();
            });
        });
    }
    window.onscroll = function() {
        if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
            showModel();
        }
    };
    $(document).ready(function() {

        if ($("body").height() < $(window).height()) {
            showModel();
        }


    });
}(jQuery));