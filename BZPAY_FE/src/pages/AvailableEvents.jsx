import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

export const AvailableEvents = () => {
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);

  useEffect(() => {
    fetchEvents();
  }, []);

  const fetchEvents = async () => {
    const url = "https://localhost:7052/api/Eventos/GetAllDetalleEventos";
    const origin = "https://localhost:3000";

    const myHeaders = {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": origin,
    };

    const settings = {
      method: "get",
      headers: myHeaders,
    };

    try {
      const response = await fetch(url, settings);
      const data = await response.json();

      if (!response.status == 200) {
        const message = `Un error ha ocurrido: ${response.status}`;
        throw new Error(message);
      }

      if (response.status === 200) {
        console.log(data);
        setEvents(data);
      }
    } catch (error) {
      throw Error(error);
    }
  };

  const formatDate = (unformattedDate) => {
    const date = new Date(unformattedDate);
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
  
    // Formatear la fecha como "DD/MM/YYYY"
    const formattedDate = `${day < 10 ? '0' + day : day}/${month < 10 ? '0' + month : month}/${year}`;
  
    return formattedDate;
  }

  const buyTicket = async(eventId) => {
    console.log(eventId);
  };

  return (
    <div className="container py-5 text-center" style={{ height: "calc(100vh - 56px)" }}>
      <h1 className="py-5">Eventos disponibles</h1>
      <div className="row">
        {events.map((event) => (
          <div className="col-md-4" key={event.id}>
            <div className="card mt-3">
              <div className="card-body">
                <h5 className="card-title">{event.descripcion}</h5>
                <p className="card-text"><i className="fa-solid fa-calendar-days pe-2"></i>{formatDate(event.fecha)}</p>
                <p className="card-text"><i className="fa-solid fa-location-dot pe-2"></i>{event.escenario}</p>
                <p className="card-text"><i className="fa-solid fa-people-group pe-2"></i>{event.tipoEvento}</p>
                <button
                  className="btn btn-success"
                  style={{
                    backgroundColor: "#198754",
                    borderRadius: "5px",
                  }}
                  onClick={() => buyTicket(event.id)}
                >
                  Comprar Entrada
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};
