import React, {Component, useState} from 'react';
import {Collapse, Nav, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from 'reactstrap';
import {Link} from 'react-router-dom';
import './NavMenu.css';

const NavMenu = (props: any) => {
  const [state, setState] = useState({collapsed: false});

  function toggleNavbar() {
    setState({
      collapsed: !state.collapsed
    });
  }

  return (
    <header>
      <nav className="header-container">
        <NavbarBrand className="text" tag={Link} to="/">Catholic.sk</NavbarBrand>

        <div className="menu-container">
          <NavItem>
            <NavLink tag={Link} className="link" to="/">Home</NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="link" to="/holy-mass">Holy Mass</NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="link" to="/bible-group">Bible Group</NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="link" to="/choir">Choir</NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="link" to="/legion-of-mery">Legion of Mary</NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="link" to="/news">News</NavLink>
          </NavItem>
        </div>
        <NavbarToggler className="menu-button" onClick={toggleNavbar}/>

      </nav>
    </header>
  );
}

export default NavMenu;


{/*<Collapse className="menu" isOpen={!state.collapsed} navbar>*/
}
{/*  <ul className="menu-container">*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/">Home</NavLink>*/
}
{/*    </NavItem>*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/holly-mass">Holly Mass</NavLink>*/
}
{/*    </NavItem>*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/bible-group">Bible Group</NavLink>*/
}
{/*    </NavItem>*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/choir">Choir</NavLink>*/
}
{/*    </NavItem>*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/legion-of-mery">Legion of Mary</NavLink>*/
}
{/*    </NavItem>*/
}
{/*    <NavItem>*/
}
{/*      <NavLink tag={Link} className="link" to="/news">News</NavLink>*/
}
{/*    </NavItem>*/
}
{/*  </ul>*/
}
{/*</Collapse>*/
}