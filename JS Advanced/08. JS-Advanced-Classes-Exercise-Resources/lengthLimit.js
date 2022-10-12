class Stringer{

    constructor(innerString , innerLength ){
        this.innerString  = innerString;
        this.innerLength  = Number(innerLength);
    }


    increase(length){
        this.innerLength += length;
    }

    decrease(length){
        let newStringLength = this.innerLength - Number(length);

        newStringLength < 0 ? 
        this.innerLength = 0 : 
        this.innerLength = newStringLength;
    }

    toString(){
        let result = this.innerString.substring(0, this.innerLength);

        this.innerLength < this.innerString.length ? 
        result += '...' : 
        result;

        return result;
    }
}


