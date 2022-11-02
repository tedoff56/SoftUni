 function solve() {
    let info = document.getElementsByClassName('info')[0];
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let currentStopName = '';
    let nextStopId = 'depot';

    async function depart() {
        try{
            const response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`)
            const stop = await response.json();
            info.textContent = `Next stop ${stop.name}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
            nextStopId = stop.next;
            currentStopName = stop.name;
        }
        catch(error){
            info.textContent = 'Error';
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }   

    function arrive() {
        info.textContent = `Arriving at ${currentStopName}`;
        arriveBtn.disabled = true;
        departBtn.disabled = false;
    }
    
    return {
        depart,
        arrive
    };
}

let result = solve();