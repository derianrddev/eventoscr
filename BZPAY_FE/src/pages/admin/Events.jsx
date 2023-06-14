import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { formatDate, getRequest } from "../../helpers";
import img from '../../images/tarea-completada.png';

export const Events = () => {
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);

  useEffect(() => {
    fetchEvents();
  }, []);

  const fetchEvents = async () => {
    const url =
      "https://localhost:7052/api/Eventos/GetAllDetalleEventosSinEntradas";
    const result = await getRequest(url);

    if (result.ok) {
      setEvents(result.data);
    }
  };

  const createTicket = async (eventId) => {
    navigate(`/CreateTickets/${eventId}`, { state: { eventId } });
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      {events.length === 0 ? (
        <>
          <h1 className="mb-4 fw-bold">No hay eventos sin entradas creadas</h1>
          <img src={img} alt="Imagen de eventos vacíos" />
        </>
      ) : (
        <>
          <h1 className="mb-4 fw-bold">Eventos sin entradas creadas</h1>
          <div className="row">
            {events.map((event) => (
              <div className="col-md-4" key={event.id}>
                <div className="card mt-3">
                  <div className="card-body">
                    <h5 className="card-title fw-bold">{event.descripcion}</h5>
                    <p className="card-text">
                      <i className="fa-solid fa-calendar-days pe-2"></i>
                      {formatDate(event.fecha)}
                    </p>
                    <p className="card-text">
                      <i className="fa-solid fa-location-dot pe-2"></i>
                      {event.escenario}
                    </p>
                    <p className="card-text">
                      <i className="fa-solid fa-people-group pe-2"></i>
                      {event.tipoEvento}
                    </p>
                    <button
                      className="btn btn-success"
                      style={{
                        backgroundColor: "#198754",
                        borderRadius: "5px",
                      }}
                      onClick={() => createTicket(event.id)}
                    >
                      Crear Entrada
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </>
      )}
    </div>
  );
};
