function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');

  
  let sentences = input.split('.').filter(s => s.length > 0);


  for (let i = 0; i < sentences.length; i += 3) {
    let temp = '';

    for (let x = 0; x < 3; x++){
      if(sentences[i + x]){
        temp += sentences[i + x].trim();
      }
    }

    output.innerHTML += `<p>${temp}.</p>\n`;
    temp = '';
  }
}