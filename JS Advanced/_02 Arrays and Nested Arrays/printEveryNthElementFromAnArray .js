function getEveryNthElement(...input){
    let n = input.pop();

    let result = input[0].filter((e, i, ) =>{
        if (i  % n === 0) {return 1;}
    });

    return result;
}

console.log(getEveryNthElement(
    ['5', 
    '20', 
    '31', 
    '4', 
    '20'], 
    2));