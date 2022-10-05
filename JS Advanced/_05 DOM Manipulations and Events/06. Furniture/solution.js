function solve() {

  let [generateButton, buyButton] = Array.from(document.querySelectorAll('button'));

  let [furnitureJson, furnitureBuyData] = Array.from(document.querySelectorAll('textarea'));

  let tBody = document.querySelector('tbody');

  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', buy);

  let items = [];

  function generate(){

    for(let furniture of JSON.parse(furnitureJson.value)){
      
      let tr = document.createElement('tr');
  
      let tdImg = document.createElement('td');
      let img = document.createElement('img');
      img.src = furniture.img;
      tdImg.appendChild(img);
      tr.appendChild(tdImg);
  
      let tdName = document.createElement('td');
      tdName.innerHTML = `<p>${furniture.name}</p>`;
      tr.appendChild(tdName);
  
      let tdPrice = document.createElement('td');
      tdPrice.innerHTML = `<p>${furniture.price}</p>`;
      tr.appendChild(tdPrice);
  
      let tdDecFactor = document.createElement('td');
      tdDecFactor.innerHTML = `<p>${furniture.decFactor}</p>`;
      tr.appendChild(tdDecFactor);
  
      let tdCheck = document.createElement('td');
      let input = document.createElement('input');
      input.type = 'checkbox';
      tdCheck.appendChild(input);
      tr.appendChild(tdCheck);

      tBody.appendChild(tr);
  
      items.push({
        ...furniture,
        isChecked
    });

      function isChecked(){
        return input.checked;
      }
    }
  
  }
  
  function buy() {
    let bought = items.filter(i => i.isChecked());
  
    let names = [];
    let totalPrice = 0;
    let totalDec = 0;
  
    let result = [];

    for(let furniture of bought){
      names.push(furniture.name);
      totalPrice += furniture.price;
      totalDec += furniture.decFactor;
    }
    
    result.push(`Bought furniture: ${names.join(', ')}`);
    result.push(`Total price: ${totalPrice.toFixed(2)}`);
    result.push(`Average decoration factor: ${totalDec /= bought.length}`);

    furnitureBuyData.value = result.join('\n');
    
  }
}