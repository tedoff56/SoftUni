function sort(names){
    names = names.sort((a, b) => a.localeCompare(b));
    
    names.forEach((n, i) => { console.log(`${i + 1}.${n}`) });
}

sort(["John", "Bob", "Christina", "Ema"]);