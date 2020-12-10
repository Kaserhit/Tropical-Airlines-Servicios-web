/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from 'react';

import logo from '../assets/Logo/linea aeria blanco-04.png';
import logo2 from '../assets/Img/nenad-radojcic-RF5U8BkaQHU-unsplash.jpg';
import Dropdown from 'react-bootstrap/Dropdown';
import '../styles/Header.css';

import { NavLink } from 'react-router-dom';

import Cookies from 'universal-cookie';

import firebase from 'firebase';

const cookies = new Cookies();

class header2 extends Component {
  cerrarSesion = () => {
    cookies.remove('USRID', { path: '/' });
    cookies.remove('Primer_Apellido', { path: '/' });
    cookies.remove('Segundo_Apellido', { path: '/' });
    cookies.remove('Nombre', { path: '/' });
    cookies.remove('Usuario', { path: '/' });
    firebase.auth().signOut();

    window.location.href = './';
  };

   componentDidMount() {
    if(!cookies.get('Usuario')){
        alert("Usuario no loggeado");
        window.location.href="./";
    }
  }

  render() {
    // console.log('USRID: ' + cookies.get('USRID'));
    // console.log('Primer_Apellido: ' + cookies.get('Primer_Apellido'));
    // console.log('Segundo_Apellido: ' + cookies.get('Segundo_Apellido'));
    // console.log('Nombre: ' + cookies.get('Nombre'));
    // console.log('Usuario: ' + cookies.get('Usuario'));

    return (
      <header id="header">
        <nav
          class="navbar fixed-top navbar-expand-lg navbar-dark  scrolling-navbar"
          style={{
            background: '#8C7811',
          }}
        >
          <img src={logo} alt="Icono" width="100px" height="50px"></img>
          <a class="navbar-brand">
            <NavLink
              to="/Menu"
              activeStyle={{
                color: 'white',
              }}
            >
              <strong>Tropical Airlines</strong>
            </NavLink>
          </a>
          <button
            class="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
              <li class="nav-item">
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
                  </Dropdown.Menu>
                </Dropdown>
              </li>
              <li class="nav-item">
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

              <right>
                <li class="nav-item">
                  <div class="container">
                    <button
                      class="btn text-white disabled"
                      type="button"
                      id="User"
                      ia-haspopup="true"
                      aria-expanded="false"
                    >
                      Bienvenido Usuario
                    </button>
                  </div>
                </li>
              </right>
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
