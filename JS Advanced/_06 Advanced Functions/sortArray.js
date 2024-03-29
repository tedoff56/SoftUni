function sortArr(...params){
    let [arr, sortType] = params;

    if(sortType === 'asc'){
        arr.sort((a, b) => a - b);
    }
    else{
        arr.sort((a, b) => b - a);
    }

    return arr;
}

console.log(sortArr([14, 7, 17, 6, 8], 'asc'));
console.log(sortArr([14, 7, 17, 6, 8], 'desc'));