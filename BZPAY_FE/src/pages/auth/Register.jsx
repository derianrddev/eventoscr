import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import Swal from "sweetalert2";
import "sweetalert2/dist/sweetalert2.css";
import "../../css/auth/Login.css";
import { useForm } from "../../hooks";
import { setUser } from "../../store/auth/authSlice";

const formData = {
  username: "",
  email: "",
  password: "",
};

export const Register = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [formSubmitted, setFormSubmitted] = useState(false);
  const { username, email, password, onInputChange } = useForm(formData);

  const handleSubmit = async (event) => {
    event.preventDefault();
    setFormSubmitted( true );

    if (username.length < 1) {
      Swal.fire("Error", "El nombre de usuario es obligatorio", "error");
    } else if (!email.includes("@") || !email.includes(".")) {
      Swal.fire("Error", "El correo debe de tener una @ y un punto.", "error");
    } else if (password.length < 6) {
      Swal.fire("Error", "La contraseña debe de tener más de 6 letras.", "error");
    } else {
      const url = "https://localhost:7052/api/User/Register";
      const origin = "https://localhost:3000";

      const register = {
        username,
        email,
        password,
      };

      const myHeaders = {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": origin,
      };

      const settings = {
        method: "post",
        headers: myHeaders,
        body: JSON.stringify(register),
      };

      try {
        const response = await fetch(url, settings);
        const data = await response.json();

        if (!response.status == 200) {
          Swal.fire("Error", "Lo siento, ha ocurrido un error al registrar la cuenta.", "error");
        }

        if (response.status === 200) {
          cookies.set("email", data.email, { path: "/" });
          dispatch(setUser(data));

          // Guardar la información en el localStorage
          localStorage.setItem("user", JSON.stringify(data));

          navigate("/Home");
        }
      } catch (error) {
        Swal.fire("Error", "Lo siento, ha ocurrido un error al registrar la cuenta.", "error");
      }
    }
    setFormSubmitted( false );
  };

  useEffect(() => {
    if (cookies.get("email")) {
      navigate("/Home");
    }
  }, []);

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
              Crear una cuenta
            </button>
            <br />
            <center>
              <Link className="text-dark" to="/">
                Iniciar sesión
              </Link>
            </center>
          </form>
        </div>
      </div>
    </div>
  );
};
