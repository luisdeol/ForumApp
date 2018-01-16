import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import promise from 'redux-promise';

import './index.css';
import registerServiceWorker from './registerServiceWorker';
import Forum from './components/forum/forum';

import reducers from './reducers';

const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

ReactDOM.render(
    <Provider store={createStoreWithMiddleware(reducers)}>
        <Forum />
    </Provider>
    ,document.getElementById('root'));
registerServiceWorker();
