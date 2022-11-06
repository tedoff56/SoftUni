function attachEvents() {
    const [btnSend, btnRefresh] = document.querySelectorAll('input[type=button]');
    const [author, content] = document.querySelectorAll('input[type=text]');
    const textarea = document.getElementById('messages');

    btnSend.addEventListener('click', send);
    btnRefresh.addEventListener('click', refresh);

    const url = 'http://localhost:3030/jsonstore/messenger';

    async function refresh(){
        const response = await fetch(url);
        const messages = Object.values(await response.json());
        let result = '';

        messages.forEach(m => result += `${m.author}: ${m.content}\n`)
        textarea.value = result.trimEnd();

    }

    async function send(){
        const message = {
            author: author.value,
            content: content.value
        };

        await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(message)
        });
    }
}

attachEvents();