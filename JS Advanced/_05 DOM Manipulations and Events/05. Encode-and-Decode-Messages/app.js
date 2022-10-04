function encodeAndDecodeMessages() {

    let [encodeButton, decodeButton] = document.getElementsByTagName('button');
    let [message, receivedMessage] = document.getElementsByTagName('textarea');

    encodeButton.addEventListener('click', function() {
        let encodedMessage = '';
    
        for (let char of message.value) {
            encodedMessage += String.fromCharCode(char.charCodeAt(0) + 1)
        }

        message.value = '';
        receivedMessage.value = encodedMessage;
    });

    decodeButton.addEventListener('click', function(){
        let decodedMessage = '';

        for(let char of receivedMessage.value){
            decodedMessage += String.fromCharCode(char.charCodeAt(0) - 1);
        }

        receivedMessage.value = decodedMessage;
    });
}