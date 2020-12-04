import React, { Component } from 'react';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import Cards from 'react-credit-cards';
import 'react-credit-cards/es/styles-compiled.css';
import Cookies from 'universal-cookie';

import Header from '../components/header2';
import Footer from '../components/Footer';

const url1 = 'http://localhost:62299/api/VuelosSalida/';
const url2 = 'http://localhost:49575/api/Tarjetas';
const url3 = 'http://localhost:49575/api/Easy_Pay';
const cookies = new Cookies();

class Compra extends Component {
  state = {
    data: [],
    tarjeta: [],
    tarjetas: [],
    easypay: [],
    Cant_Boletos: '',
    Total: '',
    modalTarjeta: false,
    modalTarjetas: false,
    modalEasyPay: false,
    metodopago: 'Seleccionar metodo de pago',
    form1: {
      USRID: '',
      Usuario: '',
      Nombre: '',
      Correo: '',
      Num_Tarjeta: '',
      Exp_Month: '',
      Exp_Year: '',
      CVV: '',
      Tipo_Tarjeta: '',
      Tipo: '',
      Limite_Tarjeta: '',
      Fondos: ''
    },
    form2: {
      EPID: '',
      USRID: '',
      Usuario: '',
      Nombre: '',
      Correo: '',
      Num_Cuenta: '',
      Cod_Seguridad: '',
      Password: '',
      Fondos: '',
    },
    form3: {
      CMPID: '',
      Compra_Usuario: '',
      Consec_Compra: '',
      Destino: '',
      Cant_Boletos: '',
      TotalCompra: ''
    }
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
        if (response[i].Usuario === cookies.get('Usuario')) {
          this.setState({ tarjetas: response[i] });
          // this.setState({form: {USRID: response[i].USRID, Usuario: response[i].Usuario, Nombre: response[i].Nombre, 
          //   Correo: response[i].Correo, Num_Tarjeta: response[i].Num_Tarjeta, Exp_Month: response[i].Exp_Month, Exp_Year: response[i].Exp_Year, 
          //   CVV: response[i].CVV, Tipo_Tarjeta: response[i].Tipo_Tarjeta, Tipo: response[i].Tipo, Limite_Tarjeta: response[i].Limite_Tarjeta, Fondos: response[i].Fondos}})
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }

  seleccionarTarjeta=(Tarjeta)=>{
    this.setState({
      tipoModal: 'actualizar',
      form1: {
        USRID: Tarjeta.USRID,
        Usuario: Tarjeta.Usuario,
        Nombre: Tarjeta.Nombre,
        Correo: Tarjeta.Correo,
        Num_Tarjeta: Tarjeta.Num_Tarjeta,
        Exp_Month: Tarjeta.Exp_Month,
        Exp_Year: Tarjeta.Exp_Year,
        CVV: Tarjeta.CVV,
        Tipo_Tarjeta: Tarjeta.Tipo_Tarjeta,
        Tipo: Tarjeta.Tipo,
        Limite_Tarjeta: Tarjeta.Limite_Tarjeta,
        Fondos: Tarjeta.Fondos
      }
    })
  }
  
  peticionPostTarjeta=async()=>{
    delete this.state.form1.USRID;
   await axios.post(url2,this.state.form).then(response=>{
      this.modalTarjeta();
    }).catch(error=>{
      console.log(error.message);
    })
  }

  peticionPostEasyPay=async()=>{
    delete this.state.form.id;
   await axios.post(url3,this.state.form).then(response=>{
      this.modalEasyPay();
    }).catch(error=>{
      console.log(error.message);
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

  handleInputChange=async e=>{
    e.persist();
    await this.setState({
      form1:{
        ...this.state.form1,
        [e.target.name]: e.target.value
      }
    });
    }
  
  modalTarjeta=()=>{
    this.setState({modalTarjeta: !this.state.modalTarjeta});
  }
  
  modalTarjetas=()=>{
    this.setState({modalTarjetas: !this.state.modalTarjetas});
  }
  
  modalEasyPay=()=>{
    this.setState({modalEasyPay: !this.state.modalEasyPay});
  }
  
  componentDidMount() {
    this.peticionGet();
    this.GetTarjetas();
  }
  
  render(){
    const {form1}=this.state;
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

    {this.state.metodopago==='Seleccionar metodo de pago'?
    <p></p>: this.state.metodopago==='Easy Pay'?
    <button className="btn btn-default border-dark" onClick={()=>{this.modalEasyPay()}}>Ver Easy Pay</button>: this.state.form1.Num_Tarjeta===''?
    <button className="btn btn-default border-dark" onClick={()=>{this.modalTarjeta()}}>Ver Tarjeta Crédito/Débito</button>: 
    <button className="btn btn-default border-dark" onClick={()=>{this.modalTarjetas()}}>Seleccionar Tarjeta Crédito/Débito</button>}
    
    <Modal isOpen={this.state.modalTarjetas}>
    <ModalHeader style={{display: 'block'}}>
    <span style={{float: 'right'}} onClick={()=>this.modalTarjetas()}>x</span>
    <h2 className="card-title">Tarjetas de Crédito/Débito</h2>
    
    </ModalHeader>
    <ModalBody>

    <Cards
    cvc={this.state.form1.CVV}
    expiry={this.state.form1.Exp_Month + '/' + this.state.form1.Exp_Year}
    focused={this.state.form1.focus}
    name={this.state.form1.name}
    number={this.state.form1.number}
    />
    
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.modalTarjetas()}>
    Seleccionar Tarjeta
    </button> 
    
    <button className="btn btn-default border-dark" onClick={()=>this.modalTarjetas()}>Cancelar</button>
    </ModalFooter>
    </Modal>
    
    <Modal isOpen={this.state.modalTarjeta}>
    <ModalHeader style={{display: 'block'}}>
    <span style={{float: 'right'}} onClick={()=>this.modalTarjeta()}>x</span>
    <h2 className="card-title">Tarjeta Crédito/Débito</h2>
    
    <Cards
    cvc={this.state.form1.CVV}
    expiry={this.state.form1.Exp_Month + '/' + this.state.form1.Exp_Year}
    focused={this.state.form1.focus}
    name={this.state.form1.name}
    number={this.state.form1.number}
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
    value={form1?form1.Num_Tarjeta: ''}
    onChange={this.handleInputChange}
    />
    <br />
    <label htmlFor="Name">Nombre</label>
    <input
    className="form-control"
    type="text"
    name="name"
    value={form1?form1.Num_Tarjeta: ''}
    onChange={this.handleInputChange}
    />
    <br />
    <label htmlFor="Expiry">Valida hasta:</label>
    <input
    className="form-control"
    type="tel"
    name="expiry"
    value={this.state.expiry}
    onChange={this.handleInputChange}
    />
    <br />
    <label htmlFor="CVC">CVC</label>
    <input
    className="form-control"
    type="tel"
    name="cvc"
    value={this.state.cvc}
    onChange={this.handleInputChange}
    />
    </center>    
    </form>
    </div>
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.modalTarjeta()}>
    Procesar
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