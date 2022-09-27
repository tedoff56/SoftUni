function storeCatalogue(input){
    let result = [];

    for (const productData of input) {
        let [productName, productPrice] = productData.split(' : ');

        result.push({productName, productPrice: Number(productPrice), firstLetter: productName[0]})

    }

    result.sort((a, b) => a.productName.localeCompare(b.productName));

    let lastUsedLetter = '';
    for (let i = 0; i < result.length; i++) {

        let product = result[i];

        if(i === 0){
            console.log(product.firstLetter);
        }
        
        let nextProduct = result[i + 1];
        if(nextProduct !== undefined && product.firstLetter !== nextProduct.firstLetter){
            lastUsedLetter = product.firstLetter;
            console.log(` ${result[i].productName}: ${result[i].productPrice}`)
            console.log(nextProduct.firstLetter);
        }
        else{

            console.log(` ${result[i].productName}: ${result[i].productPrice}`)
        }
    }

}

storeCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);

console.log('-------------');

storeCatalogue(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
    )