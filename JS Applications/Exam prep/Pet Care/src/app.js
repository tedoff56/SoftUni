import { page, render} from './lib.js';
import { getUserData } from './util.js';
import { dashboardView } from './views/dashboardView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { updateNav } from './views/nav.js';
import { registerView } from './views/registerView.js';
import { detailsView } from './views/detailsView.js';
import { createView } from './views/createView.js';
import { editView } from './views/editView.js';

const main = document.getElementById('content');

page(decorateContext);
page('/', homeView);
page('/home', homeView);
page('/dashboard', dashboardView);
page('/details/:id', detailsView)
page('/edit/:id', editView);
page('/create', createView);
page('/login', loginView);
page('/register', registerView);

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