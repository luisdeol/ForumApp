import { CREATE_COMMENT } from '../actions/index';

export default function(state=[], action) {
    switch(action.type){
        case CREATE_COMMENT:
            return [...state, action.payload.data];
        default:
            return state;
    }
}

