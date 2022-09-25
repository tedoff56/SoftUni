function validate(x1, y1, x2, y2){

    function distance(x1, y1, x2, y2){
        return Math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
    }

    let valuesToCompare = [
        [x1, y1, 0, 0],
        [x2, y2, 0, 0],
        [x1, y1, x2, y2]];

    for (const values of valuesToCompare) {
        let status = Number.isInteger(distance(...values)) ? 'valid' : 'invalid';
        console.log(`{${values[0]}, ${values[1]}} to {${values[2]}, ${values[3]}} is ${status}`)
    }
}

validate(3, 0, 0, 4);
validate(2, 1, 1, 1);