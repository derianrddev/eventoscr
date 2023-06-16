import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { pdf } from "@react-pdf/renderer";
import { formatDate, getRequest, postRequestUrl } from "../../helpers";
import { TicketPDF } from "../../components";

export const TicketDelivery = () => {
  const cookies = new Cookies();
  const location = useLocation();
  const navigate = useNavigate();
  const userId = location.state?.userId;
  const role = localStorage.getItem('roleName');

  const [clientTickets, setClientsTickets] = useState([]);

  useEffect(() => {
    if (!cookies.get("email")) {
      navigate("/");
    }
    if(role !== 'Cajero' || !userId){
      navigate('/Home')
    }else{
      getClientsTickets();
    }
  }, []);

  const getClientsTickets = async () => {
    const url = `https://localhost:7052/api/Compras/GetCompraByIdCliente/${userId}`;
    const result = await getRequest(url);

    if (result.ok) {
      setClientsTickets(result.data);
    }
  };

  const handlePrintTicket = async (ticketId) => {
    const url = `https://localhost:7052/api/Compras/ImprimirEntrada?idCompra=${ticketId}`;
    const result = await postRequestUrl(url);

    if (result.ok) {
      const pdfBlob = await pdf(
        <TicketPDF ticket={result.data} />
      ).toBlob();
      const pdfUrl = URL.createObjectURL(pdfBlob);
      const win = window.open(pdfUrl, "_blank");
      win.focus();
      getClientsTickets();
    }
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      <h1 className="mb-4 fw-bold">Entrega de entradas</h1>
      <div className="table-responsive mb-5">
        <table className="table table-hover">
          <thead>
            <tr>
              <th scope="col">Evento</th>
              <th scope="col">Cantidad</th>
              <th scope="col">Fecha de reserva</th>
              <th scope="col">Fecha de pago</th>
              <th scope="col">Asiento</th>
              <th scope="col">Precio</th>
              <th scope="col">Total</th>
              <th scope="col">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {clientTickets.map((ticket) => (
              <tr key={ticket.id}>
                <td>{ticket.evento}</td>
                <td>{ticket.cantidad}</td>
                <td>{formatDate(ticket.fechaReserva)}</td>
                <td>
                  {ticket.fechaPago !== "0001-01-01T00:00:00"
                    ? formatDate(ticket.fechaPago)
                    : "No ha realizado el pago"}
                </td>
                <td>{ticket.tipoAsiento}</td>
                <td>{ticket.precio}</td>
                <td>{ticket.total}</td>
                <td>
                  <button
                    className="btn btn-primary m-0"
                    style={{
                      backgroundColor: "#0d6efd",
                      borderRadius: "5px",
                      height: "36px",
                    }}
                    onClick={() => handlePrintTicket(ticket.id)}
                  >
                    <i className="fa-solid fa-print"></i>
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
