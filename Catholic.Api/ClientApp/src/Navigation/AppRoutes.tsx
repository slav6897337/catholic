import React, {ReactNode} from "react";
import BibleQuotes from '../components/DailyBibleQuote';
import HomePage from '../Pages/HomePage';


interface IAppRoutes {
  element: ReactNode,
  index?: boolean,
  path?: string
}

const AppRoutes:IAppRoutes[] = [
  {
    index: true,
    element: <HomePage />
  },
  {
    path: '/bible-quotes',
    element: <BibleQuotes />
  },
];

export default AppRoutes;
