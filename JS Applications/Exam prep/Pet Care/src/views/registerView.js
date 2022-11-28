import { register } from "../api/user.js";
import { html } from "../lib.js";
import { createSubmitHandler } from '../util.js';


const registerTemplate = (onSubmit) => html`
        <section id="registerPage">
            <form @submit=${onSubmit} class="registerForm">
                <img src="./images/logo.png" alt="logo" />
                <h2>Register</h2>
                <div class="on-dark">
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>

                <div class="on-dark">
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <div class="on-dark">
                    <label for="repeatPassword">Repeat Password:</label>
                    <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit">Register</button>

                <p class="field">
                    <span>If you have profile click <a href="#">here</a></span>
                </p>
            </form>
        </section>`;

export function registerView(ctx){
    ctx.render(registerTemplate(createSubmitHandler(onRegister)));

    async function onRegister(data){
        if(!data.email || !data.password || !data.repeatPassword){
            return alert('All fields are required');
        }

        if(data.password !== data.repeatPassword){
            return alert('Passwords don\'t match')
        }

        await register(data.email, data.password)
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}