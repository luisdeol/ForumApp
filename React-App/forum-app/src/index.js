import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import promise from 'redux-promise';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import './index.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'; 
import registerServiceWorker from './registerServiceWorker';
import Forum from './components/forum/forum';
import PostNew from './components/post_new/post_new';
import reducers from './reducers';
import Post from './components/post/post';
import NavBar from './components/navbar/navbar';

const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

    ReactDOM.render(<Provider store={createStoreWithMiddleware(reducers)}>
    <BrowserRouter>
        <div>
            <NavBar />        
            <Switch>
                <Route path="/posts/new" component={PostNew} />
                <Route path="/posts/:id" component={Post} />
                <Route path="/" component={Forum} />
            </Switch>
        </div>
    </ BrowserRouter>
</Provider>, document.getElementById("root"));

registerServiceWorker();
