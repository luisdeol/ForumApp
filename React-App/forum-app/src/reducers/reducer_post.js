import { FETCH_POST, CREATE_COMMENT, CLEAN_POST_STATE } from './../actions/index';

export default function(state={}, action){
    switch(action.type){
        case FETCH_POST:
            return action.payload.data;
        case CREATE_COMMENT:
            return Object.assign({}, state, {
                comments: [...state.comments, action.payload.data]
            });
        case CLEAN_POST_STATE:
            return {};
        default :
            return state;
    }
}