import { formatDate } from "../helpers";

export const EventCard = ({ event, handleEvent }) => {
  return (
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
            onClick={() => handleEvent(event.id)}
          >
            Crear Entrada
          </button>
        </div>
      </div>
    </div>
  );
};
