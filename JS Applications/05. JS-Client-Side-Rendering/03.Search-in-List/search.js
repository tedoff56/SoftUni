import {html, render} from './node_modules/lit-html/node/lit-html.js';
import {towns as data} from './towns.js';

const btn = document.querySelector('button');
btn.addEventListener('click', search);

renderTowns(data);

function search(e) {
   const searchText = document.getElementById('searchText');
   const text = searchText.value;

   renderTowns(data, text);
   renderMatches();
}

function renderMatches(){
   const divResult = document.getElementById('result');

   const matches = document.querySelectorAll('.active').length;
   const result = matches ? html`<p>${matches} matches found</p>` : '';

   render(result, divResult);
}

function renderTowns(data, search = ''){
   const divTowns = document.getElementById('towns');

   const result = html`
      <ul>${data.map(t => createItem(t, search))}</ul>`;

   render(result, divTowns);
}

function createItem(item, search){
   const li = html`
      <li class="${search && item.includes(search) ? 'active' : ''}">${item}</li>`;

   return li;
}
