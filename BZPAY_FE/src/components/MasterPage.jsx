import { Link, NavLink, useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
// import { faPhone } from '@fortawesome/free-solid-svg-icons';

export const MasterPage = ({ children }) => {
  const cookies = new Cookies();
  const navigate = useNavigate();

  const logout = () => {
    cookies.remove("username", { path: "/" });
    navigate("/");
  };

  return (
    <>
      <nav className="navbar navbar-dark bg-dark fixed-top">
        <div className="container-fluid">
          <Link to="/Home" className="navbar-brand">
            <span style={{ color: "#001489" }}>E</span>ve
            <span style={{ color: "#DA291C" }}>nto</span>sC
            <span style={{ color: "#001489" }}>R</span>
          </Link>
          <div className="d-lg-none">
            <button
              className="navbar-toggler"
              type="button"
              data-bs-toggle="offcanvas"
              data-bs-target="#offcanvasDarkNavbar"
              aria-controls="offcanvasDarkNavbar"
            >
              <span className="navbar-toggler-icon"></span>
            </button>
          </div>
          <div
            className="offcanvas offcanvas-end text-bg-dark d-lg-none"
            tabindex="-1"
            id="offcanvasDarkNavbar"
            aria-labelledby="offcanvasDarkNavbarLabel"
          >
            <div className="offcanvas-header">
              <h5 className="offcanvas-title" id="offcanvasDarkNavbarLabel">
                Menú
              </h5>
              <button
                type="button"
                className="btn-close btn-close-white"
                data-bs-dismiss="offcanvas"
                aria-label="Close"
              ></button>
            </div>
            <div className="offcanvas-body pt-0">
              <ul className="navbar-nav justify-content-end flex-grow-1 pe-3">
                <li className="nav-item">
                  <NavLink
                    className="nav-link"
                    exact
                    to="/Home"
                    activeClassName="active"
                    aria-current="page"
                  >
                    Home
                  </NavLink>
                </li>
                <li className="nav-item">
                  <NavLink
                    className="nav-link"
                    exact
                    to="/Events"
                    activeClassName="active"
                    aria-current="page"
                  >
                    Crear entradas
                  </NavLink>
                </li>
                <li className="nav-item">
                  <NavLink
                    className="nav-link"
                    exact
                    to="/AvailableEvents"
                    activeClassName="active"
                    aria-current="page"
                  >
                    Reservar entradas
                  </NavLink>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#">
                    Entrega de entradas
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#" onClick={() => logout()}>
                    <i className="fa-solid fa-right-from-bracket"></i>
                  </a>
                </li>
              </ul>
            </div>
          </div>
          <div className="d-none d-lg-flex">
            <ul className="navbar-nav flex-row justify-content-end flex-grow-1 pe-3 gap-2">
              <li className="nav-item">
                <NavLink
                  className="nav-link"
                  exact
                  to="/Home"
                  activeClassName="active"
                  aria-current="page"
                >
                  Home
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink
                  className="nav-link"
                  exact
                  to="/Events"
                  activeClassName="active"
                  aria-current="page"
                >
                  Crear entradas
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink
                  className="nav-link"
                  exact
                  to="/AvailableEvents"
                  activeClassName="active"
                  aria-current="page"
                >
                  Reservar entradas
                </NavLink>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#">
                  Entrega de entradas
                </a>
              </li>
              <li className="nav-item">
                <button
                  className="btn btn-danger mb-0"
                  style={{
                    backgroundColor: "#dc3545",
                    borderRadius: "5px",
                    height: "40px"
                  }}
                  onClick={() => logout()}
                >
                  <i className="fa-solid fa-right-from-bracket"></i> Cerrar
                  Sesión
                </button>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      {children}
      <footer className="text-center text-white bg-dark">
        <div className="py-3">Todos los derechos reservados hasta 2023.</div>
      </footer>
    </>
  );
};
