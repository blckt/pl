
import React from 'react';
import Provider from 'react-redux/lib/components/provider';
import Router from 'react-router/lib/Router';

import { browserHistory } from 'react-router';
import store from './utils/createStore.js';
import { syncHistoryWithStore } from 'react-router-redux';

import route from './routes'


const history = syncHistoryWithStore(browserHistory, store);

export default class App extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <Router history={history} routes={route} />
      </Provider>
    )
  }
}
