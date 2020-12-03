import React, { Component } from 'react';
import StyledFirebaseAuth from 'react-firebaseui/StyledFirebaseAuth';
import { Redirect } from 'react-router-dom';
//import Cookies from 'universal-cookie';

import firebase from 'firebase'
require('firebase/auth')

//const cookies = new Cookies();

firebase.initializeApp({
  apiKey: 'AIzaSyChZW1ES9FwFR9yCzpO77lbyOGbUE-L_AY',
  authDomain: 'proyecto-vuelos-5c6e4.firebaseapp.com',
});

class LoginSocial extends Component {
  state = { isSignedIn: false };
  uiConfig = {
    signInFlow: 'popup',
    signInOptions: [
      firebase.auth.GoogleAuthProvider.PROVIDER_ID,
      firebase.auth.FacebookAuthProvider.PROVIDER_ID,
    ],
    callbacks: {
      signInSuccess: () => false,
    },
  };

  componentDidMount = () => {
    firebase.auth().onAuthStateChanged((user) => {
      
      this.setState({ isSignedIn: !!user });

      // if(this.state.isSignedIn === true) {
      //   this.setState({ isSignedIn: !!user });
      //   cookies.set('Usuario', user.displayName, {path: '/'});
      //   cookies.set('Nombre', user.displayName, {path: '/'});
      //   alert("Esta logeado");
      // }
      // else{
      //   this.setState({isSignedIn: false});
      //   cookies.remove('Nombre', { path: '/' });
      //   cookies.remove('Usuario', { path: '/' });
      //   alert("No Esta logeado");
      // }
      console.log('user', user);
    });
  };

  render() {
    return (
      <div className="App">
        {this.state.isSignedIn ? (
          <Redirect to="/Menu"></Redirect>
        ) : (
          <StyledFirebaseAuth
            uiConfig={this.uiConfig}
            firebaseAuth={firebase.auth()}
          />
        )}
      </div>
    );
  }
}

export default LoginSocial;
