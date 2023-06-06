import React, {Component} from 'react';
import {Container} from 'reactstrap';
import NavMenu from './NavMenu';
import Footer from './Footer';

const Layout = (props: any) => {
  return (
    <div>
      <NavMenu/>
      <Container tag="main">
        {props.children}
      </Container>
      <Footer/>
    </div>
  );
}

export default Layout;
