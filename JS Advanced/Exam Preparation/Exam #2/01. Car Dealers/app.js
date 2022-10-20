window.addEventListener("load", solve);

function solve() {
  let make = document.getElementById('make');
  let model = document.getElementById('model');
  let year = document.getElementById('year');
  let fuel = document.getElementById('fuel');
  let originalCost = document.getElementById('original-cost');
  let sellingPrice = document.getElementById('selling-price');

  document.getElementById('publish').addEventListener('click', publish);

  let tBody = document.getElementById('table-body');
  let carsList = document.getElementById('cars-list');
  let profit = document.getElementById('profit');

  function publish(e){
    e.preventDefault();

    if(!make.value || !model.value || !year.value || !fuel.value || !originalCost.value || !sellingPrice.value){
      return;
    }

    if(originalCost.value > sellingPrice.value){
      return;
    }

    createRow();

    make.value = '';
    model.value = '';
    year.value = '';
    fuel.value = '';
    originalCost.value = '';
    sellingPrice.value = '';

  }

  function sell(e){
    let row = e.target.parentElement.parentElement;
    let data = Array.from(row.querySelectorAll('td'));

    let priceDiff = Number(data[5].textContent) - Number(data[4].textContent);

    let li = document.createElement('li');
    li.classList.add('each-list');

    li.innerHTML += `<span>${data[0].textContent} ${data[1].textContent}</span>`;
    li.innerHTML += `<span>${data[2].textContent}</span>`;
    li.innerHTML += `<span>${priceDiff}</span>`;

    carsList.appendChild(li);
    calculateProfit();

    row.remove();
  }

  function calculateProfit(){
    let sum = 0;

    Array.from(document.getElementsByClassName('each-list')).forEach(e => {
      sum += Number(e.lastChild.textContent);
    })

    profit.textContent = sum.toFixed(2);
  }

  function edit(e){
    let row = e.target.parentElement.parentElement;
    let data = Array.from(row.querySelectorAll('td'));
    make.value = data[0].textContent;
    model.value = data[1].textContent;
    year.value = data[2].textContent;
    fuel.value = data[3].textContent;
    originalCost.value = data[4].textContent;
    sellingPrice.value = data[5].textContent;

    row.getElementsByClassName('edit')[0].parentElement.parentElement.remove();
  }

  function createRow(){
    let tr = document.createElement('tr');
    tr.classList.add('row');

    let tdMake = document.createElement('td');
    tdMake.textContent = make.value;
    tr.appendChild(tdMake);

    let tdModel = document.createElement('td');
    tdModel.textContent = model.value;
    tr.appendChild(tdModel);

    let tdYear = document.createElement('td');
    tdYear.textContent = year.value;
    tr.appendChild(tdYear);
    
    let tdFuel = document.createElement('td');
    tdFuel.textContent = fuel.value;
    tr.appendChild(tdFuel);

    let tdOriginalCost = document.createElement('td');
    tdOriginalCost.textContent = originalCost.value;
    tr.appendChild(tdOriginalCost);

    let tdSellingPrice = document.createElement('td');
    tdSellingPrice.textContent = sellingPrice.value;
    tr.appendChild(tdSellingPrice);

    let editBtn = document.createElement('button');
    editBtn.classList.add('action-btn', 'edit');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', edit);

    let sellBtn = document.createElement('button');
    sellBtn.classList.add('action-btn', 'sell');
    sellBtn.textContent = 'Sell';
    sellBtn.addEventListener('click', sell);
    
    let tdBtns = document.createElement('td');
    tdBtns.appendChild(editBtn);
    tdBtns.appendChild(sellBtn);
    tr.appendChild(tdBtns);

    tBody.appendChild(tr);
  }

}
