import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link, Redirect } from 'react-router-dom';
import VuelosLlegada from './VuelosLlegada';
import VuelosSalida from './VuelosSalida';

function App () {
  return (
    <Router>
      <div className="App">
      <Switch>
        <Route exact path="/">
            <header className="App-header">
              <img src={logo} className="App-logo" alt="logo" />
              <Link to="/VuelosLlegada" className="App-link">
                Vuelos de Llegada
              </Link>
              <br />
              <Link to="/VuelosSalida" className="App-link">
                Vuelos de Salida
              </Link>
            </header>
        </Route>
        <Route exact path="/VuelosLlegada" component={VuelosLlegada}/>
        <Route exact path="/VuelosSalida" component={VuelosSalida}/>
        <Redirect path="/**" to="/" />
      </Switch>
    </div>
    </Router>
  );
}

export default App;
