import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { formatDate, getRequest } from "../../helpers";
import img from '../../images/llorando.png';
import { EventCard } from "../../components";

export const AvailableEvents = () => {
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
    if(role !== 'Cliente'){
      navigate('/Home')
    }else{
      getEvents();
    }
  }, []);

  const getEvents = async () => {
    const url = "https://localhost:7052/api/Eventos/GetAllDetalleEventosConEntradas";
    const result = await getRequest(url);

    if (result.ok) {
      setEvents(result.data);
    }
  };

  const handleBuyTickets = async (eventId) => {
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
              <EventCard key={event.id} event={event} handleEvent={handleBuyTickets} />
            ))}
          </div>
        </>
      )}
    </div>
  );
};
