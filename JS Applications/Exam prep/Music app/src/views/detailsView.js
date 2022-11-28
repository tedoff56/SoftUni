import { html, nothing } from "../lib.js";
import { deleteAlbum, getAlbumById } from "../api/data.js";


const detailsTemplate = (album, isCreator, onDelete) => html`
        <section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src="${album.imgUrl}">
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: $${album.price}</h4>
                        <h4>Date: ${album.releaseDate}</h4>
                        <p>Description: ${album.description}</p>
                    </div>
                    ${isCreator 
                        ? html`
                        <div class="actionBtn">
                            <a href="/edit/${album._id}" class="edit">Edit</a>
                            <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                        </div>`
                        : nothing}
                </div>
            </div>
        </section>`;

export async function detailsView(ctx){
    const album = await getAlbumById(ctx.params.id);
    const isCreator = Boolean(ctx.user) && (album._ownerId == ctx.user._id);

    ctx.render(detailsTemplate(album, isCreator, onDelete));

    async function onDelete(){
        const choice = confirm("Delete this album?");

        if(choice){
            await deleteAlbum(album._id);
            ctx.page.redirect('/catalog');
        }
        
    }
}

