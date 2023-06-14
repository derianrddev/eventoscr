import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import Swal from "sweetalert2";
import "sweetalert2/dist/sweetalert2.css";
import { formatDate, getRequest, postRequestUrl } from "../helpers";

export const CreateTickets = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const eventId = location.state.eventId;
  const { user } = useSelector((state) => state.auth);

  const [event, setEvent] = useState([]);
  const [seating, setSeating] = useState([]);

  useEffect(() => {
    getDetailEvent();
    getSeating();
  }, []);

  const getDetailEvent = async () => {
    const url = `https://localhost:7052/api/Eventos/GetDetalleEventosById/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      setEvent(result.data);
    }
  };

  const getSeating = async () => {
    const url = `https://localhost:7052/api/Eventos/GetDetalleAsientos/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      result.data.forEach((seat) => (seat.precio = 0));
      setSeating(result.data);
    }
  };

  const onChangePrice = (seatId, price) => {
    setSeating((prevSeating) =>
      prevSeating.map((seat) =>
        seat.id === seatId ? { ...seat, precio: price } : seat
      )
    );
  };

  const createTicket = async () => {
    const isEmptyInput = seating.some(
      (seat) => seat.precio === 0 || seat.precio === ""
    );

    if (isEmptyInput) {
      Swal.fire("Error", "Por favor, completa todos los precios de los asientos.", "error");
    } else {
      let error = false;
      for (const seat of seating) {
        const url = `https://localhost:7052/api/Entradas/CreateEntrada?disponibles=${seat.cantidad}&tipoAsiento=${seat.tipoAsiento}&precio=${seat.precio}&idEvento=${seat.idEvento}&userId=${user.id}`;
        const data = await postRequestUrl(url);
        if (data.ok === false) {
          error = true;
        }
      }
      if (error) {
        Swal.fire("Error", "No se pudieron crear las entradas.", "error");
      } else {
        Swal.fire("Entrada creada", "Se han creado las entradas del evento correctamente.", "success");
        navigate("/Home");
      }
    }
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      <h1 className="mb-5 fw-bold">{event.descripcion}</h1>
      <div className="row">
        <div className="col-md-6">
          <h3 className="mb-4 fw-bold">Detalles del evento</h3>
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
        </div>
        <div className="col-md-6">
          <h3 className="mb-4 fw-bold">Asientos</h3>
          {seating.map((seat) => (
            <div className="mb-3 row d-flex align-items-center" key={seat.id}>
              <div className="col-md-6">
                <h5 className="fw-bold">{seat.tipoAsiento}</h5>
                <p className="mb-1">Cantidad: {seat.cantidad}</p>
              </div>
              <div className="col-md-6">
                <div className="input-group d-flex justify-content-center align-items-center">
                  <label
                    htmlFor={`precio-${seat.id}`}
                    className="form-label m-0"
                  >
                    Precio:
                  </label>
                  <input
                    type="number"
                    id={`precio-${seat.id}`}
                    name={`precio-${seat.id}`}
                    className="form-control text-end ms-2"
                    style={{ maxWidth: "150px", borderRadius: "5px" }}
                    min="1"
                    value={seat.precio}
                    onChange={(e) => onChangePrice(seat.id, e.target.value)}
                  />
                </div>
              </div>
            </div>
          ))}
          <button
            type="submit"
            className="btn btn-success"
            style={{
              backgroundColor: "#198754",
              borderRadius: "5px",
              margin: "20px 0px 35px",
              width: "50%",
            }}
            onClick={createTicket}
          >
            Guardar
          </button>
        </div>
      </div>
    </div>
  );
};
