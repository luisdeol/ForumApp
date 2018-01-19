import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import promise from 'redux-promise';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import './index.css';
import registerServiceWorker from './registerServiceWorker';
import Forum from './components/forum/forum';
import PostNew from './components/new_post/post_new';
import reducers from './reducers';

const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

ReactDOM.render(
    <Provider store={createStoreWithMiddleware(reducers)}>
        <BrowserRouter>
            <div>
                <Switch>
                    <Route path="/posts/new" component={PostNew} />
                    <Route path="/" component={Forum} />
                </Switch>
            </div>
        </ BrowserRouter>
    </Provider>
    ,document.getElementById('root'));
registerServiceWorker();
