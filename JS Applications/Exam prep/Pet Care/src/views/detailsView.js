import { html, nothing } from '../lib.js';
import { getPetById, deletePetById } from '../api/data.js';

const detailsTemplate = (pet, hasUser, isCreator, onDelete) => html`
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
                                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                                    <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`
                                : html`
                                    <a href="#" class="donate">Donate</a>`}
                        </div>`
                        : nothing}
                    
                </div>
            </div>
        </section>`;

export async function detailsView(ctx){
    
    const pet = await getPetById(ctx.params.id);
    const user = ctx.user;
    const isCreator = Boolean(user) && (pet._ownerId === user._id);


    ctx.render(detailsTemplate(pet, Boolean(user), isCreator, onDelete))

    async function onDelete(){
        const choice = confirm('Are you sure?');
        if(choice){
            await deletePetById(pet._id);
            ctx.page.redirect('/');
        }

    }
}