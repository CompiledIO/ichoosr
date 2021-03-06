L.mapbox.accessToken = 'pk.eyJ1IjoiY29tcGlsZWRpbyIsImEiOiJjbDBmcHFrNm4waWhmM2JtdG11cW92Y2tmIn0.FpfMLrZfuoLpiBTYSkJvZA';

var map = L.mapbox.map('map')
    .setView([37.77396, -122.4366], 12)
    .addLayer(L.mapbox.styleLayer('mapbox://styles/mapbox/streets-v11'));

var myFeatureLayer = L.mapbox.featureLayer('/mapbox.js/assets/data/sf_locations.geojson')
    .addTo(map);

// Open popup when user mouses over a marker
myFeatureLayer.on('ready', function (e) {
    var markers = [];
    this.eachLayer(function (marker) { markers.push(marker); });
    cycle(markers);
});

function cycle(markers) {
    var i = 0;
    function run() {
        if (++i > markers.length - 1) i = 0;
        map.setView(markers[i].getLatLng(), 12);
        markers[i].openPopup();
        window.setTimeout(run, 3000);
    }
    run();
}
