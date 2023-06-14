import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Swal from "sweetalert2";
import "sweetalert2/dist/sweetalert2.css";
import { formatDate, getRequest, postRequestUrl } from "../helpers";
import { useSelector } from "react-redux";

export const BuyTickets = () => {
  const location = useLocation();
  const eventId = location.state.eventId;
  const { user } = useSelector((state) => state.auth);

  const [event, setEvent] = useState([]);
  const [tickets, setTickets] = useState([]);
  const [selectedTicket, setSelectedTicket] = useState(null);
  const [quantity, setQuantity] = useState(1);
  const [totalPrice, setTotalPrice] = useState(0);
  const [showModal, setShowModal] = useState(false);
  const [isBuying, setIsBuying] = useState(false);

  useEffect(() => {
    getDetailEvent();
    getTickets();
  }, []);

  const getDetailEvent = async () => {
    const url = `https://localhost:7052/api/Eventos/GetDetalleEventosById/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      setEvent(result.data);
    }
  };

  const getTickets = async () => {
    const url = `https://localhost:7052/api/Entradas/GetDetalleEntradas/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      setTickets(result.data);
    }
  };

  const ticketSelection = (ticket) => {
    setSelectedTicket(ticket);
    setQuantity(1);
    setTotalPrice(ticket.precio);
    setShowModal(true);
  };

  const quantityChange = (e) => {
    const value = parseInt(e.target.value);
    setQuantity(value);
    setTotalPrice(selectedTicket.precio * value);
  };

  const buyTickets = async () => {
    setIsBuying(true);
    if (selectedTicket.disponibles > quantity) {
      const url = `https://localhost:7052/api/Compras/CreateCompra?cantidad=${quantity}&idEntrada=${selectedTicket.id}&userId=${user.id}`;
      const data = await postRequestUrl(url);
      if (data.ok === false) {
        Swal.fire("Error", "Lo siento, no fue posible realizar la compra de las entradas.", "error");
      } else {
        // Actualizar el estado local de tickets utilizando prev
        setTickets((prevTickets) => {
          return prevTickets.map((ticket) => {
            if (ticket.id === selectedTicket.id) {
              return {
                ...ticket,
                disponibles: selectedTicket.disponibles - quantity,
              };
            }
            return ticket;
          });
        });
        setShowModal(false);
        Swal.fire("Entradas compradas", "Las entradas del evento se han comprado exitosamente.", "success");
      }
    } else {
      Swal.fire("Error", "Lo siento, no hay suficientes entradas disponibles.", "error");
    }
    setIsBuying(false);
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      <h1 className="mb-5 fw-bold">{event.descripcion}</h1>
      <div className="row text-center">
        <div className="col-lg-4">
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
        <div className="col-lg-8">
          <div className="row">
            <h3 className="mb-4 fw-bold">Entradas disponibles</h3>
            {tickets.map((ticket) => (
              <div className="col-md-4" key={ticket.id}>
                <div className="card mt-3">
                  <div className="card-body">
                    <h5 className="card-title fw-bold">{ticket.tipoAsiento}</h5>
                    <p className="card-text">
                      <i className="fa-solid fa-chair pe-2"></i>
                      {ticket.disponibles}
                    </p>
                    <p className="card-text">
                      <i className="fa-solid fa-tag pe-2"></i>₡{ticket.precio}
                    </p>
                    <button
                      className="btn btn-success"
                      style={{
                        backgroundColor: "#198754",
                        borderRadius: "5px",
                      }}
                      onClick={() => ticketSelection(ticket)}
                    >
                      Comprar entradas
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>

      {/* Modal */}
      {showModal && (
        <div className="modal fade show" style={{ display: "block" }}>
          <div className="modal-dialog modal-dialog-centered">
            <div className="modal-content">
              <div className="modal-header">
                <h4 className="modal-title fw-bold">Comprar entradas</h4>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowModal(false)}
                ></button>
              </div>
              <div className="modal-body">
                <div className="row justify-content-center align-items-center">
                  <div className="col-3">
                    <h5 className="modal-title">
                      {selectedTicket.tipoAsiento}
                    </h5>
                  </div>
                  <div className="col-3">
                    <p className="m-0">₡{selectedTicket.precio} c/u</p>
                  </div>
                  <div className="col input-group d-flex justify-content-center align-items-center">
                    <label htmlFor="quantityInput" className="form-label m-0">
                      Cantidad:
                    </label>
                    <input
                      type="number"
                      className="form-control text-end ms-3"
                      id="quantityInput"
                      value={quantity}
                      onChange={quantityChange}
                      min="1"
                      style={{ maxWidth: "150px", borderRadius: "5px" }}
                    />
                  </div>
                </div>
                <p className="mt-2 mb-0">Total: ₡{totalPrice}</p>
              </div>
              <div className="modal-footer">
                <button
                  type="button"
                  className="btn btn-danger my-0"
                  disabled={isBuying}
                  onClick={() => setShowModal(false)}
                  style={{
                    backgroundColor: "#dc3545",
                    borderRadius: "5px",
                  }}
                >
                  Cancelar
                </button>
                <button
                  type="button"
                  className="btn btn-success my-0"
                  onClick={buyTickets}
                  disabled={isBuying}
                  style={{
                    backgroundColor: "#198754",
                    borderRadius: "5px",
                  }}
                >
                  Comprar
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
      {/* End Modal */}
    </div>
  );
};
