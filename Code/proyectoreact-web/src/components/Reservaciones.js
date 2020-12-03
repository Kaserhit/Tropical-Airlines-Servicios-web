import React, { Component } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from '../components/header2';
import Footer from '../components/Footer';

const url = 'http://localhost:62299/api/Reservas';

var caracteres = 'abcdefghijkmnpqrtuvwxyzABCDEFGHJKMNPQRTUVWXYZ2346789';
var contraseña = '';
let i;
for (i = 0; i < 7; i++)
contraseña += caracteres.charAt(
  Math.floor(Math.random() * caracteres.length)
  );
  
  let reserv = Math.floor(Math.random() * (2000000 - 1)) + 1;
  
  class Reservaciones extends Component {
    state = {
      data: [],
      modalInsertar: false,
      form: {
        RSVID: '',
        Reserva_Usuario: '',
        Consec_Reserva: '',
        Destino: '',
        Cant_Boletos: '',
        TotalCompra: '',
        Num_Reserva: '',
        BookingID: '',
      },
    };
    
    peticionPost = async () => {
      delete this.state.form.RSVID;
      await axios
      .post(url, this.state.form)
      .then((response) => {
        this.modalInsertar();
        this.props.history.push('/Menu');
        alert('Reservacion realizada!!!');
      })
      .catch((error) => {
        console.log(error.message);
        this.props.history.push('/Reservaciones');
        alert(
          'Fallo en la reservacion contacte a soporte o vuelva a intentarlo'
          );
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
          <div className="Reservaciones">
          <Header />
          
          <center>
          <h1>Reservacion de Boletos</h1>
          </center>
          
          <br />
          <hr />
          <br />
          
          <center>
          <div class="container">
          <div class="row justify-content-md-center">
          <div class="col col-lg-5">
          <label htmlFor="Reserva_Usuario">Usuario</label>
          <input
          className="form-control"
          type="number"
          name="Reserva_Usuario"
          id="Reserva_Usuario"
          onChange={this.handleChange}
          value={form ? form.Reserva_Usuario : ''}
          />
          <br />
          </div>
          <div class="col col-lg-5">
          <label htmlFor="Consec_Reserva">Consecutivo</label>
          <input
          className="form-control"
          type="number"
          name="Consec_Reserva"
          id="Consec_Reserva"
          onChange={this.handleChange}
          value={form ? form.Consec_Reserva : ''}
          />
          <br />
          </div>
          </div>
          </div>
          
          <div class="container">
          <div class="row justify-content-md-center">
          <div class="col col-lg-5">
          <label htmlFor="Destino">Destino</label>
          <input
          className="form-control"
          type="text"
          name="Destino"
          id="Destino"
          onChange={this.handleChange}
          value={form ? form.Destino : ''}
          />
          <br />
          </div>
          <div class="col col-lg-5">
          <label htmlFor="Num_Reserva">Numero de Reserva</label>
          <input
          className="form-control"
          type="text"
          name="Num_Reserva"
          id="Num_Reserva"
          onChange={this.handleChange}
          disabled
          value={form ? (form.Num_Reserva = reserv) : ''}
          />
          <br />
          </div>
          </div>
          </div>
          
          <div class="container">
          <div class="row justify-content-md-center">
          <div class="col col-lg-5">
          <label htmlFor="Cant_Boletos">Cantidad de Boletos</label>
          <input
          className="form-control"
          type="number"
          name="Cant_Boletos"
          id="Cant_Boletos"
          onChange={this.handleChange}
          value={form ? form.Cant_Boletos : ''}
          />
          <br />
          </div>
          <div class="col col-lg-5">
          <label htmlFor="BookingID">BookingID</label>
          <input
          className="form-control"
          type="text"
          name="BookingID"
          id="BookingID"
          onChange={this.handleChange}
          disabled
          value={form ? (form.BookingID = contraseña) : ''}
          />
          <br />
          </div>
          </div>
          </div>
          
          <div class="container">
          <div class="row justify-content-md-center">
          <div class="col col-lg-5">
          <label htmlFor="Pregunta">Metodo de pago</label>
          <select class="form-control" onChange={this.handleChange}>
          <option value="Tarjeta de credito">Tarjeta de credito</option>
          <option value="Easy Pay">Easy Pay</option>
          </select>
          <br />
          </div>
          <div class="col col-lg-5">
          <label htmlFor="Cant_Boletos">Total de la Compra</label>
          <input
          className="form-control"
          type="number"
          name="TotalCompra"
          id="TotalCompra"
          onChange={this.handleChange}
          value={form ? form.TotalCompra : ''}
          />
          <br />
          </div>
          </div>
          </div>
          
          <br />
          <br />
          
          <h7 class="bg-warning text-dark d-inline">
          *Estimado usuario le recordamos que se debe presentar 3 horas antes
          en la caja para recoger y pagar los boletos de viaje*
          </h7>
          
          <br />
          <br />
          
          <button
          className="btn text-white mr-auto"
          style={{
            background: '#8C7811',
          }}
          onClick={() => this.peticionPost()}
          >
          Confirmar Reservacion
          </button>
          </center>
          <Footer />
          </div>
          );
        }
      }
      export default Reservaciones;
