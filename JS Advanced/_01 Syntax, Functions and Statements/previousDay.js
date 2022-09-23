function getPreviousDay(...dateData){

    let date = new Date(dateData)

    let [year, month, day] = [date.getUTCFullYear(), date.getUTCMonth() + 1, date.getUTCDate()]

    return `${year}-${month}-${day}`;
}

console.log(getPreviousDay(2016, 9, 30));
console.log(getPreviousDay(2016, 10, 1));