import { FETCH_POSTS, SEARCH_POSTS } from '../actions';

export default function(state={}, action){
    switch(action.type){
        case FETCH_POSTS:
            return !action.payload.data ? state : action.payload.data;
        case SEARCH_POSTS:
            console.log(action.payload);
            return  !action.payload.data ? state : action.payload.data;
        default:
            return state;
    }
}