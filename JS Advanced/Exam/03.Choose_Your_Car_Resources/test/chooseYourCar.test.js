let chooseYourCar = require(`../chooseYourCar`);
let {assert} = require('chai');

describe('Test chooseYourCar', () =>{
    describe('choosingType', () => {
        it('Should throw if year is invalid', ()=>{
            let exp = 'Invalid Year!';
            assert.throw(() => (chooseYourCar.choosingType('Sedan', 'Blues', 1899)), exp);
            assert.throw(() => (chooseYourCar.choosingType('Sedan', 'Blues', 2023)), exp);
        })
        it('Shoud return correct message if year > 2010', () =>{
            let exp = 'This Blue Sedan meets the requirements, that you have.';
            assert.equal(chooseYourCar.choosingType('Sedan', 'Blue', 2011), exp);
        })
        it('Shoud return correct message if year = 2010', () =>{
            let exp = 'This Blue Sedan meets the requirements, that you have.';
            assert.equal(chooseYourCar.choosingType('Sedan', 'Blue', 2010), exp);
        })
        it('Shoud return correct message if year < 2010', () =>{
            let exp = 'This Sedan is too old for you, especially with that Blue color.';
            assert.equal(chooseYourCar.choosingType('Sedan', 'Blue', 2009), exp);
        })
        it('Should throw if type is invalid', ()=>{
            let exp = 'This type of car is not what you are looking for.';
            assert.throw(() => (chooseYourCar.choosingType('ab', 'Blues', 1900)), exp);
        })
    })
    describe('brandName', () => {
        it('Should throw if invalid info', () => {
            let exp = 'Invalid Information!';
            assert.throw(() => chooseYourCar.brandName(['Nissan', 'Vw'], 2), exp)
            assert.throw(() => chooseYourCar.brandName(['Nissan', 'Vw'], -1), exp)
            assert.throw(() => chooseYourCar.brandName(['Nissan', 'Vw'], 'NaN'), exp)
        })

        it('Should return correct info', () => {
            let exp = 'Nissan, Mercedes';
            assert.equal(chooseYourCar.brandName(['Nissan', 'Vw', 'Mercedes'], 1), exp)
        })
    })
    describe('carFuelConsumption', () => {
        it('Should throw if invalid info', () =>{
            let exp = 'Invalid Information!';
            assert.throw(() => chooseYourCar.carFuelConsumption('NaN', 5), exp)
            assert.throw(() => chooseYourCar.carFuelConsumption(5, 'NaN'), exp)
            assert.throw(() => chooseYourCar.carFuelConsumption(-1, 5), exp)
            assert.throw(() => chooseYourCar.carFuelConsumption(5, -1), exp)
            assert.throw(() => chooseYourCar.carFuelConsumption(0, 5), exp)
            assert.throw(() => chooseYourCar.carFuelConsumption(5, 0), exp)
        })
        it('Should return correct info if consumptedFuelInLiters < 7', () =>{
            let consumptedFuelInLiters = 6;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);
            let exp = `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`
            assert.equal(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters), exp);
        })
        it('Should return correct info if consumptedFuelInLiters = 7', () =>{
            let consumptedFuelInLiters = 7;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);
            let exp = `The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`
            assert.equal(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters), exp);
        })

        it('Should return correct info if consumptedFuelInLiters > 7', () =>{
            let consumptedFuelInLiters = 8;
            let distanceInKilometers = 100;
            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);
            let exp = `The car burns too much fuel - ${litersPerHundredKm} liters!`
            assert.equal(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters), exp);
        })
    })
})