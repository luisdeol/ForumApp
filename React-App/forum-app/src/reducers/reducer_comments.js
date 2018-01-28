import { FETCH_COMMENTS, CREATE_COMMENT, CLEAN_COMMENTS_STATE } from '../actions/index';

export default function(state=[], action) {
    switch(action.type){
        case FETCH_COMMENTS:
            return action.payload.data;
        case CREATE_COMMENT:
            return [...state, action.payload.data];
        case CLEAN_COMMENTS_STATE:
            return [];
        default:
            return state;
    }
}

