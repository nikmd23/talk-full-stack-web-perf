(function (window) {
    'use strict';

    window.addEventListener('unload', function () {
        var rum = {
                resources: performance.getEntriesByType('resource'),
                navigation: timing.getTimes(), // suped-up perfomance.timing via timing.js https://github.com/addyosmani/timing.js
                marks: performance.getEntriesByType('mark'),
                measures: performance.getEntriesByType('measure')
            };

        rum = reduce(rum);
        var data = JSON.stringify(rum);

        console.log(data.length);
        console.log('Beacon Queued: ', navigator.sendBeacon("/rum/submit", data));
    }, false);

    function reduce(rum) {
        var origin = window.location.origin;

        // convert to [name, initiatorType, connectTime, domainLookupTime, duration, fetchStart, redirectTime, e.startTime, responseTime, requestStart]
        rum.resources = rum.resources.map(function(e) {
            return [
                e.name.replace(origin, '').replace('/Content/Images', ''),
                e.initiatorType,
                e.connectEnd - e.connectStart,
                e.domainLookupEnd - e.domainLookupStart,
                e.duration,
                e.fetchStart,
                e.redirectEnd - e.redirectStart,
                e.startTime,
                e.responseEnd - e.responseStart,
                e.requestStart
            ];
        });

        // delete unneeded properties
        delete rum.navigation.loadEventStart;
        delete rum.navigation.loadEventEnd;
        delete rum.navigation.domainLookupStart;
        delete rum.navigation.domainLookupEnd;
        delete rum.navigation.unloadEventStart;
        delete rum.navigation.unloadEventEnd;
        delete rum.navigation.redirectStart;
        delete rum.navigation.redirectEnd;
        delete rum.navigation.connectStart;
        delete rum.navigation.connectEnd;

        // convert to [name, duration, startTime]
        rum.marks = rum.marks.map(function (e) { return [e.name, e.duration, e.startTime]; });

        // convert to [name, duration, startTime]
        rum.measures = rum.measures.map(function (e) { return [e.name, e.duration, e.startTime]; });

        return rum;
    }
})(this);