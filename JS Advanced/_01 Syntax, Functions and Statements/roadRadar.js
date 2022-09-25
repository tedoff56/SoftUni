function roadRadar(speed, area){

    let speedInArea = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    }

    let speedLimit = speedInArea[area];

    if(speed <= speedLimit){
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        return;
    }

    let difference = speed - speedLimit;
    let status = difference <= 20 ? 'speeding' : difference <= 40 ? 'excessive speeding' : 'reckless driving';

    console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`)
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');
