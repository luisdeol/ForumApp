import axios from 'axios';

export const FETCH_POSTS = 'fetch_posts';
export const CREATE_POST = 'create_posts';

const ROOT_URL = 'http://localhost:62324/api/posts';

export function fetchPosts() {
    const request = axios.get(ROOT_URL);

    return {
        type: FETCH_POSTS,
        payload: request
    }
}

export function createPost(values, callback) {
    const request = axios
                        .post(ROOT_URL, values)
                        .then(() => callback());
    
    return {
        type: CREATE_POST,
        payload: request
    }
}   