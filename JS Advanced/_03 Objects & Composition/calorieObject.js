function compose(input){
    let products = {};

    for (let i = 0; i < input.length; i+=2) {
        let food = input[i];
        let calories = Number(input[i + 1]);
        products[food] = calories;
    }

    console.log(products);
}

compose(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);

