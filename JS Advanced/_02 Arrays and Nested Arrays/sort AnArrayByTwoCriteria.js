function orderByTwoCriteria(stringsArr){
    stringsArr
        .sort((a, b) => a.length - b.length || a.localeCompare(b))
        .forEach(s => console.log(s));
}

orderByTwoCriteria(
    ['alpha', 
    'beta', 
    'gamma']);