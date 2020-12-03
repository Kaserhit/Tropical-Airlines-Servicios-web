import React, { Component } from 'react';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import Cards from 'react-credit-cards';
import 'react-credit-cards/es/styles-compiled.css';

import Header from '../components/header2';
import Footer from '../components/Footer';

const url1 = 'http://localhost:62299/api/VuelosSalida/';
const url2 = 'http://localhost:49575/api/Tarjetas';
const url3 = 'http://localhost:49575/api/Easy_Pay';

class Compra extends Component {
  state = {
    data: [],
    tarjetas: [],
    easypay: [],
    Cant_Boletos: '',
    Total: '',
    modalTarjeta: false,
    modalEasyPay: false,
    cvc: '',
    expiry: '',
    focus: '',
    name: '',
    number: '',
    metodopago: '',
    accnumber: '',
    cod_seg: '',
    password: '',
  }
  
  peticionGet = async () => {
    await axios.get(url1)
    .then(response => {
      return response.data;
    })
    .then(response => {
      for (var i = 0; i < response.length; i++) {
        if (response[i].VLOID === parseInt(this.props.id)) {
          this.setState({ data: response[i] });
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }
  
  GetTarjetas = async () => {
    await axios.get(url2)
    .then(response => {
      return response.data;
    })
    .then(response => {
      for (var i = 0; i < response.length; i++) {
        if (response[i].USRID === parseInt(this.props.id)) {
          this.setState({ tarjetas: response[i] });
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }
  
  GetEasy_Pay = async () => {
    await axios.get(url3)
    .then(response => {
      return response.data;
    })
    .then(response => {
      for (var i = 0; i < response.length; i++) {
        if (response[i].USRID === parseInt(this.props.id)) {
          this.setState({ easypay: response[i] });
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }
  
  handleChange=async e=>{
    e.persist();
    await this.setState({
      Cant_Boletos: e.target.value,
      Total: this.state.data.Monto*e.target.value
    });
  }
  
  handleOption = async e => {
    await this.setState({metodopago: e.target.value});
    console.log(this.state.metodopago);
  }
  
  handleInputFocus = (e) => {
    this.setState({ focus: e.target.name });
  }
  
  handleInputChange = (e) => {
    const { name, value } = e.target;
    
    this.setState({ [name]: value });
  }
  
  modalTarjeta=()=>{
    this.setState({modalTarjeta: !this.state.modalTarjeta});
  }
  
  modalEasyPay=()=>{
    this.setState({modalEasyPay: !this.state.modalEasyPay});
  }
  
  componentDidMount() {
    this.peticionGet();
    this.GetTarjetas();
    this.GetEasy_Pay();
  }
  
  render(){
    return (
      <div className="Compra">
      
      <Header />
      
      <center>
      <div className="form-group">
      <label htmlFor="Destino">Destino</label>
      <input className="form-control" type="text" name="Destino" id="Destino" value={this.state.data.Destino} readOnly/>
      <br />
      <label htmlFor="Cant_Boletos">Cantidad de Boletos</label>
      <input className="form-control" type="number" name="Cant_Boletos" id="Cant_Boletos" onChange={this.handleChange} value={this.state.Cant_Boletos?this.state.Cant_Boletos: ''}/>
      <br />
      <label htmlFor="Total">Total de la Compra</label>
      <input className="form-control" type="number" name="Total" id="Total" readOnly value={this.state.Total?this.state.Total: ''}/>
      <br />
      
      <select class="form-control" id="metodopago" value={this.state.metodopago} onChange={this.handleOption}>
      <option selected value="Seleccionar metodo de pago">Seleccionar metodo de pago</option>
      <option value="Tarjeta de Credito/Debito">Tarjeta de Crédito/Débito</option>
      <option value="Easy Pay">Easy Pay</option>
      </select>
      
      <br />
      
      {this.state.metodopago==='Tarjeta de Credito/Debito'?
      <button className="btn btn-default border-dark" onClick={()=>{this.modalTarjeta()}}>Ver Tarjeta Crédito/Débito</button>: this.state.metodopago==='Easy Pay'?
      <button className="btn btn-default border-dark" onClick={()=>{this.modalEasyPay()}}>Ver Easy Pay</button>: <p></p>
    }
    
    
    <Modal isOpen={this.state.modalTarjeta}>
    <ModalHeader style={{display: 'block'}}>
    <span style={{float: 'right'}} onClick={()=>this.modalTarjeta()}>x</span>
    <h2 className="card-title">Tarjeta Crédito/Débito</h2>
    
    <Cards
    cvc={this.state.cvc}
    expiry={this.state.expiry}
    focused={this.state.focus}
    name={this.state.name}
    number={this.state.number}
    />
    
    </ModalHeader>
    <ModalBody>
    <div className="form-group">
    <form>
    <center>
    <label htmlFor="CardNumber">Numero de Tarjeta</label>
    <input
    className="form-control"
    type="tel"
    name="number"
    value={this.state.number}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Name">Nombre</label>
    <input
    className="form-control"
    type="text"
    name="name"
    value={this.state.name}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Expiry">Valida hasta:</label>
    <input
    className="form-control"
    type="tel"
    name="expiry"
    value={this.state.expiry}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="CVC">CVC</label>
    <input
    className="form-control"
    type="tel"
    name="cvc"
    value={this.state.cvc}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    </center>    
    </form>
    </div>
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.modalTarjeta()}>
    Aceptar
    </button> 
    
    <button className="btn btn-default border-dark" onClick={()=>this.modalTarjeta()}>Cancelar</button>
    </ModalFooter>
    </Modal>
    
    <Modal isOpen={this.state.modalEasyPay}>
    <ModalHeader style={{display: 'block'}}>
    <span style={{float: 'right'}} onClick={()=>this.modalEasyPay()}>x</span>
    <h2 className="card-title">Cuenta de Easy Pay</h2>
    
    </ModalHeader>
    <ModalBody>
    <div className="form-group">
    <form>
    <center>
    <label htmlFor="AccNumber">Numero de Cuenta</label>
    <input
    className="form-control"
    type="tel"
    name="accnumber"
    value={this.state.accnumber}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Cod_Seg">Codigo de Seguridad</label>
    <input
    className="form-control"
    type="number"
    name="cod_seg"
    value={this.state.cod_seg}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Password">Contraseña</label>
    <input
    className="form-control"
    type="password"
    name="password"
    value={this.state.password}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    </center>    
    </form>
    </div>
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.modalEasyPay()}>
    Procesar
    </button> 
    
    <button className="btn btn-default border-dark" onClick={()=>this.modalEasyPay()}>Cancelar</button>
    </ModalFooter>
    </Modal>
    
    </div>
    </center>
    
    <Footer />
    
    </div>
    );
  }
}

export default Compra