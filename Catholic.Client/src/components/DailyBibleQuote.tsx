import React, {useEffect} from 'react';
import {IBibleQuote} from '../Domain/IBibleQuote';
import Api from '../Utiles/Api';
import moment from 'moment';
import './DailyBibleQuote.css';

const defaultQuote: IBibleQuote = {
    bookname: 'John',
    chapter: '3',
    verse: '16',
    text: 'For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.'
}

const DailyBibleQuote = () => {
  const [quote, setQuote] = React.useState<IBibleQuote>(defaultQuote);

  useEffect(() => {
    Api.getDailyBibleQuote().then((quote: IBibleQuote) => {
        if(quote){
            setQuote(quote);
        }
    });
  }, []);

  return (
    <div className="quote" style={{backgroundImage: 'url(/bible-quote.png)'}}>
      <div className="background-container">
        {quote ?
          <div className="quote-container">
            
            <div className="horizontal-container">
              <div className="date-container">
                <div className="date">{moment(new Date()).format('MMMM D,yyyy')}</div>
              </div>

              <div className="vertical-line"/>
              
              <div className="vertical-container">
                <div className="quote-title">DAILY REFRESH</div>
                <div className="quote-text">“{quote?.text.trim()}”</div>
                <div className="reference">{quote?.bookname} {quote?.chapter}-{quote?.verse}</div>
              </div>
              
            </div>
          </div> : null}
      </div>
    </div>

  );
}

export default DailyBibleQuote;