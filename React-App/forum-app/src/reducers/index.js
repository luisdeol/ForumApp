import { combineReducers } from 'redux';
import PostsReducer from './reducer_posts';
import CommentsReducer from './reducer_comments';
import PostReducer from './reducer_post';
import { reducer as formReducer } from 'redux-form';

const rootReducer =  combineReducers({
    posts: PostsReducer,
    form: formReducer,
    comments: CommentsReducer,
    post: PostReducer
});

export default rootReducer;