import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Forces } from './components/Forces';
import { StreetCrimes } from './components/StreetCrimes';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/forces' component={Forces} />
        <Route path='/streetcrimes' component={StreetCrimes} />
      </Layout>
    );
  }
}
