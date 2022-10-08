function add(number){
    let sum = number;

    let inner =  function(number2){
        sum += number2;
        return inner;
    }

    inner.toString = function() {return sum};

    return inner;
}


console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());