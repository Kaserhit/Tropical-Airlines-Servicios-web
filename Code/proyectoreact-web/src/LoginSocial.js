import React, { Component } from 'react';
import firebase from 'firebase';
import StyledFirebaseAuth from 'react-firebaseui/StyledFirebaseAuth';
import { Redirect } from 'react-router-dom';

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
