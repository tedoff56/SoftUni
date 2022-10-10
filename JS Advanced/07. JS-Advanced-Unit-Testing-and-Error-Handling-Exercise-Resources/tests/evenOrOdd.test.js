let { expect } = require('chai');
let { isOddOrEven } = require('../evenOrOdd');

describe('Is even or odd', () => {
    it('Should return undefined if passed a  number', () => {
        expect(isOddOrEven(0)).to.be.undefined;
    })

    it('Should return undefined if passed an array', () => {
        expect(isOddOrEven([])).to.be.undefined;
    })

    it('Should return even', () => {
        expect(isOddOrEven('12')).to.be.equal('even');
    })

    it('Should return odd', () => {
        expect(isOddOrEven('123')).to.be.equal('odd');
    })

    it('Should return even', () => {
        expect(isOddOrEven('asdasd')).to.be.equal('even');
    })
})
