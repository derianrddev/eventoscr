import { useEffect, useState } from "react";
import { formatDate, getRequest } from "../helpers";

export const EventDetails = ({ eventId }) => {
  const [event, setEvent] = useState({});

  useEffect(() => {
    getDetailEvent();
  }, []);

  const getDetailEvent = async () => {
    const url = `https://localhost:7052/api/Eventos/GetDetalleEventosById/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      setEvent(result.data);
    }
  };

  return (
    <>
      <h3 className="mb-4 fw-bold">Detalles del evento</h3>
      <h5 className="mb-4">
        <strong>Nombre:</strong> {event.descripcion}
      </h5>
      <h5 className="mb-4">
        <strong>Tipo de evento:</strong> {event.tipoEvento}
      </h5>
      <h5 className="mb-4">
        <strong>Fecha:</strong> {formatDate(event.fecha)}
      </h5>
      <h5 className="mb-4">
        <strong>Escenario:</strong> {event.escenario}
      </h5>
      <h5 className="mb-4">
        <strong>Tipo de escenario:</strong> {event.tipoEscenario}
      </h5>
      <h5 className="mb-4">
        <strong>Localización:</strong> {event.localizacion}
      </h5>
    </>
  );
};