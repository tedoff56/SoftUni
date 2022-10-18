window.addEventListener("load", solve);

function solve(){
    let typeProduct = document.getElementById('type-product');
    let description = document.getElementById('description');
    let clientName = document.getElementById('client-name');
    let clientPhone = document.getElementById('client-phone');

    let receivedOrders = document.getElementById('received-orders');
    let completedOrder = document.getElementById('completed-orders');


    document.querySelector('button[type="submit"]').addEventListener('click', sendForm);
    document.getElementsByClassName('clear-btn')[0].addEventListener('click', clearOrders)

    function clearOrders(e){
        let section = e.target.parentElement;
        Array.from(section.getElementsByClassName('container')).forEach(d => d.remove());
    }

    function finishRepair(e){
        let div = e.target.parentElement;
        Array.from(div.querySelectorAll('button')).forEach(b => b.remove());

        completedOrder.appendChild(div);
    }

    function startRepair(e){
        e.target.disabled = true;
        e.target.parentElement.getElementsByClassName('finish-btn')[0].disabled = false;
    }

    function sendForm(e){
        e.preventDefault();

        if(!description.value || !clientName.value || !clientPhone.value){
            return;
        }

        createOrder(typeProduct.value, description.value, clientName.value, clientPhone.value);

        description.value = '';
        clientName.value = '';
        clientPhone.value = '';
    }

    function createOrder(typeProductValue, descriptionValue, clientNameValue, clientPhoneValue){
        let div = document.createElement('div');
        div.classList.add('container');
        div.innerHTML += `<h2>Product type for repair: ${typeProductValue}</h2>`;
        div.innerHTML += `<h3>Client information: ${clientNameValue}, ${clientPhoneValue}</h3>`;
        div.innerHTML += `<h4>Description of the problem: ${descriptionValue}</h4>`;

        let startBtn = document.createElement('button');
        startBtn.classList.add('start-btn');
        startBtn.textContent = 'Start repair';
        startBtn.addEventListener('click', startRepair);

        let finishBtn = document.createElement('button');
        finishBtn.classList.add('finish-btn');
        finishBtn.disabled = true;
        finishBtn.textContent = 'Finish repair';
        finishBtn.addEventListener('click', finishRepair);

        div.appendChild(startBtn);
        div.appendChild(finishBtn);

        receivedOrders.appendChild(div);
    }
    
}