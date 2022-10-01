function search() {
   let towns = Array.from(document.querySelectorAll('#towns li'));
   let searchText = document.getElementById('searchText').value;

   let cnt = 0;
   for (let town of towns) {
      let townName = town.textContent;

      if(townName.toLowerCase().includes(searchText.toLowerCase())){
         cnt++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline'
      }
      else{
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   }

   document.getElementById('result').textContent = `${cnt} matches found`;

   cnt = 0;
}
