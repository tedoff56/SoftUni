window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');

  let previewList = document.getElementById('preview-list');

  let publishBtn = document.getElementById('form-btn');
  publishBtn.addEventListener('click', publish);

  function deleteStory(){
    document.getElementsByClassName('story-info')[0].remove();
    publishBtn.disabled = false;
  }

  function saveStory(){
    document.getElementById('main').innerHTML = '<h1>Your scary story is saved!</h1>';
  }

  function editStory(){

    let article = previewList.querySelector('article');
    let data = Array.from(article.children).map(n => n.outerText);

    story.value = data.pop();
    data = data.map(d => d.split(': ')[1]);

    [firstName.value, lastName.value] = data[0].split(' ');
    age.value = data[1];
    storyTitle.value = data[2];
    genre.value = data[3];

    article.parentElement.remove();

    publishBtn.disabled = false;
  }

  function createPreview(){
    let li = document.createElement('li');
    li.classList.add('story-info');

    let article = document.createElement('article');

    article.innerHTML += `<h4>Name: ${firstName.value} ${lastName.value}</h4>`;
    article.innerHTML += `<p>Age: ${age.value}</p>`;
    article.innerHTML += `<p>Title: ${storyTitle.value}</p>`;
    article.innerHTML += `<p>Genre: ${genre.value}</p>`;
    let pStory = document.createElement('p');
    pStory.style.wordBreak = 'break-all';
    pStory.textContent = story.value;
    article.appendChild(pStory);
    // article.innerHTML += `<p>"${story.value}"</p>`;

    li.appendChild(article);

    let saveBtn = document.createElement('button');
    saveBtn.classList.add('save-btn');
    saveBtn.textContent = 'Save Story';
    saveBtn.addEventListener('click', saveStory);
    li.appendChild(saveBtn);

    let editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit Story';
    editBtn.addEventListener('click', editStory);
    li.appendChild(editBtn);

    let deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Delete Story';
    deleteBtn.addEventListener('click', deleteStory);
    li.appendChild(deleteBtn);

    previewList.appendChild(li);
  }

  function publish(){

    if(!firstName.value || !lastName.value || !age.value || !storyTitle.value || !genre.value || !story.value){
      return;
    }

    createPreview();

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    genre.value = '';
    story.value = '';
    
    publishBtn.disabled = true;
  }

}
