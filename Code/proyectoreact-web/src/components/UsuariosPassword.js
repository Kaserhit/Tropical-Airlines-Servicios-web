/* eslint-disable jsx-a11y/alt-text */
import React, { Component } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from '../components/header2';
import Footer from '../components/Footer';
import { Link } from 'react-router-dom';

import icn1 from '../assets/icons/181501-interface/181501-interface/svg/padlock.svg';
import icn2 from '../assets/icons/181501-interface/181501-interface/svg/shield-1.svg';
import icn3 from '../assets/icons/181501-interface/181501-interface/svg/settings.svg';

const url = 'http://localhost:62299/api/Seguridad/';

class Usuariospassword extends Component {
  state = {
    data: [],
    modalInsertar: false,
    form: {
      USRID: '',
      Contrasena: '',
      newcontrasena: '',
      newcontrasena2: '',
    },
  };

  peticionPut = () => {
    axios.put(url + this.state.form.USRID, this.state.form);
    this.props.history.push('/Menu');
  };

  handleChange = async (e) => {
    e.persist();
    await this.setState({
      form: {
        ...this.state.form,
        [e.target.name]: e.target.value,
      },
    });
    console.log(this.state.form);
  };

  render() {
    const { form } = this.state;
    return (
      <div className="UsuariosPasswords">
        <Header />

        <center>
          <h3 class="text-center">Cambiar Contraseña</h3>
          <hr />

          <br />

          <div class="form-group">
            <h5 class="control-label col-md-3">Identificador</h5>

            <div class="col-md-10">
              <input
                class="form-control"
                type="text"
                id="USRID"
                name="USRID"
                value={form.USRID}
                onChange={this.handleChange}
              ></input>
            </div>

            <br />
            <br />

            <h5 class="control-label col-md-3">
              <img src={icn2} width="25" height="25" /> Contraseña Antigua
            </h5>

            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="Contrasena"
                name="Contrasena"
                onChange={this.handleChange}
                value={form.Contrasena}
              ></input>
            </div>

            <br />
            <br />

            <h5 class="control-label col-md-3">
              <img src={icn1} width="25" height="25" /> Nueva Contraseña
            </h5>
            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="newcontrasena"
                name="newcontrasena"
                onChange={this.handleChange}
                value={form.newcontrasena}
              ></input>
            </div>

            <br />
            <br />

            <h5 class="control-label col-md-3">
              <img src={icn1} width="25" height="25" /> Confirmar Contraseña
            </h5>
            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="newcontrasena2"
                name="newcontrasena2"
                onChange={this.handleChange}
                value={form.newcontrasena2}
              ></input>
            </div>

            <br />
            <br />

            <div class="col-md-offset-2 col-md-10">
              <button
                className="btn text-white"
                onClick={() => this.peticionPut()}
                style={{
                  background: '#8C7811',
                }}
              >
                <img src={icn3} width="25" height="25" /> Actualizar
              </button>
            </div>

            <br />

            <div class="col-md-offset-2 col-md-10">
              <Link to="/Menu" className="btn btn-default border-dark">
                Cancelar
              </Link>
            </div>
          </div>
        </center>
        <Footer />
      </div>
    );
  }
}
export default Usuariospassword;
