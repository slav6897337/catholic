import React from 'react';
import {Link} from 'react-router-dom';
import moment from 'moment/moment';
import './SpecificNews.css';

interface ISpecificNews {
  title: string,
  date: Date,
  description: string,
  link: string,
}

const SpecificNews = (props: ISpecificNews) => {
  if(!props.title || !props.date || !props.description || !props.link) return null;
  
  return (
    <Link to={props.link} className="news">
      <div className="news__title">
        <h1>News Title</h1>
        <p>{moment(new Date()).format('DD.MM.yyyy')}</p>
      </div>
      <p>{props.description}</p>
    </Link>
  );
};

export default SpecificNews;