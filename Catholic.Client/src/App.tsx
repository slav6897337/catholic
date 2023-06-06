import React, { Component } from 'react';
import  Layout  from './components/Layout';
import './custom.css';
import './fonts.css';
import Navigation from './Navigation/Navigation';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Navigation />
      </Layout>
    );
  }
}
