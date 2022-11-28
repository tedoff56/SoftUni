import { html, nothing } from '../lib.js';
import { getPetById } from '../api/data.js';

const detailsTemplate = (pet, hasUser, isCreator) => html`
        <section id="detailsPage">
            <div class="details">
                <div class="animalPic">
                    <img src="${pet.image}">
                </div>
                <div>
                    <div class="animalInfo">
                        <h1>Name: ${pet.name}</h1>
                        <h3>Breed: ${pet.breed}</h3>
                        <h4>Age: ${pet.age}</h4>
                        <h4>Weight: ${pet.weight}</h4>
                        <h4 class="donation">Donation: 0$</h4>
                    </div>
                    ${hasUser
                        ? html`
                        <div class="actionBtn">
                            ${isCreator
                                ? html`
                                    <a href="#" class="edit">Edit</a>
                                    <a href="#" class="remove">Delete</a>`
                                : html`
                                    <a href="#" class="donate">Donate</a>`}
                        </div>`
                        : nothing}
                    
                </div>
            </div>
        </section>`;

export async function detailsView(ctx){
    
    const data = await getPetById(ctx.params.id);
    const user = ctx.user;
    const isCreator = Boolean(user) && (data._ownerId === user._id);

    ctx.render(detailsTemplate(data, Boolean(user), isCreator))
}