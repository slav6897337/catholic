import React from 'react';
import './AllNews.css';
import SpecificNews from './SpecificNews';

const AllNews = () => {
  return (
    <div className='all-news'>
      <h1 className="all-news__title">News</h1>
      <div className="all-news__container">
        <SpecificNews 
          title="Text Title" 
          date={new Date()} 
          description="English Bible Group is currently meeting every Thursday, 18:00, at Dom Quo Vadis, Bratislava. For more information click the icon on the menu bar near the top of this web page." 
          link="/"
        />
        <SpecificNews
          title="Text Title"
          date={new Date()}
          description="English Bible Group is currently meeting every Thursday, 18:00, at Dom Quo Vadis, Bratislava. For more information click the icon on the menu bar near the top of this web page."
          link="/"
        />
        <SpecificNews
          title="Text Title"
          date={new Date()}
          description="English Bible Group is currently meeting every Thursday, 18:00, at Dom Quo Vadis, Bratislava. For more information click the icon on the menu bar near the top of this web page."
          link="/"
        />
        <SpecificNews
          title="Text Title"
          date={new Date()}
          description="English Bible Group is currently meeting every Thursday, 18:00, at Dom Quo Vadis, Bratislava. For more information click the icon on the menu bar near the top of this web page."
          link="/"
        />
      </div>
    </div>
  );
};

export default AllNews;