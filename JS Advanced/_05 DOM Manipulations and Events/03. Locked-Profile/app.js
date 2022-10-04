function lockedProfile() {

    let profiles = Array.from(document.querySelectorAll('.profile'));
    
    for(let profile of profiles){
        profile.getElementsByTagName('button')[0].addEventListener('click', showMore);


    }

    function showMore(e){
        let isLocked = e.target.parentElement.querySelectorAll('input[type=radio]')[0].checked === true;

        if(isLocked){
            return;
        }

        let hiddenFields = e.target.parentElement.getElementsByTagName('div')[0];

        if(e.target.textContent == 'Hide it'){
            hiddenFields.style.display = 'none';
            e.target.textContent = 'Show more'
        }
        else{
            hiddenFields.style.display = 'block';
            e.target.textContent = 'Hide it';
        }

    }
}