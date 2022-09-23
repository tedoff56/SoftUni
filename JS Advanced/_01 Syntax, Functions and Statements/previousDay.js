function getPreviousDay(...dateData){

    let date = new Date(dateData)

    let year = date.getUTCFullYear();
    let month = date.getUTCMonth() + 1;
    let day = date.getUTCDate();

    return `${year}-${month}-${day}`;
}

console.log(getPreviousDay(2016, 9, 30));
console.log(getPreviousDay(2016, 10, 1));