import { html, render, page} from "../lib.js";
import { getUserData } from "../util.js";
import { logout } from "../api/user.js";

const header = document.querySelector('header');

const navTemplate = (hasUser) => html`
        <nav>
            <section class="logo">
                <img src="images/logo.png" alt="logo">
            </section>
            <ul>
                <li><a href="/">Home</a></li>
                <li><a href="/dashboard">Dashboard</a></li>
                ${hasUser
                    ? html`
                <li><a href="/create">Create Postcard</a></li>
                <li><a @click=${onLogout} href="javascript:void(0)">Logout</a></li>`
                    : html`
                <li><a href="/login">Login</a></li>
                <li><a href="/register">Register</a></li>`}       
            </ul>
        </nav>`;

export function updateNav(){
    const user = getUserData();

    render(navTemplate(Boolean(user)), header);
}

function onLogout(){
    logout();
    updateNav();
    page.redirect('/home')
}