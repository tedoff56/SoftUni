function attachEvents() {
    let btnLoadPosts = document.getElementById('btnLoadPosts');
    let selectPosts = document.getElementById('posts');
    let btnViewPost = document.getElementById('btnViewPost');

    let postTitle = document.getElementById('post-title');
    let postBody = document.getElementById('post-body');
    let postComments = document.getElementById('post-comments');

    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPost);

    async function viewPost(){
        let selectedPostId = selectPosts.value;

        let commentsResponse = await fetch(`http://localhost:3030/jsonstore/blog/comments/`);
        let comments = Object.values(await commentsResponse.json());

        let postsResponse = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
        let post  = Object.values(await postsResponse.json()).find(p => p.id === selectedPostId);

        postTitle.textContent = post.title;
        postBody.textContent = post.body;

        postComments.innerHTML = '';

        comments
            .filter(c => c.postId === selectedPostId)
            .forEach(c => {
                let li = document.createElement('li');
                li.textContent = c.text;
                postComments.appendChild(li);
            })

    }

    async function loadPosts(){
        let postsResponse = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
        let posts = Object.values(await postsResponse.json());

        selectPosts.innerHTML = '';
        for (const post of posts) {
            let option = document.createElement('option');
            option.value = post.id;
            option.textContent = post.title;

            selectPosts.appendChild(option);
        }

    }
}

attachEvents();