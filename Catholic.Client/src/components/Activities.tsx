import React from 'react';
import Activity from './Activity';
import './Activities.css';

const Activities = () => {
  return (
      <div className="activities" >
        <h1>Activities</h1>
      <div className="activities-container">
        <Activity
          title="Holy Mass"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/holy-mass.png"
          link="/holy-mass"
          isImageTop={true}
        />

        <Activity
          title="Bible Group"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/bible-rosary.png"
          link="/bible-group"
          isImageTop={false}
        />

        <Activity
          title="Choir"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/bratislava.png"
          link="/choir"
          isImageTop={true}
        />

        <Activity
          title="Legion of Mary"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/bible.png"
          link="/holy-mass"
          isImageTop={true}
        />

        <Activity
          title="Catholic Table"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/reading.png"
          link="/holy-mass"
          isImageTop={false}
        />

        <Activity
          title="Holy Mass"
          description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
          image="/img/holy-mass.png"
          link="/holy-mass"
          isImageTop={true}
        />
      </div>
    </div>
    
  );
}

export default Activities  