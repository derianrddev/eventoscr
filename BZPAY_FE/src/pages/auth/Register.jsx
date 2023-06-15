import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import Swal from "sweetalert2";
import "sweetalert2/dist/sweetalert2.css";
import { useForm } from "../../hooks";
import { setUser } from "../../store/auth/authSlice";
import { AuthForm } from "../../components";
import { getUserDetails } from "../../helpers";

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
          getUserDetails(data.id);

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
    let isMounted = true;

    if (cookies.get("email")) {
      navigate("/Home");
    }

    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <AuthForm page="register" onInputChange={onInputChange} handleSubmit={handleSubmit} formSubmitted={formSubmitted} />
  );
};
