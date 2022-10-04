function attachEventsListeners() {

    let buttons = Array.from(document.querySelectorAll('input[type=button]'))
        .map(b => b.addEventListener('click', convert));


    function convert(e){
        let inputValue = e.target.parentElement.querySelector('input[type=text]').value;

        switch(e.target.id){
            case 'daysBtn':
                populate(inputValue);
            break;
            case 'hoursBtn':
                populate(inputValue / 24);
            break;
            case 'minutesBtn':
                populate(inputValue / 24 / 60);
            break;
            case 'secondsBtn':
                populate(inputValue / 24 / 60 / 60);
            break;
        }
        console.log(input);
    }

    function populate(value){

        let inputs = Array.from(document.querySelectorAll('input[type=text]'));
        inputs.shift().value = value;

        let currentValue = value * 24;

        for(let input of inputs){
            input.value = currentValue;
            currentValue *= 60;
        }

    }
}
