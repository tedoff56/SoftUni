function checkDigits(number){
    
    let numberArr = Array.from(number.toString()).map(d => Number(d));

    let areAllSame = numberArr.every(d => d === numberArr[0]);
    let sum = numberArr.reduce((partialSum, a) => partialSum + a)

    console.log(areAllSame);
    console.log(sum);
}

checkDigits(2222222);
checkDigits(1234)