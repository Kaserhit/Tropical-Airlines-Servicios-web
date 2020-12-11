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

var fondos = Math.floor(Math.random() * (10000000 - 0) + 0);

class Compra extends Component {
  state = {
    data: [],
    tarjetas: [],
    Cant_Boletos: '',
    Total: '',
    metodopago: 'Seleccionar metodo de pago',

    modalTarjeta: false,
    modalTarjetas: false,
    modalEasyPay: false,

    cvc: '',
    expiry: '',
    focus: '',
    name: '',
    number: '',

    form: {
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
      Fondos: '',
      focus: ''
    },
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
      USRID: cookies.get('USRID'),
      Usuario: cookies.get('Usuario'),
      Nombre: cookies.get('Nombre'),
      Correo: cookies.get('Correo'),
      Num_Cuenta: '',
      Cod_Seguridad: '',
      Password: '',
      Fondos: fondos
    },
    form3: {
      Compra_Usuario: '',
      Consec_Compra: '',
      Destino: '',
      Cant_Boletos: '',
      TotalCompra: ''
    },
    form4: {
      USRID: '',
      Usuario: '',
      Nombre: '',
      Correo: '',
      Num_Cuenta: '',
      Cod_Seguridad: '',
      Password: '',
      Fondos: ''
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
          //this.setState({ tarjetas: response[i] });
          this.setState({form: {USRID: response[i].USRID, Usuario: response[i].Usuario, Nombre: response[i].Nombre, 
            Correo: response[i].Correo, Num_Tarjeta: response[i].Num_Tarjeta, Exp_Month: response[i].Exp_Month, Exp_Year: response[i].Exp_Year, 
            CVV: response[i].CVV, Tipo_Tarjeta: response[i].Tipo_Tarjeta, Tipo: response[i].Tipo, Limite_Tarjeta: response[i].Limite_Tarjeta, Fondos: response[i].Fondos}})
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }

  GetEPAcc = async () => {
    await axios.get(url3)
    .then(response => {
      return response.data;
    })
    .then(response => {
      for (var i = 0; i < response.length; i++) {
        if (response[i].Usuario === cookies.get('Usuario')) {
          //this.setState({ tarjetas: response[i] });
          this.setState({form4: {USRID: response[i].USRID, Usuario: response[i].Usuario, Nombre: response[i].Nombre, 
            Correo: response[i].Correo, Num_Cuenta: response[i].Num_Cuenta, Cod_Seguridad: response[i].Cod_Seguridad, Password: response[i].Password, Fondos: response[i].Fondos}})
        }
      }
    })
    .catch(error => {
      console.log(error);
    })
  }
  
