class VegetableStore{
    constructor(owner, location){
        this.owner = owner;
        this.location = location;
        this.availableProducts = []; 
    }

    revision (){
        let result = 'Available vegetables:';

        this.availableProducts
            .sort((a, b) => a.price - b.price)
            .forEach(p => result += `\n${p.type}-${p.quantity}-$${p.price}`);

        result += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`

        return result;
    }

    rottingVegetable (type, quantity){
        let product = this.availableProducts.find(p => p.type === type);

        if(!product){
            throw Error(`${type} is not available in the store.`)
        }

        if(quantity > product.quantity){
            product.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        product.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    buyingVegetables (selectedProducts){
        let totalPrice = 0;

        for(let productData of selectedProducts){
            let [type, quantity] = productData.split(' ');
            quantity = Number(quantity);

            let product = this.availableProducts.find(p => p.type === type);

            if(!product){
                throw Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            if(quantity > product.quantity){
                throw Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            totalPrice += product.price * quantity;
            product.quantity -= quantity;

        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    loadingVegetables(vegetables){
        let buff = [];
        for(let vegetableData of vegetables){
            let [type, quantity, price] = vegetableData.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            let product = this.availableProducts.find(p => p.type === type);

            if(!product){
                this.availableProducts.push({type, quantity, price});
                buff.push(type);
                continue;
            }

            product.quantity += quantity;
            if(price > product.price){
                product.price = price;
            }

        }
        return `Successfully added ${buff.join(', ')}`;
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());



