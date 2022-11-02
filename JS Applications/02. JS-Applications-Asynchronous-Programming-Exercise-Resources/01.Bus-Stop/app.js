async function getInfo() {
    let stopId = document.getElementById('stopId');
    let buses = document.getElementById('buses');
    let stopName = document.getElementById('stopName');

    stopName.textContent = '';
    buses.innerHTML = '';

    try{
        const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`;
        const response = await fetch(url);
        let stopData = await response.json();
    
        buses.innerHTML = '';
        stopName.textContent = stopData.name;
    
        for (const [busId, time] of Object.entries(stopData.buses)) {
            let li = document.createElement('li');
            li.textContent = `Bus ${busId} arrives in ${time} minutes`;
            buses.appendChild(li);
        }
    }
    catch(error){
        stopName.textContent = 'Error';
    }
}