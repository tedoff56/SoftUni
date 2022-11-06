function attachEvents() {
    const [btnLoad, btnCreate] = document.querySelectorAll('button');
    const ulPhonebook = document.getElementById('phonebook');
    let [person, phone] = document.querySelectorAll('input[type=text]');

    btnLoad.addEventListener('click', loadPhonebook);
    btnCreate.addEventListener('click', createContact);

    const url = 'http://localhost:3030/jsonstore/phonebook/';

    async function createContact(){
        await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                person: person.value, 
                phone: phone.value
            })
        });

        person.value = '';
        phone.value = '';
        btnLoad.click();
    }

    async function loadPhonebook(){
        ulPhonebook.innerHTML = '';

        const response = await fetch(url);
        const phonebook = Object.values(await response.json());

        for (const entry of phonebook) {
            const li = document.createElement('li');
            li.textContent = `${entry.person}: ${entry.phone}`;

            const btnDelete = document.createElement('button');
            btnDelete.id = 'btnDelete';
            btnDelete.textContent = 'Delete';  
            btnDelete.addEventListener('click', () =>{        
                fetch(url + entry._id, {
                    method: 'DELETE'
                })
            });
            
            li.appendChild(btnDelete);
            ulPhonebook.appendChild(li);
        }

    }
}

attachEvents();