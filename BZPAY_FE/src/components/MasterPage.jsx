import { Link, Outlet } from "react-router-dom";
import { NavigationMenu } from "./NavigationMenu";

export const MasterPage = () => {
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
            tabIndex="-1"
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
                <NavigationMenu />
              </ul>
            </div>
          </div>
          <div className="d-none d-lg-flex">
            <ul className="navbar-nav flex-row justify-content-end flex-grow-1 pe-3 gap-2">
              <NavigationMenu />
            </ul>
          </div>
        </div>
      </nav>
      <Outlet />
      <footer className="text-center text-white bg-dark">
        <div className="py-3">Todos los derechos reservados hasta 2023.</div>
      </footer>
    </>
  );
};
