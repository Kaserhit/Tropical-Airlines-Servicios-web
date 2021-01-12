import React from 'react';
import { useParams } from "react-router-dom";

import Compra from './CompraBoletos';

function GetVLOID() {
    const { id } = useParams();
    
    return (
        <div>
        <Compra id={id} />
        </div>
        );
    }
    
    export default GetVLOID