import React, {useEffect} from 'react';
import {IBibleQuote} from '../Domain/IBibleQuote';
import Api from '../Utiles/Api';
import moment from 'moment';
import './DailyBibleQuote.css';

const DailyBibleQuote = () => {
  const [quote, setQuote] = React.useState<IBibleQuote>();

  useEffect(() => {
    Api.getDailyBibleQuote().then((quote: IBibleQuote) => {
      setQuote(quote);
    });
  }, []);
  console.log(JSON.stringify(quote));
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