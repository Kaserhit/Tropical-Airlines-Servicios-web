import React, { Component } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from '../components/header2';
import Footer from '../components/Footer';

import icn1 from '../assets/icons/181501-interface/181501-interface/svg/padlock.svg';
import icn2 from '../assets/icons/181501-interface/181501-interface/svg/shield-1.svg';
import icn3 from '../assets/icons/181501-interface/181501-interface/svg/settings.svg';

const url = 'http://localhost:62299/api/Seguridad';

class Usuariospassword extends Component {
  state = {
    data: [],
    modalInsertar: false,
    form: {
      USRID: '',
      Usuario: '',
      Contrasena: '',
      Nombre: '',
      Primer_Apellido: '',
      Segundo_Apellido: '',
      Pregunta: '',
      Respuesta: '',
      Correo: '',
    },
  };

  peticionPost = async () => {
    delete this.state.form.USRID;
    await axios
      .post(url, this.state.form)
      .then((response) => {
        this.modalInsertar();
        this.peticionGet();
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  modalInsertar = () => {
    this.setState({ modalInsertar: !this.state.modalInsertar });
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
            <h5 class="control-label col-md-3">
              <img src={icn2} width="25" height="25" /> Contraseña Antigua
            </h5>

            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="Contrasena"
                name="Contrasena"
              ></input>
            </div>
          </div>

          <br />

          <div class="form-group">
            <h5 class="control-label col-md-3">
              <img src={icn1} width="25" height="25" /> Nueva Contraseña
            </h5>
            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="newcontrasena"
                name="newcontrasena"
              ></input>
            </div>
          </div>

          <br />

          <div class="form-group">
            <h5 class="control-label col-md-3">
              <img src={icn1} width="25" height="25" /> Confirmar Contraseña
            </h5>
            <div class="col-md-10">
              <input
                class="form-control"
                type="password"
                id="newcontrasena2"
                name="newcontrasena2"
              ></input>
            </div>
          </div>

          <br />

          <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
              <button
                className="btn text-white mr-auto"
                style={{
                  background: '#8C7811',
                }}
                onClick={() => this.peticionPost()}
              >
                <img src={icn3} width="25" height="25" /> Cambiar Contraseña
              </button>
            </div>

            <br />

            <div class="col-md-offset-2 col-md-10">
              <a class="btn btn-default border"> Cancelar</a>
            </div>
          </div>
        </center>
        <Footer />
      </div>
    );
  }
}
export default Usuariospassword;
