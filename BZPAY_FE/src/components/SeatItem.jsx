export const SeatItem = ({seat, handleChangePrice}) => {
  return (
    <div className="mb-3 row d-flex align-items-center" key={seat.id}>
      <div className="col-md-6">
        <h5 className="fw-bold">{seat.tipoAsiento}</h5>
        <p className="mb-1">Cantidad: {seat.cantidad}</p>
      </div>
      <div className="col-md-6">
        <div className="input-group d-flex justify-content-center align-items-center">
          <label htmlFor={`precio-${seat.id}`} className="form-label m-0">
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
            onChange={(e) => handleChangePrice(seat.id, e.target.value)}
          />
        </div>
      </div>
    </div>
  );
};
