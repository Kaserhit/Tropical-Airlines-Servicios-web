/* eslint-disable jsx-a11y/anchor-has-content */
/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../styles/Footer.css';

import logo from '../assets/Logo/linea aeria blanco-04.png';
import icon1 from '../assets/icons/circle-cropped.png';

class Footer extends Component {
  render() {
    return (
      <footer
      className="text-white"
        style={{
          background: '#8C7811',
        }}
      >
        <div className="container">
          <br />
          <br />
          <div className="row ">
            <div className="col-md-5">
              <br />
              <p></p>
              <br />
              <center>
                <h4>
                  <img
                    src={logo}
                    alt="Icono"
                    width="150px"
                    height="100px"
                  ></img>
                   <a></a><b> Tropical Airlines </b>
                </h4>
              </center>
              <br />
              <p></p>
              <br />
            </div>

            <div className="col-md-2">
              <h4>
                <b>Compañia</b>
              </h4>
              <br />
              <p>
                <a href="#" className="text-white">
                  Acerca de nosotros
                </a>
              </p>
              <p>
                <a href="#" className="text-white">
                  Novedades
                </a>
              </p>
              <p>
                <a href="#" className="text-white">
                  Asociaciones
                </a>
              </p>
              <br />
            </div>

            <div className="col-md-2">
              <h4>
                <b>Soporte</b>
              </h4>
              <br />
              <p>
                <a href="#" className="text-white">
                  Ayuda
                </a>
              </p>
              <p>
                <a href="#" className="text-white">
                  Contactenos
                </a>
              </p>
            </div>

            <div className="col-md-3">
              <br />
              <p></p>
              <br />
              <center>
                <h4>
                  <img
                    src={icon1}
                    alt="Icono"
                    width="100px"
                    height="100px"
                  ></img>
                </h4>
              </center>
            </div>
          </div>
        </div>
      </footer>
    );
  }
}

export default Footer;
