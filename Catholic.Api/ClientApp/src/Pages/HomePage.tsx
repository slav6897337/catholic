import React, {Component} from 'react';
import DailyBibleQuote from '../components/DailyBibleQuote';
import './HomePage.css';
import Welcome from '../components/Welcome';
import Activities from '../components/Activities';
import AllNews from '../components/AllNews';

export default class HomePage extends Component {
    static displayName = HomePage.name;
    
    render() {
        return (
        <div className="home">
            <DailyBibleQuote />
            <div className="home__background-image" style={{ backgroundImage: 'url(/home-background.png)' }}>
                <div className="home__background">
                    <Welcome />
                    <Activities />
                    <AllNews />
                </div>
                
            </div>
        </div>
        );
    }
}