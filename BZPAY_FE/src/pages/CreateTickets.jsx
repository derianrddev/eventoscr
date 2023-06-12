import React from "react";
import { useLocation } from "react-router-dom";

export const CreateTickets = () => {
  const location = useLocation();
  const event = location.state.data;

  const formatDate = (unformattedDate) => {
    const date = new Date(unformattedDate);
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
  
    // Formatear la fecha como "DD/MM/YYYY"
    const formattedDate = `${day < 10 ? '0' + day : day}/${month < 10 ? '0' + month : month}/${year}`;
  
    return formattedDate;
  }

  return (
    <div className="container text-center" style={{ height: "calc(100vh - 56px)", padding: "100px 0" }}>
      <h1 className="mb-5">Detalles del evento</h1>
      <div className="row">
        <div className="col-md-6">
          <h5>Descripción:</h5>
          <p>{event.descripcion}</p>
        </div>
        <div className="col-md-6">
          <h5>Tipo de evento:</h5>
          <p>{event.tipoEvento}</p>
        </div>
        <div className="col-md-6">
          <h5>Fecha:</h5>
          <p>{formatDate(event.fecha)}</p>
        </div>
        <div className="col-md-6">
          <h5>Escenario:</h5>
          <p>{event.escenario}</p>
        </div>
        <div className="col-md-6">
          <h5>Tipo de escenario:</h5>
          <p>{event.tipoEscenario}</p>
        </div>
        <div className="col-md-6">
          <h5>Localización:</h5>
          <p>{event.localizacion}</p>
        </div>
      </div>
    </div>
  );
};

