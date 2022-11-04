async function solution() {

    let main = document.getElementById('main');
    let titlesResponse = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
    let titles = await titlesResponse.json();   ;

    for (const titleData of Object.values(titles)) {  

        let div = document.createElement('div');
        div.classList.add('accordion');
        div.innerHTML = `
        <div class="head">
            <span>${titleData.title}</span>
            <button class="button" id="${titleData._id}">More</button>
        </div>
        <div class="extra">
            <p>Scalable Vector Graphics .....</p>
        </div>`;

        main.appendChild(div); 
    }

    for (const titleData of Object.values(titles)) {
        let btn = document.getElementById(titleData._id);
        let divExtra = btn.parentElement.parentElement.getElementsByClassName('extra')[0];

        let contentResponse = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${titleData._id}`);
        let content = (await contentResponse.json()).content;
        divExtra.querySelector('p').textContent = content;
        
        btn.addEventListener('click', () => {
            if(btn.textContent === 'More'){
                btn.textContent = 'Less';
                divExtra.style.display = 'block';
            }else {
                btn.textContent = 'More';
                divExtra.style.display = 'none';
            }
            
        });
    }
}
window.onload = solution();