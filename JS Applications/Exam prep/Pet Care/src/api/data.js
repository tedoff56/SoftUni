import { del, get, post, put } from "./api.js";

const endpoints = {
    'getAll': '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    'getById': '/data/pets/'
};

export async function getAllPets(){
    return get(endpoints.getAll);
}

export async function getPetById(id){
    return get(endpoints.getById + id);
}