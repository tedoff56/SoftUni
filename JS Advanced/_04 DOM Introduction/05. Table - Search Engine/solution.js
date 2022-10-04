function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = Array.from(document.querySelectorAll('tbody tr'));
      let search = document.getElementById('searchField').value;

      rows.forEach(d => {
         d.classList.remove('select');

         if(search !== '' && d.innerText.toLowerCase().includes(search.toLowerCase())){
            d.className = 'select';
         }
      });
      

   }
}