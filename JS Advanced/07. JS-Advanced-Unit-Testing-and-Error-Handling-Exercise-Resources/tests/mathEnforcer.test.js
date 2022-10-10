let { expect } = require('chai');
let { mathEnforcer } = require('../mathEnforcer');

describe('addFive', () => {
    it('Should return undefined if the parameter is NOT a number', () =>{
        expect(mathEnforcer.addFive([])).to.be.undefined;
    })

    it('Should return correct result if the parameter is a number', () =>{
        expect(mathEnforcer.addFive(1)).to.be.equal(6);
    })

    it('Should return 6.2', () => {
        expect(mathEnforcer.addFive(1.2)).to.closeTo(6.2, 0.01);
    });

    it('Should return -2', () => {
        expect(mathEnforcer.addFive(-7)).to.closeTo(-2, 0.01);
    });
})

describe('subtractTen', () => {
    it('Should return undefined if the parameter is NOT a number', ()=> {
        expect(mathEnforcer.subtractTen([])).to.be.undefined;
    })

    it('Should return correct result if the parameter is a number', ()=> {
        expect(mathEnforcer.subtractTen(11)).to.be.equal(1);
    })

    it('Should return -5.8', () => {
        expect(mathEnforcer.subtractTen(4.2)).to.closeTo(-5.8, 0.01);
    });

    it('Should return -7', () => {
        expect(mathEnforcer.subtractTen(3)).to.equal(-7);
    });

    it('Should return -5', () => {
        expect(mathEnforcer.subtractTen(5)).to.equal(-5);
    });
})

describe('sum', () => {
    it('Should return undefined if first parameter is NOT a number', ()=> {
        expect(mathEnforcer.sum([], 2)).to.be.undefined;
    })

    it('Should return undefined if second parameter is NOT a number', ()=> {
        expect(mathEnforcer.sum(2, [])).to.be.undefined;
    })

    it('Should return undefined if no parameters are passed', ()=> {
        expect(mathEnforcer.sum()).to.be.undefined;
    })

    it('Should return undefined if one parameter is passed', ()=> {
        expect(mathEnforcer.sum(2)).to.be.undefined;
    })

    it('Should return sum if first and second parameters are numbers', ()=> {
        expect(mathEnforcer.sum(2, 2)).to.be.equal(4);
    })

    it('Should return -2', ()=> {
        expect(mathEnforcer.sum(2, -4)).to.be.equal(-2);
    })

    it('Should return -4.2', ()=> {
        expect(mathEnforcer.sum(-2, -2.2)).to.be.closeTo(-4.2, 0.01);
    })
})