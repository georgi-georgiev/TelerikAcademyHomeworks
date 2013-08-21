var map;
var x = 42.69;
var y = 23.35;
var z = 6;

var cities = [
	//paris
	{
		x: 48.52,
		y: 2.20,
		name: "Paris"
	},
	//vienna
	{
		x: 48.12,
		y: 16.22,
		name: "Vienna"
	},
	//london
	{
		x: 51.30,
		y: 0.70,
		name: "London"
	},
	//berlin
	{
		x:  52.30,
		y: 13.23,
		name: "Berlin"
	},
	//madrid
	{
		x: 40.23,
		y: 3.43,
		name: "Madrid"
	},
	//newYork
	{
		x: 40.43,
		y: 74,
		name: "New York"
	},
	//Los angelis
	{
		x: 34.03,
		y: 118.15,
		name: "Los Angelis"
	},
	//washington
	{
		x: 38.53,
		y: 77.02,
		name: "Washington"
	},
	//Oslo
	{
		x: 59.55,
		y: 10.45,
		name: "Oslo"
	},
	//Rio
	{
		x: 22.54,
		y: 43.11,
		name: "Rio de Janeiro"
	}
];
var currentCity = 0;

function initialize() {
    var mapOptions = {
        zoom: z,
        center: new google.maps.LatLng(cities[currentCity].x, cities[currentCity].y),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);
}

document.getElementById('get-previous').addEventListener('click', function () {
	currentCity--;
	if(currentCity == -1)
	{
		currentCity = 9;
	}
    x=cities[currentCity].x;
	y=cities[currentCity].y;
	var pos = new google.maps.LatLng(x, y);
	map.panTo(pos);
	
	if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var infowindow = new google.maps.InfoWindow({
                map: map,
                position: pos,
                content: "Town: " + cities[currentCity].name
            });
            map.setCenter(pos);
        }, function () {
            handleNoGeolocation(true);
        });
    } else {
        handleNoGeolocation(false);
    }
	
}, false);

document.getElementById('get-next').addEventListener('click', function () {
	currentCity++;
	if(currentCity == 9)
	{
		currentCity = 0;
	}
    x=cities[currentCity].x;
	y=cities[currentCity].y;
	var pos = new google.maps.LatLng(x, y);
	map.panTo(pos);
	if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var infowindow = new google.maps.InfoWindow({
                map: map,
                position: pos,
                content: "Town: " + cities[currentCity].name
            });
            map.setCenter(pos);
        }, function () {
            handleNoGeolocation(true);
        });
    } else {
        handleNoGeolocation(false);
    }
	
}, false);

function handleNoGeolocation(errorFlag) {
    if (errorFlag) {
        var content = 'Error: The Geolocation service failed.';
    } else {
        var content = 'Error: Your browser doesn\'t support geolocation.';
    }

    var options = {
        map: map,
        position: new google.maps.LatLng(42.69, 23.35),
        content: content
    };

    var infowindow = new google.maps.InfoWindow(options);
    map.setCenter(options.position);
}

google.maps.event.addDomListener(window, 'load', initialize());

console.log(map);