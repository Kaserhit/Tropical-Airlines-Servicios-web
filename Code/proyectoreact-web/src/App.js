import React, { Component } from 'react';
import axios from 'axios';
import Header from './components/header';
import Usuarios from './components/Usuarios';
import Footer from './components/Footer';
import Cookies from 'universal-cookie';
import Loginsocial from './LoginSocial';

import './styles/Site.css';

const url = 'http://localhost:62299/api/Seguridad';
const cookies = new Cookies();

class App extends Component {
  state = {
    form: {
      Usuario: '',
      Contrasena: ''
    }
  }

  handleChange = async (e) => {
    await this.setState({
      form: {
        ...this.state.form,
        [e.target.name]: e.target.value,
      },
    });
  }

  iniciarSesion = async () => {
    await axios.get(url, {params: {Usuario: this.state.form.Usuario, Contrasena: this.state.form.Contrasena}})
      .then(response => {
        return response.data;
      })
      .then(response => {
        var respuesta;
        var err = 0;
        for (var i = 0; i < response.length; i++) {
          if (response[i].Usuario === this.state.form.Usuario && response[i].Contrasena === this.state.form.Contrasena) {
            respuesta = response[i];
            err++;
          }
        }

        if (err === 1){
          cookies.set('USRID', respuesta.USRID, {path: '/'});
          cookies.set('Primer_Apellido', respuesta.Primer_Apellido, {path: '/'});
          cookies.set('Segundo_Apellido', respuesta.Segundo_Apellido, {path: '/'});
          cookies.set('Nombre', respuesta.Nombre, {path:'/'});
          cookies.set('Usuario', respuesta.Usuario, {path: '/'});
          alert(`Bienvenido ${respuesta.Nombre} ${respuesta.Primer_Apellido}`);
          window.location.href = './Menu';
        }
        else{
          alert('El usuario o la contraseña no son correctos');
        }
      })
      .catch(error => {
        console.log(error);
      })
  }

  componentDidMount() {
    if(cookies.get('Usuario')){
        window.location.href="./Menu";
    }
  }

  render() {
    return (
      <div className="App">
        <Header />

        <center>
          <h2>Iniciar Sesion</h2>

          <div className="form-horizontal">
            <hr />

            <div className="form-group">
              <div className="col-center-10">
                <b>Usuario</b>
                <input
                  className="form-control"
                  type="text"
                  id="Usuario"
                  name="Usuario"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>

            <br />

            <div className="form-group">
              <div className="col-center-10">
                <b>Contraseña</b>
                <br></br>
                <input
                  className="form-control"
                  type="password"
                  id="Contrasena"
                  name="Contrasena"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>

            <br />

            <div className="form-group">
              <div className="col-center-offset-2 col-center-10">
                <button
                  className="btn btn-default border-dark"
                  onClick={() => this.iniciarSesion()}
                >
                  Iniciar Sesión
                </button>
              </div>
            </div>
          </div>
        </center>

        <br />

        <center>
          <Usuarios />

          <br />
          <Loginsocial />
          <br />
          <Footer />
        </center>
      </div>
    );
  }
}

export default App;
