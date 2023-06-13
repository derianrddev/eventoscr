import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { formatDate, getRequest } from "../helpers";

export const AvailableEvents = () => {
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);

  useEffect(() => {
    getEvents();
  }, []);

  const getEvents = async () => {
    const url = "https://localhost:7052/api/Eventos/GetAllDetalleEventos";
    const result = await getRequest(url);

    if (result.ok) {
      setEvents(result.data);
    }
  };

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
