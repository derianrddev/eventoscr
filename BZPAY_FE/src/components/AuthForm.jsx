import { Link } from "react-router-dom";
import "../css/auth/Login.css";

export const AuthForm = ({page, onInputChange, handleSubmit, formSubmitted}) => {
  return (
    <div className="m-0 vh-100 row justify-content-center align-items-center login">
      <div className="container" style={{ padding: "35px 0" }}>
        <div className="card card-container mt-5">
          <br />
          <h1
            className="text-center text-white text-with-border"
            style={{ borderRadius: "5px" }}
          >
            <span style={{ color: "#001489" }}>E</span>ve
            <span style={{ color: "#DA291C" }}>nto</span>sC
            <span style={{ color: "#001489" }}>R</span>
          </h1>
          <hr />
          <form className="form-signin">
            {
              page === "register" && (
                <>
                  <p className="input_title text-dark">Usuario</p>
                  <input
                    type="text"
                    name="username"
                    id="username"
                    className="login_box"
                    onChange={onInputChange}
                    placeholder="pepe123"
                    required
                    autoFocus
                  />
                </>
              )
            }
            <p className="input_title text-dark">Correo</p>
            <input
              type="text"
              name="email"
              id="email"
              className="login_box"
              onChange={onInputChange}
              placeholder="correo@gmail.com"
              required
              autoFocus
            />
            <p className="input_title text-dark">Contraseña</p>
            <input
              type="password"
              name="password"
              id="password"
              className="login_box"
              onChange={onInputChange}
              placeholder="******"
              required
            />
            <button
              className="btn btn-lg btn-success"
              type="submit"
              onClick={handleSubmit}
              disabled={formSubmitted}
              style={{
                backgroundColor: "#198754",
                borderRadius: "5px",
              }}
            >
              { page === "login" ? "Iniciar sesión" : "Crear una cuenta" }
            </button>
            <br />
            <center>
              <Link className="text-dark" to={ page === "login" ? "/Register" : "/" }>
                { page === "login" ? "Crear cuenta" : "Iniciar sesión" }
              </Link>
            </center>
          </form>
        </div>
      </div>
    </div>
  );
};
