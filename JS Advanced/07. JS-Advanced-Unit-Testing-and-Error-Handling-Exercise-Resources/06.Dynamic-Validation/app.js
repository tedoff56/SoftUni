function validate() {
    let email = document.getElementById('email');
    let validRegex = /^[a-z]+\@[a-z]+\.[a-z]+$/;

    email.addEventListener('change', () =>{
        if(validRegex.test(email.value)){
            email.classList.remove('error');
            email.value = email.value.split('@')[0];
        }
        else{
            email.classList.toggle('error')
        }
    })
}