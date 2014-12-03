(function (window) {
    'use strict';

    window.addEventListener('unload', function () {
        var rum = {
                navigation: performance.timing,
                resources: performance.getEntriesByType('resource'),
                marks: performance.getEntriesByType('mark'),
                measures: performance.getEntriesByType('measure')
            };

        rum = reduce(rum);

        console.log('Beacon Queued: ', navigator.sendBeacon('/rum/submit', JSON.stringify(rum)));
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

        // convert to [name, duration, startTime]
        rum.marks = rum.marks.map(function (e) { return [e.name, e.duration, e.startTime]; });

        // convert to [name, duration, startTime]
        rum.measures = rum.measures.map(function (e) { return [e.name, e.duration, e.startTime]; });

        return rum;
    }
})(this);