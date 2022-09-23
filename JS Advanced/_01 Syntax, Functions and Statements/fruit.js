function calculateMoneyToBuyFruit(...fruitData){

    let [fruit, weightInGrams, pricePerKg] = fruitData;

    let weightInKg = Number(weightInGrams) / 1000;
    let totalMoneyNeeded = weightInKg * Number(pricePerKg);

    console.log(`I need $${totalMoneyNeeded.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`)
}

calculateMoneyToBuyFruit('orange', 2500, 1.80);
calculateMoneyToBuyFruit('apple', 1563, 2.35);