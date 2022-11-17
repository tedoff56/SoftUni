import {render, html} from './node_modules/lit-html/node/lit-html.js';

const root = document.getElementById('root');
const form = document.querySelector('.content');
form.addEventListener('submit', load);

function load(e){
    e.preventDefault();
    const formData = new FormData(form);
    const data = formData.get('towns').split(', ');

    renderTownList(data)
    form.reset();
}

function renderTownList(data){
    const result = createElement(data);
    render(result, root);
}

function createElement(data){
    const townsTemplate = html`
    <ul>
        ${data.map(t => html`<li>${t}</li>`)}
    </ul>
    `;

    return townsTemplate;
}

