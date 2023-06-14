import { useEffect, useState } from "react";
import { getRequest } from "../../helpers";

export const TicketDelivery = () => {
  const [clients, setClients] = useState([]);

  useEffect(() => {
    getClients();
  }, []);

  const getClients = async () => {
    const url = "https://localhost:7052/api/User/GetUsersWithReservations";
    const result = await getRequest(url);

    if (result.ok) {
      setClients(result.data);
    }
  };

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      <h1 className="mb-4 fw-bold">Clientes</h1>
      <div className="table-responsive">
        <table className="table table-hover">
          <thead>
            <tr>
              <th scope="col">Nombre</th>
              <th scope="col">Correo</th>
              <th scope="col">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {clients.map((client) => (
              <tr key={client.id}>
                <td>{client.userName}</td>
                <td>{client.email}</td>
                <td>
                  <button
                    className="btn btn-primary m-0"
                    style={{
                      backgroundColor: "#0d6efd",
                      borderRadius: "5px",
                      height: "36px",
                    }}
                  >
                    <i className="fa-solid fa-circle-info"></i>
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
