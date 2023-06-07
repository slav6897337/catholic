import React from 'react';
import './Welcome.css';

const Welcome = () => {

  return (
    <div className="welcome-container">
      <div className="welcome-text">
        <h1>Welcome</h1>
        <div className="welcome__horizontal-line"/>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore
          magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
          consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
          pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id
          est laborum. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
          labore et dolore magna aliqua. </p>
      </div>
      <div className="welcome-image">
        <img className="welcome-picture" src="/welcome-image.png" alt="welcome-image" />
        <div className="overlay-top"/>
        <div className="overlay-right"/>
      </div>
    </div>
  );
}

export default Welcome;