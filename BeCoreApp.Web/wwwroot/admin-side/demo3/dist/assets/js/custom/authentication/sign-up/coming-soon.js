"use strict";
var KTSignupComingSoon = function () {
    var n, i, r, a;
    return {
        init: function () {
            var s, u;
                n = document.querySelector("#kt_coming_soon_counter_days"),
                i = document.querySelector("#kt_coming_soon_counter_hours"),
                r = document.querySelector("#kt_coming_soon_counter_minutes"),
                a = document.querySelector("#kt_coming_soon_counter_seconds"),
                s = new Date("Aug 30, 2021 15:37:25").getTime(),
                u = function () {
                    var e = (new Date).getTime(),
                        t = s - e,
                        o = Math.floor(t / 864e5),
                        u = Math.floor(t % 864e5 / 36e5),
                        l = Math.floor(t % 36e5 / 6e4),
                        c = Math.floor(t % 6e4 / 1e3);

                        n.innerHTML = o,
                        i.innerHTML = u,
                        r.innerHTML = l,
                        a.innerHTML = c

                }, setInterval(u, 1e3), u()
        }
    }
}();

KTUtil.onDOMContentLoaded((function () {
    KTSignupComingSoon.init()
}));