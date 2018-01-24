import axios from 'axios';

export const FETCH_POSTS = 'fetch_posts';
export const CREATE_POST = 'create_posts';
export const CREATE_COMMENT = 'create_comment';
export const FETCH_COMMENTS = 'fetch_comments';

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

export function createComment(values, callback) {
    // const request = axios
    //                     .post(ROOT_URL_COMMENTS, values)
    //                     .then(() => callback());

    const comment = { content: values.content, id: values.id };

    return {
        type: CREATE_COMMENT,
        payload: comment
    }
}

export function fetchComments(id) {
    const comments = [{ id: 1, content: 'the first comment'},{ id: 2, content: 'the second comment'},{ id: 3, content: 'the third comment'}];

    return {
        type: FETCH_COMMENTS,
        payload: comments
    }
}