import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { getRequest } from "../../helpers";
import img from '../../images/tarea-completada.png';
import { EventCard } from "../../components";

export const Events = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);
  const role = localStorage.getItem('roleName');

  // window.addEventListener("load", function(event) {
  //   navigate('/Home')
  // });

  useEffect(() => {
    if (!cookies.get("email")) {
      navigate("/");
    }
    if(role !== 'Administrador'){
      navigate('/Home')
    }else{
      getEvents();
    }
  }, []);

  const getEvents = async () => {
    const url = "https://localhost:7052/api/Eventos/GetAllDetalleEventosSinEntradas";
    const result = await getRequest(url);

    if (result.ok) {
      setEvents(result.data);
    }
  };

  const handleCreateTicket = async (eventId) => {
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
              <EventCard key={event.id} event={event} handleEvent={handleCreateTicket} />
            ))}
          </div>
        </>
      )}
    </div>
  );
};
