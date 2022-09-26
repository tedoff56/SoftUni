function extract(numbersArr){
    let result = [];
    let biggestNumber = numbersArr[0];
    
    numbersArr.forEach(n => {
        if(n >= biggestNumber){
            biggestNumber = n;
            result.push(n);
        }
    })

    return result;
}

console.log(extract([
    1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]));