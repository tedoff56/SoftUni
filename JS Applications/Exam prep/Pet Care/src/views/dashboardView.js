import { getAllPets } from '../api/data.js';
import { html } from '../lib.js';


const animalCard = (animal) => html`
        <div class="animals-board">
            <article class="service-img">
                <img class="animal-image-cover" src="${animal.image}">
            </article>
            <h2 class="name">${animal.name}</h2>
            <h3 class="breed">${animal.breed}</h3>
            <div class="action">
                <a class="btn" href="/details/${animal._id}">Details</a>
        </div>`;

const dashboardTemplate = (data) => html`
        <section id="dashboard">
            <h2 class="dashboard-title">Services for every animal</h2>
            <div class="animals-dashboard">
                ${data.length !== 0
                    ? data.map(animalCard)
                    : html`
                    <div>
                        <p class="no-pets">No pets in dashboard</p>
                    </div>`}
            </div>
        </section>`;

export async function dashboardView(ctx){
    const data = await getAllPets();
    ctx.render(dashboardTemplate(data))
}

    
