
function SumSeconds(input)
{

    let totalSeconds = Number(input[0]) + Number(input[1]) + Number(input[2]);

    let minutes = Math.floor(totalSeconds / 60);
    let seconds = totalSeconds % 60 < 10 ? "0" + totalSeconds % 60 : totalSeconds % 60;

    console.log(minutes + ":" + seconds)
}

SumSeconds(["35","45","44"]);
