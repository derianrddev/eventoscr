import { useDispatch } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { cleanUser } from "../store/auth/authSlice";

export const NavigationMenu = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const role = localStorage.getItem("roleName");

  const logout = () => {
    cookies.remove("email", { path: "/" });
    dispatch(cleanUser());

    // Limpiar los datos del localStorage
    localStorage.removeItem("user");
    localStorage.removeItem("roleName");

    navigate("/");
  };

  return (
    <>
      <li className="nav-item">
        <NavLink
          className="nav-link"
          exact="true"
          to="/Home"
          activeclassname="active"
          aria-current="page"
        >
          Home
        </NavLink>
      </li>
      {role === "Administrador" && (
        <>
          <li className="nav-item">
            <NavLink
              className="nav-link"
              exact="true"
              to="/Events"
              activeclassname="active"
              aria-current="page"
            >
              Crear entradas
            </NavLink>
          </li>
        </>
      )}
      {role === "Cliente" && (
        <>
          <li className="nav-item">
            <NavLink
              className="nav-link"
              exact="true"
              to="/AvailableEvents"
              activeclassname="active"
              aria-current="page"
            >
              Reservar entradas
            </NavLink>
          </li>
        </>
      )}
      {role === "Cajero" && (
        <>
          <li className="nav-item">
            <NavLink
              className="nav-link"
              exact="true"
              to="/Clients"
              activeclassname="active"
              aria-current="page"
            >
              Entrega de entradas
            </NavLink>
          </li>
        </>
      )}
      <li className="nav-item">
        <button
          className="btn btn-danger mb-0"
          style={{
            backgroundColor: "#dc3545",
            borderRadius: "5px",
            height: "40px",
          }}
          onClick={() => logout()}
        >
          <i className="fa-solid fa-right-from-bracket"></i> Cerrar Sesión
        </button>
      </li>
    </>
  );
};
