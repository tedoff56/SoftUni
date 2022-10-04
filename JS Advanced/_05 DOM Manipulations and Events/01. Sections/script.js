function create(words) {
   
   let content = document.getElementById('content');

   for (let word of words) {
      let div = document.createElement('DIV');
      let p = document.createElement('P');
      p.textContent = word;
      p.style.display = 'none';

      div.appendChild(p);
      content.appendChild(div);

      div.addEventListener('click', function(){
         p.style.display = 'block';
      })
   }
}