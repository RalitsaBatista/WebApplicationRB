
let lat = 60.192059;
let lon = 24.945831;
const apiKey = '33b6481666cb3e97bf888af54aa091b9';
//const apiUrl = 'http://api.openweathermap.org/data/2.5/weather?units=metric&lat=';
const apiUrl = 'http://api.openweathermap.org/data/2.5/weather?units=metric&lat=%lat%&lon=%lon%&appid=%appid%';

const getData = () => {
    $('#city').text('');
    $('#temp').html('');
    $('#wind').html('');
    $('#get-weather').attr('disabled', true);

    setTimeout(function () {

        //$.getJSON(apiUrl + lat + "&lon=" + lon + "&appid=" + apiKey, (data) => {
        let _apiUrl = apiUrl.replace('%lat%', lat).replace('%lon%', lon).replace('%appid%', apiKey);
        $.getJSON(_apiUrl, (data) => {
            let temp = data["main"]["temp"];
            let city = data["name"];
            let wind = data["wind"]["speed"];
            console.log(data);
            //alert('Temperature in ' + city + ' is ' + temp);
            $('#city').text(city);
            $('#temp').html(Math.round(temp) + '&deg;C');
            $('#wind').html(wind + ' m/sec');
            $('#get-weather').removeAttr('disabled');
        });

    }, 1000);
}

const getWeather = () => {
    if (navigator != null && "geolocation" in navigator) {

        const success = (pos) => {
            lat = pos.coords.latitude;
            lon = pos.coords.longitude;
            accuracy = pos.coords.accuracy;
            getData();
        }

        const error = (err) => {
            console.log('Err: ', err);
        }
        navigator.geolocation.getCurrentPosition(success, error);

    } else {
        getData();
    }
}

$(document).on('click', '#get-weather', () => {
    getWeather();
});

$(document).ready(() => {
    getWeather();
});