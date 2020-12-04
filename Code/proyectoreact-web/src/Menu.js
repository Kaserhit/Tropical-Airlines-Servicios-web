import React, { Component } from 'react';

import CR from './assets/icons/330422-international-flags/svg/156-costa-rica.svg';
import BR from './assets/icons/330422-international-flags/svg/255-brazil.svg';
import MX from './assets/icons/330422-international-flags/svg/252-mexico.svg';

import PV from './assets/Img/puerto-viejo-4048875_960_720.jpg';
import RJ from './assets/Img/rio-de-janeiro-1963744__340.jpg';
import CN from './assets/Img/cancun-1235489_1920.jpg';

import Header from './components/header2';
import Footer from './components/Footer';

class Menu extends Component {
  render() {
    return (
      <div className="Menu">
        <center>
          <Header />

          <h2 class="bg-info p-4 text-center text-white">
            <strong>
              <b>Visite distintos Paises Tropicales</b>
            </strong>
          </h2>

          <br />

          <br />

          <br />

          <div class="container">
            <div class="row justify-content-md-center">
              <div class="col col-lg-4">
                <img src={CR} width="150" height="150" alt="Costa Rica" />
                <h2>Costa Rica</h2>
                <br />
              </div>
              <div class="col col-lg-4">
                <img src={BR} width="150" height="150" alt="Brazil" />
                <h2>Brazil</h2>
                <br />
              </div>
              <div class="col col-lg-4">
                <img src={MX} width="150" height="150" alt="Mexico" />
                <h2>Mexico</h2>
                <br />
              </div>
            </div>
          </div>

          <br />

          <br />

          <br />

          <div class="container">
            <div class="row justify-content-md-center">
              <div class="col col-lg-4">
                <img src={PV} width="170" height="150" alt="Puerto Viejo" />
                <h2>Puerto Viejo</h2>
                <br />
              </div>
              <div class="col col-lg-4">
                <img src={RJ} width="150" height="150" alt="Rio de Janeiro" />

                <h2>Rio de Janeiro</h2>
                <br />
              </div>
              <div class="col col-lg-4">
                <img src={CN} width="150" height="150" alt="Cancun" />
                <h2>Cancun</h2>
                <br />
              </div>
            </div>
          </div>
          <Footer />
        </center>
      </div>
    );
  }
}

export default Menu;
