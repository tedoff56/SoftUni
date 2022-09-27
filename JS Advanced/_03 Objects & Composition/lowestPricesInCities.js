function lowestPrice(input){
    let result = [];

    for (const townData of input) {
        let [townName, productName, productPrice] = townData.split(' | ');

        productPrice = Number(productPrice);

        let product = result.find(r => r.productName === productName);

        if(product === undefined){
            result.push({productName, productPrice, townName})
            continue;
        }

        if(productPrice < town.productPrice){
            town.townName = townName;
            town.productPrice = productPrice;
        }

    }

    result.forEach(r => console.log(`${r.productName} -> ${r.productPrice} (${r.townName})`))
}

lowestPrice([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);