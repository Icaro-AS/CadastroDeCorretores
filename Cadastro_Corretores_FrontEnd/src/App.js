import React, { Component, Fragment } from 'react';
import AppHeader from './components/AppHeader';
import Home from './components/Home';


class App extends Component {

  render() {
    return <Fragment>
      <AppHeader />
      <Home />
    </Fragment>;
  }
}

export default App;
