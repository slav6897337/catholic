import Http from './Http';
import {IBibleQuote} from '../Domain/IBibleQuote';

const Api = {
   getDailyBibleQuote: async () => await Http.get<IBibleQuote>('/api/daily-bible-quote'),
};

export default Api;