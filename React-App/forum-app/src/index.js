import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import registerServiceWorker from './registerServiceWorker';
import Forum from './components/forum/forum';

ReactDOM.render(<Forum />, document.getElementById('root'));
registerServiceWorker();
