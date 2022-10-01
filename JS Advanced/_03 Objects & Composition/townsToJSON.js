function townsToJson(input){
    let result = [];
    let regex = new RegExp(/\s*\|\s*/);

    for (const townData of input.slice(1)) {

        let [town, latitude, longitude] = townData.split(regex).filter(Boolean);

        result.push({
            Town: town, 
            Latitude: Math.round( latitude * 1e2 ) / 1e2, 
            Longitude: Math.round( longitude * 1e2 ) / 1e2
        });

    }

    return JSON.stringify(result);
}

console.log(townsToJson([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']));

