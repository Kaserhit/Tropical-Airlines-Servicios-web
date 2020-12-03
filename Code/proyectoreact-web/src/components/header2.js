/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';
import Cookies from 'universal-cookie';
import Dropdown from 'react-bootstrap/Dropdown';

import logo from '../assets/Logo/linea aeria blanco-04.png';
import logo2 from '../assets/Img/nenad-radojcic-RF5U8BkaQHU-unsplash.jpg';
import '../styles/Header.css';

import firebase from 'firebase'
require('firebase/auth')

const cookies = new Cookies();

class header2 extends Component {
  cerrarSesion = () => {
    //console.log(cookies.get('Usuario'));
    if (typeof cookies.get('Primer_Apellido') === "undefined") {
      alert(`Hasta la próxima ${cookies.get('Nombre')}`);
    }
    else{
      alert(`Hasta la próxima ${cookies.get('Nombre')} ${cookies.get('Primer_Apellido')}`);
    }
    cookies.remove('USRID', { path: '/' });
    cookies.remove('Primer_Apellido', { path: '/' });
    cookies.remove('Segundo_Apellido', { path: '/' });
    cookies.remove('Nombre', { path: '/' });
    cookies.remove('Usuario', { path: '/' });
    firebase.auth().signOut();

    window.location.href = './';
  }

  // componentDidMount() {
  //   if(!cookies.get('Usuario')){
  //       alert("Usuario no loggeado");
  //       window.location.href="./";
  //   }
  // }

  render() {
    // console.log('USRID: ' + cookies.get('USRID'));
    // console.log('Primer_Apellido: ' + cookies.get('Primer_Apellido'));
    // console.log('Segundo_Apellido: ' + cookies.get('Segundo_Apellido'));
    // console.log('Nombre: ' + cookies.get('Nombre'));
    // console.log('Usuario: ' + cookies.get('Usuario'));

    return (
      <header id="header">
        <nav
          className="navbar fixed-top navbar-expand-lg navbar-dark  scrolling-navbar"
          style={{
            background: '#8C7811',
          }}
        >
          <img src={logo} alt="Icono" width="100px" height="50px"></img>
          <button className="btn">
            <NavLink
              to="/Menu"
              activeStyle={{
                color: 'White',
                backgroundColor: 'transparent'
              }}
            >
              <strong>Tropical Airlines</strong>
            </NavLink>
          </button>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav mr-auto">
              <li className="nav-item">
                <Dropdown>
                  <Dropdown.Toggle
                    style={{
                      background: '#8C7811',
                      border: 0,
                    }}
                    id="dropdown-basic"
                  >
                    Menu Principal
                  </Dropdown.Toggle>

                  <Dropdown.Menu>
                    <Dropdown.Item>
                      <NavLink
                        to="/VuelosSalida"
                        activeStyle={{
                          color: 'black',
                        }}
                      >
                        Vuelos de salida »
                      </NavLink>
                    </Dropdown.Item>
                    <Dropdown.Item>
                      <NavLink
                        to="/VuelosLlegada"
                        activeStyle={{
                          color: 'black',
                        }}
                      >
                        Vuelos de llegada »
                      </NavLink>
                    </Dropdown.Item>
                    <Dropdown.Item>Compra de boletos »</Dropdown.Item>
                    <Dropdown.Item>
                      <NavLink
                        to="/Reservaciones"
                        activeStyle={{
                          color: 'black',
                        }}
                      >
                        Reserva de boletos »
                      </NavLink>
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </li>
              <li className="nav-item">
                <Dropdown>
                  <Dropdown.Toggle
                    style={{
                      background: '#8C7811',
                      border: 0,
                    }}
                    id="dropdown-basic"
                  >
                    Opciones
                  </Dropdown.Toggle>

                  <Dropdown.Menu>
                    <Dropdown.Item href="http://localhost:62299">
                      Panel de Control »
                    </Dropdown.Item>
                    <Dropdown.Item>
                      <NavLink
                        to="/UsuariosPasswords"
                        activeStyle={{
                          color: 'black',
                        }}
                      >
                        Cambiar Contraseña »
                      </NavLink>
                    </Dropdown.Item>
                    <Dropdown.Item onClick={() => this.cerrarSesion()}>
                      Cerrar Sesión »
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
              </li>

              <li className="nav-item">
                  <div className="container">
                    <button
                      className="btn text-white disabled"
                      type="button"
                      id="User"
                      ia-haspopup="true"
                      aria-expanded="false"
                    >
                      Bienvenido Usuario
                    </button>
                  </div>
                </li>
            </ul>
          </div>
        </nav>
        <div>
          <img src={logo2} className="ImageHeader" alt="Icono"></img>
        </div>
      </header>
    );
  }
}

export default header2;
