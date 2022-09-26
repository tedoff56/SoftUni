function printWithDelimiter(...input){

    let separator = input.pop();
    
    let result = input[0].join(separator);
    
    console.log(result)
}

printWithDelimiter(
    ['One', 
    'Two', 
    'Three', 
    'Four', 
    'Five'], 
    '-')

printWithDelimiter(
    ['How about no?', 
    'I',
    'will', 
    'not', 
    'do', 
    'it!'], 
    '_')
