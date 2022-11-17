import { render, html } from './node_modules/lit-html/node/lit-html.js';
import { cats } from './catSeeder.js';

const section = document.getElementById('allCats');

renderCards();

function showInfo(e){
    const btn = e.target;

    const div = e.target.parentElement.querySelector('.status');

    if(div.style.display === 'none'){
        div.style.display = 'block';
        btn.textContent = 'Hide status code';
    }
    else{
        div.style.display = 'none';
        btn.textContent = 'Show status code';
    }
}

function renderCards(){
    const result = html`
        <ul>
            ${cats.map(createCard)}
        </ul>
    `;

    render(result, section);
}

function createCard(cat) {
    const card = html`
        <li>
            <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn" @click="${showInfo}" id="${cat.id}">Show status code</button>
                <div class="status" style="display: none" id="100">
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
            </div>
        </li>`;

    return card;
}