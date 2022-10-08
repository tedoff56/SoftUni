
function fibonacci(){
    let n1 = 0;
    let n2 = 1;
    let nextTerm;

    return function () {
        nextTerm = n1 + n2;
        n1 = n2;
        n2 = nextTerm;
    
        return n1;
    };
}

let currentNum = fibonacci();

console.log(currentNum());
console.log(currentNum());
console.log(currentNum());