import { del, get, post, put } from "./api.js";

const endpoints = {
    'getAll': '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    'albumById': '/data/albums/',
    'create': '/data/albums'
};

export async function getAllAlbums(){
    return get(endpoints.getAll);
}

export async function getAlbumById(id){
    return get(endpoints.albumById + id);
}

export async function deleteAlbum(id){
    return del(endpoints.albumById + id);
}

export async function editAlbum(id, data){
    return put(endpoints.albumById + id, data)
}

export async function createAlbum(data){
    return post(endpoints.create, data);
}
