function breakfastRobot(){
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const recipes = {
        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        eggs: {protein: 5, fat: 1, flavour: 1},
        turkey: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10},
    }

    const commands = {
        restock,
        prepare,
        report
    };


    function manager(input) {
        let [command, argument, quantity] = input.split(' ');
        quantity = Number(quantity);
        return commands[command](argument, quantity);
    };

    function restock(microelement, quantity){
        stock[microelement] += quantity;
        return 'Success';
    }

    function prepare(recipeString, quantity){
        let recipe = Object.entries(recipes[recipeString]);

        recipe.forEach(m => m[1] *= quantity);

        for (let [microelement, required] of recipe) {
            if (stock[microelement] < required) {
                return `Error: not enough ${microelement} in stock`;
            }
        }

        for(let [microelement, required] of recipe){
            stock[microelement] -= required;
        }

        return 'Success';
    }

    function report(){
        return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour} `
    }

    return manager;
}



let manager = breakfastRobot();

// console.log(manager("restock flavour 50"));
// console.log (manager("prepare lemonade 4"));
// console.log (manager("restock carbohydrate 10"));
// console.log (manager("restock flavour 10"));
// console.log (manager("prepare apple 1"));
// console.log (manager("restock fat 10"));
// console.log (manager("prepare burger 1"));
// console.log (manager("report"));

console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));