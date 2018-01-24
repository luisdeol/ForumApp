import { combineReducers } from 'redux';
import PostReducer from './reducer_posts';
import CommentsReducer from './reducer_comments';
import { reducer as formReducer } from 'redux-form';

const rootReducer =  combineReducers({
    posts: PostReducer,
    form: formReducer,
    comments: CommentsReducer
});

export default rootReducer;