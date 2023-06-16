import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import Cookies from "universal-cookie";
import Swal from "sweetalert2";
import "sweetalert2/dist/sweetalert2.css";
import { getRequest, postRequestUrl } from "../../helpers";
import { EventDetails, SeatItem } from "../../components";

export const CreateTickets = () => {
  const cookies = new Cookies();
  const location = useLocation();
  const navigate = useNavigate();
  const eventId = location.state?.eventId;
  const { user } = useSelector((state) => state.auth);
  const role = localStorage.getItem('roleName');

  const [seating, setSeating] = useState([]);

  useEffect(() => {
    if (!cookies.get("email")) {
      navigate("/");
    }
    if(role !== 'Administrador' || !eventId){
      navigate('/Home')
    }else{
      getSeating();
    }
  }, []);

  const getSeating = async () => {
    const url = `https://localhost:7052/api/Eventos/GetDetalleAsientos/${eventId}`;
    const result = await getRequest(url);

    if (result.ok) {
      result.data.forEach((seat) => (seat.precio = 0));
      setSeating(result.data);
    }
  };

  const handleChangePrice = (seatId, price) => {
    setSeating((prevSeating) =>
      prevSeating.map((seat) =>
        seat.id === seatId ? { ...seat, precio: price } : seat
      )
    );
  };

  const handleCreateTicket = async () => {
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
      <h1 className="mb-5 fw-bold">Crear entradas</h1>
      <div className="row">
        <div className="col-md-6">
          <EventDetails eventId={eventId} />
        </div>
        <div className="col-md-6">
          <h3 className="mb-4 fw-bold">Asientos</h3>
          {seating.map((seat) => (
            <SeatItem key={seat.id} seat={seat} handleChangePrice={handleChangePrice} />
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
            onClick={handleCreateTicket}
          >
            Guardar
          </button>
        </div>
      </div>
    </div>
  );
};
