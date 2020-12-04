import React, { Component } from 'react';
import ReCAPTCHA from 'react-google-recaptcha';
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
      Contrasena: '',
    },
  };

  handleChange = async (e) => {
    await this.setState({
      form: {
        ...this.state.form,
        [e.target.name]: e.target.value,
      },
    });
  };

  iniciarSesion = async () => {
    await axios
      .get(url, {
        params: {
          Usuario: this.state.form.Usuario,
          Contrasena: this.state.form.Contrasena,
        },
      })
      .then((response) => {
        return response.data;
      })
      .then((response) => {
        if (response.length > 0) {
          var respuesta = response[0];
          cookies.set('USRID', respuesta.USRID, { path: '/' });
          cookies.set('Primer_Apellido', respuesta.Primer_Apellido, {
            path: '/',
          });
          cookies.set('Segundo_Apellido', respuesta.Segundo_Apellido, {
            path: '/',
          });
          cookies.set('Nombre', respuesta.Nombre, { path: '/' });
          cookies.set('Usuario', respuesta.Usuario, { path: '/' });
          alert(`Bienvenido ${respuesta.Nombre} ${respuesta.Primer_Apellido}`);
          window.location.href = './Menu';
        } else {
          alert('El usuario o la contraseña no son correctos');
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  Recaptchacargado() {
    console.log('Recaptcha completado exitosamente');
  }

  render() {
    return (
      <div className="App">
        <Header />

        <center>
          <h2>Iniciar Sesion</h2>

          <div class="form-horizontal">
            <hr />

            <div class="form-group">
              <div class="col-center-10">
                <b>Usuario</b>
                <input
                  class="form-control"
                  type="text"
                  id="Usuario"
                  name="Usuario"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>

            <br />

            <div class="form-group">
              <div class="col-center-10">
                <b>Contraseña</b>
                <br></br>
                <input
                  class="form-control"
                  type="password"
                  id="Contrasena"
                  name="Contrasena"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>

            <br />

            <div class="form-group">
              <div class="col-center-offset-2 col-center-10">
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
          <ReCAPTCHA
            sitekey={'6LemVfgZAAAAAOEg26BtM3ttN833hk_8f6HO1tSb'}
            site
            onChange={this.Recaptchacargado}
          />
          <br />
          <Footer />
        </center>
      </div>
    );
  }
}

export default App;
