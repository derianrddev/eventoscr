export const TicketItem = ({ ticket, handleTicketSelection }) => {
  return (
    <div className="col-md-4">
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
            onClick={() => handleTicketSelection(ticket)}
          >
            Comprar
          </button>
        </div>
      </div>
    </div>
  );
};