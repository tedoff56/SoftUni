let { expect } = require('chai');
let { lookupChar } = require('../charLookup');

describe('Lookup for a char by index in a string', () => {
    it('Should return undefined if the first parameter is not a string', () =>{
        expect(lookupChar([], 2)).to.be.undefined;
    })

    it('Should return undefined if the second parameter is not a number', () =>{
        expect(lookupChar('asd', [])).to.be.undefined;
    })

    it('Should return undefined if floating number is passed as index', () =>{
        expect(lookupChar('asd', 4.2)).to.be.undefined;
    })
    
    it('Should return undefined if both parameters are of the correct type but the value of the index is lower than string length', () =>{
        expect(lookupChar('asd', -1)).to.be.equal('Incorrect index');
    })

    it('Should return undefined if both parameters are of the correct type but the value of the index is higher than string length', () =>{
        expect(lookupChar('asd', 4)).to.be.equal('Incorrect index');
    })

    it('Should return the character at the specified index if both parameters have correct types and values ', () =>{
        expect(lookupChar('asd', 2)).to.be.equal('d');
    })    
    
    it('Should return the character at the specified index if both parameters have correct types and values ', () =>{
        expect(lookupChar('asd', 1)).to.be.equal('s');
    })
})
