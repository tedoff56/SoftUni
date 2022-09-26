function rotateArray(stringsArr, totalRotations){
    for (let i = 0; i < totalRotations; i++) {
        stringsArr.unshift(stringsArr.pop());
    }

    console.log(stringsArr.join(' '));
}

rotateArray([
    '1', 
    '2', 
    '3', 
    '4'], 
    2);

    rotateArray(['Banana', 
    'Orange', 
    'Coconut', 
    'Apple'], 
    15
    );