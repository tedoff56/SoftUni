function addOrRemoveElement(input){
    let currentNumber = 0;
    let result = [];

    for (const command of input){
        if(command === 'add'){
            currentNumber++; 
            result.push(currentNumber)
        }
        else if(command === 'remove'){
            currentNumber++; 
            result.pop();
        }  
    }

    if(result.length !== 0){
        result.forEach(n => console.log(n));
    }
    else{
        console.log('Empty');
    }
}

addOrRemoveElement([
    'add', 
    'add', 
    'add', 
    'add']);