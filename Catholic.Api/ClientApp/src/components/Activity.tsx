import React from 'react';
import {Link} from 'react-router-dom';
import './Activity.css';
interface IActivity {
  title: string;
  description: string;
  image: string;
  link: string;
  isImageTop: boolean;
}


const Activity = (props: IActivity) => {
  if (!props.title || !props.description || !props.image || !props.link) return null;

  return (
    <div className="activity">
      {props.isImageTop ? <img src={props.image} alt={props.title}/> : null}
      <h1>{props.title}</h1>
      <p>{props.description}</p>
      <Link className="activity__link" to={props.link}>{`Read More -->`}</Link>
      {!props.isImageTop ? <img src={props.image} alt={props.title}/> : null}
    </div>
  );
}

export default Activity;