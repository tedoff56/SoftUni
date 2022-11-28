import { page, render} from './lib.js';
import { getUserData } from './util.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { updateNav } from './views/nav.js';
import { registerView } from './views/registerView.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { createView } from './views/createView.js';

const main = document.getElementById('main-content');

page(decorateContext);
page('/', homeView);
page('/home', homeView);
page('/catalog', catalogView);
page('/search', () => console.log('search'));
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);

updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();
    if(user){
        ctx.user = user;
    }

    next();
}

function renderMain(content){
    render(content, main);
}