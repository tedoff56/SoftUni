import { getAllAlbums } from "../api/data.js";
import { html, nothing } from "../lib.js";

const catalogCard = (album, hasUser) => html`
    <div class="card-box">
                <img src="${album.imgUrl}">
                <div>
                    <div class="text-center">
                        <p class="name">Name: ${album.name}</p>
                        <p class="artist">Artist: ${album.artist}</p>
                        <p class="genre">Genre: ${album.genre}</p>
                        <p class="price">Price: $${album.price}</p>
                        <p class="date">Release Date: ${album.releaseDate}</p>
                    </div>
                    ${hasUser 
                        ? html`<div class="btn-group">
                        <a href="/details/${album._id}" id="details">Details</a>
                        </div>`
                        : nothing}
                </div>
            </div>`;

const catalogTemplate = (albums, hasUser) => html`
        <section id="catalogPage">
            <h1>All Albums</h1>

            ${albums.length !== 0 
                ? albums.map(a => catalogCard(a, hasUser))
                : html`<p>No Albums in Catalog!</p>`}

        </section>`;



export async function catalogView(ctx){
    const albums = await getAllAlbums();
    const hasUser = Boolean(ctx.user);

    ctx.render(catalogTemplate(albums, hasUser));
}