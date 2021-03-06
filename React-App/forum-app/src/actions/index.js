import axios from 'axios';

export const FETCH_POSTS = 'fetch_posts';
export const FETCH_POST = 'fetch_post';
export const CREATE_POST = 'create_posts';
export const CREATE_COMMENT = 'create_comment';
export const CLEAN_POST_STATE = 'clean_post_state';
export const SEARCH_POSTS = 'search_posts';

const ROOT_URL_POSTS = 'http://localhost:62324/api/posts';
const ROOT_URL_COMMENTS = 'http://localhost:62324/api/comments';

export function fetchPosts() {
    const request = axios.get(ROOT_URL_POSTS);

    return {
        type: FETCH_POSTS,
        payload: request
    }
}

export function createPost(values, callback) {
    const request = axios
                        .post(ROOT_URL_POSTS, values)
                        .then(() => callback());
    
    return {
        type: CREATE_POST,
        payload: request
    }
}   

export function fetchPost(id) {
    const request = axios.get(`${ROOT_URL_POSTS}/${id}`);
    
    return {
        type: FETCH_POST,
        payload: request
    }
}

export function createComment(values) {
    const request = axios
                        .post(ROOT_URL_COMMENTS, values);

    return {
        type: CREATE_COMMENT,
        payload: request
    }
}

export function cleanPostState() {
    return {
        type: CLEAN_POST_STATE,
        payload: {}
    }
}

export function searchByTitle(title, callback) {
    const request = axios.get(`${ROOT_URL_POSTS}?title=${title}`);

    return {
        type: SEARCH_POSTS,
        payload: request
    }
}