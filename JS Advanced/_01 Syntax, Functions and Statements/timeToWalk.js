    //s=v*t
    //s - път
    //v - скорост
    //t - време
function calculateTimeToUniversity(steps, footPrintLength, v){
    let s = (steps * footPrintLength) / 1000; // Km
    let t = s / v;

    let restTime = Math.floor(s / 0.5);

    let hours = Math.floor(t);
    hours = hours < 10 ? '0' + hours : hours;

    let minutes = Math.floor(t * 60) + restTime;
    minutes = minutes < 10 ? '0' + minutes : minutes;

    let seconds = (((t*60)%1)*60).toFixed(0) //[sec]

    console.log(`${hours}:${minutes}:${seconds}`)
}

calculateTimeToUniversity(4000, 0.60, 5);
calculateTimeToUniversity(2564, 0.70, 5.5);