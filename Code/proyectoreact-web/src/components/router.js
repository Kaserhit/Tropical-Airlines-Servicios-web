import React from 'react';

import { BrowserRouter, Route, Switch } from 'react-router-dom';

import App from './../App';
import Menu from './../Menu';
import Usuarios from './Usuarios';
import NotFound from './notFound';

import VuelosLLegada from './VuelosLlegada';

import Reservaciones from './Reservaciones';

import VuelosSalida from './VuelosSalida';

import UsuariosPasswords from './UsuariosPassword';

const Router = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={App}></Route>
      <Route exact path="/Usuarios" component={Usuarios}></Route>
      <Route exact path="/Menu" component={Menu}></Route>
      <Route exact path="/VuelosLLegada" component={VuelosLLegada}></Route>
      <Route exact path="/VuelosSalida" component={VuelosSalida}></Route>
      <Route exact path="/Reservaciones" component={Reservaciones}></Route>
      <Route
        exact
        path="/UsuariosPasswords"
        component={UsuariosPasswords}
      ></Route>

      <Route component={NotFound}></Route>
    </Switch>
  </BrowserRouter>
);

export default Router;
