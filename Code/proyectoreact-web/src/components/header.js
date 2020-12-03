/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from 'react';
import logo from '../assets/Logo/linea aeria blanco-04.png';
import logo2 from '../assets/Img/nenad-radojcic-RF5U8BkaQHU-unsplash.jpg';
import '../styles/Header.css';

class Header extends Component {
  showDishes = (e) => {
    e.preventDefault();
    this.props.history.push('/platillos');
  };

  render() {
    return (
      <header id="header">
        <nav
          className="navbar fixed-top navbar-light"
          style={{
            background: '#8C7811',
          }}
        >
          <img src={logo} alt="Icono" width="100px" height="50px"></img>
          <a className="navbar-brand text-white" href="">
            <strong>Tropical Airlines</strong>
          </a>
          <button className="btn">
            {' '}
            <a className="text-white" onClick={this.showDishes}>
              <strong>Iniciar Sesion</strong>
            </a>
          </button>
        </nav>

        <div>
          <img src={logo2} className="ImageHeader" alt="Icono"></img>
        </div>
      </header>
    );
  }
}

export default Header;
