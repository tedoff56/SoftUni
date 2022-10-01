function solve() {
  let textToTransform = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');

  let words = textToTransform.split(' ');
  let resultString = '';

  switch(namingConvention){
    case 'Camel Case':
      words.forEach((w, i) => {
        if(i === 0){
          return resultString += w[0].toLowerCase() + w.substring(1).toLowerCase();
        }
        return resultString += w[0].toUpperCase() + w.substring(1).toLowerCase();
      })
      break;
      case 'Pascal Case':
        words.forEach((w, i) => {
          return resultString += w[0].toUpperCase() + w.substring(1).toLowerCase();
        })
        break;
        default: resultString = 'Error!';
  }

  result.textContent = resultString;
}