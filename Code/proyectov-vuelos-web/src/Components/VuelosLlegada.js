import React, { Component } from 'react';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link } from 'react-router-dom';

const url = "http://localhost:62299/api/VuelosLlegada/";

class VuelosLlegada extends Component {
    state = {
        data:[]
    }

    peticionGet = () => {
        axios.get(url).then(response=>{
            this.setState({data: response.data});
        }).catch(error=>{
            console.log(error.message);
        })
    }

    componentDidMount() {
        this.peticionGet();
    }

    render() {
        return (
            <div className="VuelosLlegada">
                <br /><br /><br />
                <center><h1>Vuelos de Llegada</h1></center>

                <Link to="/VuelosSalida" className="btn btn-dark">
                    Vuelos de Salida
                </Link>

                <br /><br />

                <table className="table">
                    <thead>
                        <tr>
                        <th>VUELO</th>
                        <th>AEROLINEA</th>
                        <th>PROCEDENCIA</th>
                        <th>FECHA</th>
                        <th>HORA</th>
                        <th>ESTADO</th>
                        <th>PUERTA</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.data.map(Vuelos=>{
                        return(
                            <tr>
                                <td>{Vuelos.CodVuelo}</td>
                                <td>{Vuelos.Aerolinea}</td>
                                <td>{Vuelos.Procedencia}</td>
                                <td>{Vuelos.Fecha_Vuelo}</td>
                                <td>{Vuelos.Hora}</td>
                                <td>{Vuelos.Estado}</td>
                                <td>{Vuelos.Vuelo_Aerop}</td>
                            </tr>
                        )
                        })}
                    </tbody>
                </table>
            </div>
        );
    }

}

export default VuelosLlegada;