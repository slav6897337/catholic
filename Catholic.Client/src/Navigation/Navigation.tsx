import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import AppRoutes from './AppRoutes';


const Navigation = () => {
  return (
    <Routes>
      {AppRoutes.map((route, index) => {
        const {element, ...rest} = route;
        return <Route key={index} {...rest} element={element}/>;
      })}
    </Routes>
  );
};

export default Navigation;
