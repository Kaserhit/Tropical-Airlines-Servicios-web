import React, { Component } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

import icn1 from '../assets/icons/181501-interface/181501-interface/svg/padlock.svg';
import icn2 from '../assets/icons/181501-interface/181501-interface/svg/user-3.svg';
import icn3 from '../assets/icons/181501-interface/181501-interface/svg/email.svg';

const url = 'http://localhost:62299/api/Seguridad';

class Usuarios extends Component {
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
      <div className="Usuarios">
        <center>
          <button
            className="btn text-white"
            style={{
              background: '#8C7811',
            }}
            onClick={() => {
              this.setState({ form: null, tipoModal: 'insertar' });
              this.modalInsertar();
            }}
          >
            Registrarse
          </button>
        </center>

        <Modal isOpen={this.state.modalInsertar}>
          <ModalHeader style={{ display: 'block', background: '#8C7811' }}>
            <span style={{ color: 'white' }}>Registro</span>
            <span
              style={{ float: 'right', color: 'white' }}
              onClick={() => this.modalInsertar()}
            >
              X
            </span>
          </ModalHeader>
          <ModalBody>
            <center>
              <div className="form-group">
                <label htmlFor="Usuario">Usuario</label>
                <input
                  className="form-control"
                  type="text"
                  name="Usuario"
                  id="Usuario"
                  onChange={this.handleChange}
                  value={form ? form.Usuario : ''}
                />
                <br />

                <label htmlFor="Contrasena">
                  <img src={icn1} alt="" width="25" height="25" /> Contrasena
                </label>
                <input
                  className="form-control"
                  type="password"
                  name="Contrasena"
                  id="Contrasena"
                  onChange={this.handleChange}
                  value={form ? form.Contrasena : ''}
                />
                <br />

                <label htmlFor="Nombre">
                  <img src={icn2} alt="" width="25" height="25" /> Nombre
                </label>
                <input
                  className="form-control"
                  type="text"
                  name="Nombre"
                  id="Nombre"
                  onChange={this.handleChange}
                  value={form ? form.Nombre : ''}
                />
                <br />
                <label htmlFor="Primer_Apellido">Primer Apellido</label>
                <input
                  className="form-control"
                  type="text"
                  name="Primer_Apellido"
                  id="Primer_Apellido"
                  onChange={this.handleChange}
                  value={form ? form.Primer_Apellido : ''}
                />
                <br />
                <label htmlFor="Segundo_Apellido">Segundo Apellido</label>
                <input
                  className="form-control"
                  type="text"
                  name="Segundo_Apellido"
                  id="Segundo_Apellido"
                  onChange={this.handleChange}
                  value={form ? form.Segundo_Apellido : ''}
                />
                <br />
                <label htmlFor="Pregunta">Pregunta</label>
                <select
                  class="form-control"
                  id="Pregunta"
                  name="Pregunta"
                  onChange={this.handleChange}
                  value={form ? form.Pregunta : ''}
                >
                  <option value="¿Cuál es el primer nombre de tu maestro favorito?">
                    ¿Cuál es el primer nombre de tu maestro favorito?
                  </option>
                  <option value="¿Cuál es tu comida favorita?">
                    ¿Cuál es tu comida favorita?
                  </option>
                  <option value="¿Cuál es el nombre de tu mascota favorita?">
                    ¿Cuál es el nombre de tu mascota favorita?
                  </option>
                  <option value="¿Cuál es el segundo nombre de tu padre?">
                    ¿Cuál es el segundo nombre de tu padre?
                  </option>
                  <option value="¿Cuál es tu ciudad natal?">
                    ¿Cuál es tu ciudad natal?
                  </option>
                  <option value="¿Cuál es el nombre de la escuela a la cual asistió?">
                    ¿Cuál es el nombre de la escuela a la cual asistió?
                  </option>
                </select>
                <br />
                <label htmlFor="Respuesta">Respuesta</label>
                <input
                  className="form-control"
                  type="text"
                  name="Respuesta"
                  id="Respuesta"
                  onChange={this.handleChange}
                  value={form ? form.Respuesta : ''}
                />
                <br />
                <label htmlFor="Correo">
                  <img src={icn3} alt="" width="25" height="25" /> Correo
                </label>
                <input
                  className="form-control"
                  type="text"
                  name="Correo"
                  id="Correo"
                  onChange={this.handleChange}
                  value={form ? form.Correo : ''}
                />
              </div>
            </center>
          </ModalBody>

          <ModalFooter>
            <button
              className="btn text-white mr-auto"
              style={{
                background: '#8C7811',
              }}
              onClick={() => this.peticionPost()}
            >
              Registrarse
            </button>

            <button
              className="btn btn-danger"
              onClick={() => this.modalInsertar()}
            >
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}
export default Usuarios;
