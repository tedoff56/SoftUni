function argumentInfo(...args){
    let typeCount = {};

    for (let argument of args) {
        let type = typeof(argument);
        let value = argument;

        console.log(`${type}: ${value}`);

        if(!typeCount[type]){
            typeCount[type] = 0;
        }

        typeCount[type]++;
    }

    let result = Object.entries(typeCount).sort((a, b) => b[1] - a[1]);

    for(let type of result){
        console.log(`${type[0]} = ${type[1]}`);
    }
}

// argumentInfo('cat', 42, function () { console.log('Hello world!'); })

argumentInfo({ name: 'bob'}, 3.333, 9.999);