import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { getRequest } from "../../helpers";

export const Clients = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();
  const [clients, setClients] = useState([]);
  const role = localStorage.getItem('roleName');

  useEffect(() => {
    if (!cookies.get("email")) {
      navigate("/");
    }
    if(role == 'Cliente'){
      navigate('/Home')
    }else{
      getClients();
    }
  }, []);

  const getClients = async () => {
    const url = "https://localhost:7052/api/User/GetUsersWithReservations";
    const result = await getRequest(url);

    if (result.ok) {
      setClients(result.data);
    }
  };

  const handleViewTickets = (userId) => {
    navigate(`/TicketDelivery/${userId}`, { state: { userId } });
  }

  return (
    <div
      className="container text-center"
      style={{ minHeight: "calc(100vh - 56px)", paddingTop: "100px" }}
    >
      <h1 className="mb-4 fw-bold">Clientes</h1>
      <div className="table-responsive mb-5">
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
                    onClick={() => handleViewTickets(client.id)}
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
