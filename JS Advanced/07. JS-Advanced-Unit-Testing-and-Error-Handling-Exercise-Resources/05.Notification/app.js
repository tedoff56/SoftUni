function notify(message) {
  let notificationDiv = document.getElementById('notification');

  notificationDiv.addEventListener('click', ()=>{
    notificationDiv.style.display = 'none';
  });
  
  notificationDiv.textContent = message;
  notificationDiv.style.display = 'block';
}