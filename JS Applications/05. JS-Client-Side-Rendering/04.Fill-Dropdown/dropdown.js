import {html, render} from './node_modules/lit-html/node/lit-html.js';

const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

const dropList = document.getElementById('menu');

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

onLoad();

function onSubmit(e){
    e.preventDefault();
    const formData = new FormData(e.target);
    const item = formData.get('itemText');

    item && addItem(item);
    form.reset();
}

async function onLoad(){
    const response = await fetch(url);
    const data = await response.json();
    
    const itemsTemplate = Object.values(data).map(createItemTemplate);

    render(itemsTemplate, dropList);
}

function createItemTemplate(item){
    const itemTemplate = html`
    <option value="${item._id}">${item.text}</option>
    `;

    return itemTemplate;
}

async function addItem(item) {
    await fetch(url, {
        method: 'POST',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({text: item})
    });

    onLoad();
}