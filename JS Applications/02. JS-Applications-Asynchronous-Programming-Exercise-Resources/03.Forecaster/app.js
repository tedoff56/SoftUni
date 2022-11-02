function attachEvents() {
    let location = document.getElementById('location');
    let button = document.getElementById('submit');

    let forecast = document.getElementById('forecast');
    let current = document.getElementById('current');
    let upcoming = document.getElementById('upcoming');
    
    forecast.style.display = 'none';


    button.addEventListener('click', getWeather);

    let getSymbol = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;'
    };

    async function getWeather(){
        current.innerHTML = '';
        upcoming.innerHTML = '';

        //get logations
        
        let locationsResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/locations`);
        let locations = await locationsResponse.json();

        let locationCode = '';
        for (let locationData of locations) {
            if(locationData.name === location.value){
                locationCode = locationData.code;
            }
        }

        debugger;
        
        
        try{
        //get current condition
        let currentConditionResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`)
        let currentContitionData = await currentConditionResponse.json();

        //get 3 days forecast
        let threeDayForecastResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`)
        let threeDayForecastData = await threeDayForecastResponse.json()

        forecast.style.display = 'block';
        renderCurrent(currentContitionData);
        renderThreeDayForecast(threeDayForecastData)
        
        }
        catch(error){
            forecast.style.display = 'block';
            forecast.textContent = 'Error';
        }


    }

    function renderThreeDayForecast(threeDayForecastData){
        let divInfo = document.createElement('div');
        divInfo.classList.add('forecast-info');
        for (const day of threeDayForecastData.forecast) {
            let spanUpcoming = document.createElement('span');
            spanUpcoming.classList.add('upcoming');

            let spanSymbol = document.createElement('span');
            spanSymbol.classList.add('symbol');
            spanSymbol.innerHTML = getSymbol[day.condition];
            spanUpcoming.appendChild(spanSymbol);

            let spanTemp = document.createElement('span');
            spanTemp.classList.add('forecast-data');
            spanTemp.innerHTML = `${day.low}${getSymbol['Degrees']}/${day.high}${getSymbol['Degrees']}`;
            spanUpcoming.appendChild(spanTemp);

            let spanCondition = document.createElement('span');
            spanCondition.classList.add('forecast-data');
            spanCondition.textContent = day.condition;
            spanUpcoming.appendChild(spanCondition);

            divInfo.appendChild(spanUpcoming);
        }

        upcoming.appendChild(divInfo);
    }

    function renderCurrent(currentContitionData){
        let forecast = currentContitionData.forecast;

        let divForecasts = document.createElement('div');
        divForecasts.classList.add('forecasts');

        let spanSymbol = document.createElement('span');
        spanSymbol.classList.add('condition');
        spanSymbol.classList.add('symbol');
        spanSymbol.innerHTML = getSymbol[forecast.condition];
        divForecasts.appendChild(spanSymbol);

        let span = document.createElement('span');
        span.classList.add('condition');

        let spanCity = document.createElement('span');
        spanCity.classList.add('forecast-data');
        spanCity.textContent = currentContitionData.name;
        span.appendChild(spanCity);

        let spanTemp = document.createElement('span');
        spanTemp.classList.add('forecast-data');
        spanTemp.innerHTML = `${forecast.low}${getSymbol['Degrees']}/${forecast.high}${getSymbol['Degrees']}`;
        span.appendChild(spanTemp);
        
        let spanCondition = document.createElement('span');
        spanCondition.classList.add('forecast-data');
        spanCondition.textContent = forecast.condition;
        span.appendChild(spanCondition);

        divForecasts.appendChild(span);
        current.appendChild(divForecasts);
    }

}

attachEvents();