  peticionPostTarjeta=async()=>{

    var exp_month = this.state.expiry.split("/")[0];
    var exp_year = this.state.expiry.split("/")[1];

    let random_tipo_tarjeta = Math.floor(Math.random() * (2 - 0) + 0);
    let random_limite = Math.floor(Math.random() * (3 - 0) + 0);
    let random_fondos = Math.floor(Math.random() * (10000000 - 0) + 0);

    let tipo = '';
    let tipo_tarjeta = '';
    let limite = '';
    let limite_tarjeta = '';
    let fondos = '';

    this.state.number.charAt(0) === '5'? tipo = 'MC': tipo = 'V'

    random_tipo_tarjeta === 0? tipo_tarjeta = 'D': tipo_tarjeta = 'C'

    random_limite === 0? limite = '500000': random_limite === 1? limite = '1000000': limite = '10000000'

    tipo_tarjeta === 'C'? limite_tarjeta = limite: limite_tarjeta = '0'

    tipo_tarjeta === 'C'? fondos = '0': fondos = random_fondos

   await this.setState({ form1:
     {USRID: cookies.get('USRID'), Usuario: cookies.get('Usuario'), Correo: cookies.get('Correo'), CVV: this.state.cvc, Exp_Month: exp_month, Exp_Year: exp_year, 
     Nombre: this.state.name, Num_Tarjeta: this.state.number, Tipo: tipo, Tipo_Tarjeta: tipo_tarjeta, Limite_Tarjeta: limite_tarjeta, Fondos: fondos}});
    
    console.log(this.state.form1);

    random_tipo_tarjeta = 0;

   await axios.post(url2,this.state.form1).then(response=>{
      this.modalTarjeta();
      this.setState({
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
      }});
    }).catch(error=>{
      console.log(error.message);
    })
  }

  peticionPostEasyPay=async()=>{

   console.log(this.state.form2);

   await axios.post(url3,this.state.form2).then(response=>{
      this.modalEasyPay();
      this.setState({
        form2: {
        USRID: cookies.get('USRID'),
        Usuario: cookies.get('Usuario'),
        Nombre: cookies.get('Nombre'),
        Correo: cookies.get('Correo'),
        Num_Cuenta: '',
        Cod_Seguridad: '',
        Password: '',
        Fondos: fondos
      }});
    }).catch(error=>{
      console.log(error.message);
    })
  }

  peticionPostCompra=async()=>{
    await this.setState({ form3:
      {Compra_Usuario: cookies.get('USRID'), Consec_Compra: '1', Destino: this.state.data.Destino, Cant_Boletos: this.state.Cant_Boletos, TotalCompra: this.state.Total}});

   await axios.post(url1,this.state.form3).then(response=>{
      alert('Compra realizada con exito');
    }).catch(error=>{
      console.log(error.message);
    })
  }

  // peticionPutTarjeta=async()=>{
  //   await this.setState({form1: {
  //     Fondos: (this.state.form.Fondos - this.state.form3.TotalCompra)
  //   }});

  //   console.log(this.state.form1.Fondos)

  //   await axios.put(url2+this.state.form.USRID, this.state.form).then(response=>{
  //     <Redirect to="/VuelosSalida"></Redirect>
  //   })
  // }

  // peticionPutEasyPay=()=>{
  //   axios.put(url2+this.state.form4.USRID, this.state.form2).then(response=>{
  //     <Redirect to="/VuelosSalida"></Redirect>
  //   })
  // }

  handleChange=async e=>{
    e.persist();
    await this.setState({
      Cant_Boletos: e.target.value,
      Total: this.state.data.Monto*e.target.value
    });
  }

  handleForm2Change=async e=>{
    e.persist();
    await this.setState({
      form2:{
        ...this.state.form2,
        [e.target.name]: e.target.value
      }
    });
  }
  
  handleOption = async e => {
    await this.setState({metodopago: e.target.value});
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
    const {form2}=this.state;
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
    <button className="btn btn-default border-dark" onClick={()=>{this.modalEasyPay()}}>Ver Easy Pay</button>: this.state.form.Num_Tarjeta===''?
    <button className="btn btn-default border-dark" onClick={()=>{this.modalTarjeta()}}>Ver Tarjeta Crédito/Débito</button>: 
    <button className="btn btn-default border-dark" onClick={()=>{this.modalTarjetas()}}>Seleccionar Tarjeta Crédito/Débito</button>}

    <br />
    <br />

    <button className="btn btn-default border-dark" onClick={()=>{this.peticionPostCompra()}}>Comprar Boletos</button>

    {/* {this.state.metodopago==='Seleccionar metodo de pago'?
    <label htmlFor="metodopago">¡Seleccione un Metodo de Pago!</label>: this.state.metodopago==='Easy Pay'?
    <button className="btn btn-default border-dark" onClick={()=>{this.peticionPostCompra()}}>Comprar Boletos</button>: 
    <button className="btn btn-default border-dark" onClick={()=>{this.peticionPostCompra()}}>Comprar Boletos</button>} */}
    
    <Modal isOpen={this.state.modalTarjetas}>
    <ModalHeader style={{display: 'block'}}>
    <span style={{float: 'right'}} onClick={()=>this.modalTarjetas()}>x</span>
    <h2 className="card-title">Tarjetas de Crédito/Débito</h2>
    
    </ModalHeader>
    <ModalBody>

    <Cards
    cvc={this.state.form.CVV}
    expiry={this.state.form.Exp_Month + '/' + this.state.form.Exp_Year}
    focused={this.state.form.focus}
    name={this.state.form.Nombre}
    number={this.state.form.Num_Tarjeta}
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
    id="number"
    value={this.state.number?this.state.number: ''}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Name">Nombre</label>
    <input
    className="form-control"
    type="text"
    name="name"
    id="name"
    value={this.state.name?this.state.name: ''}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="Expiry">Valida hasta:</label>
    <input
    className="form-control"
    type="tel"
    name="expiry"
    id="expiry"
    value={this.state.expiry?this.state.expiry: ''}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    <br />
    <label htmlFor="CVC">CVC</label>
    <input
    className="form-control"
    type="tel"
    name="cvc"
    id="cvc"
    value={this.state.cvc?this.state.cvc: ''}
    onChange={this.handleInputChange}
    onFocus={this.handleInputFocus}
    />
    </center>    
    </form>
    </div>
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.peticionPostTarjeta()}>
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
    name="Num_Cuenta"
    id="Num_Cuenta"
    value={form2?form2.Num_Cuenta: ''}
    onChange={this.handleForm2Change}
    />
    <br />
    <label htmlFor="Cod_Seg">Codigo de Seguridad</label>
    <input
    className="form-control"
    type="number"
    name="Cod_Seguridad"
    id="Cod_Seguridad"
    value={form2?form2.Cod_Seguridad: ''}
    onChange={this.handleForm2Change}
    />
    <br />
    <label htmlFor="Password">Contraseña</label>
    <input
    className="form-control"
    type="password"
    name="Password"
    id="Password"
    value={form2?form2.Password: ''}
    onChange={this.handleForm2Change}
    />
    </center>    
    </form>
    </div>
    </ModalBody>
    
    <ModalFooter>
    <button className="btn btn-default border-dark" onClick={()=>this.peticionPostEasyPay()}>
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