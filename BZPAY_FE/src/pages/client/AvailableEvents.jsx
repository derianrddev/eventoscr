import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { formatDate, getRequest } from "../../helpers";
import img from '../../images/llorando.png';

export const AvailableEvents = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);
  const role = localStorage.getItem('roleName');

  window.addEventListener("load", function(event) {
    navigate('/Home')
  });

  useEffect(() => {
    if (!cookies.get("email")) {
      navigate("/");
    }
    if(role == 'Cajero'){
      navigate('/Home')
    }else{
      getEvents();
    }
  }, []);

  const getEvents = async () => {
    const url =
      "https://localhost:7052/api/Eventos/GetAllDetalleEventosConEntradas";
    const result = await getRequest(url);

    if (result.ok) {
      setEvents(result.data);
    }
  };

  const buyTickets = async (eventId) => {
    navigate(`/BuyTickets/${eventId}`, { state: { eventId } });
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      {events.length === 0 ? (
        <>
          <h1 className="mb-4 fw-bold">No hay eventos disponibles</h1>
          <img src={img} alt="Imagen de eventos vacíos" />
        </>
      ) : (
        <>
          <h1 className="mb-4 fw-bold">Eventos disponibles</h1>
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
                      onClick={() => buyTickets(event.id)}
                    >
                      Ver entradas
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
