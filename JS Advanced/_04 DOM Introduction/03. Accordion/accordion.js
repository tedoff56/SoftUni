function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let textDiv = document.getElementById('extra');

    if(button.textContent === 'Less'){
        textDiv.style.display = 'none'
        button.textContent = 'More';
        return;
    }

    textDiv.style.display = 'block';
    button.textContent = 'Less';
}