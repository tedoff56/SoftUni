function Speed(input)
{
    let speed = Number(input[0]);
    let info = null;

    if(speed <= 10)
    {
        info = "slow"
    }
    else if(speed > 10 && speed <= 50)
    {
        info = "average";
    }
    else if(speed > 50 && speed <= 150)
    {
        info = "fast";
    }
    else if(speed > 150 && speed <= 1000)
    {
        info = "ultra fast";
    }
    else
    {
        info = "extremely fast";
    }

    console.log(info);
}