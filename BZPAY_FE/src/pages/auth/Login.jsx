import { useState, useEffect, useRef } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import "../../css/auth/Login.css";
import { useTranslation } from "react-i18next";
import ReCAPTCHA from "react-google-recaptcha";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { setUser } from "../../store/auth/authSlice";

function Login() {
  const captcha = useRef(null);
  const cookies = new Cookies();
  const navigate = useNavigate();
  const { t, i18n } = useTranslation();
  const dispatch = useDispatch();
  const [captchaValido, cambiarCaptchaValido] = useState(null);
  const [usuarioValido, cambiarUsuarioValido] = useState(null);
  const [userValido, cambiarUserValido] = useState(null);
  const [passwordValido, cambiarPasswordValido] = useState(null);
  const [credencialesValido, cambiarCredenciales] = useState(null);

  const [form, setForm] = useState({
    username: "",
    password: "",
  });

  const onChange = (e) => {
    const { name, value } = e.target;
    setForm(
      {
        ...form,
        [name]: value,
      },
      []
    );
  };

  const onChangeCaptcha = () => {
    if (captcha.current.getValue()) cambiarCaptchaValido(true);
  };

  const onClickUser = () => {
    cambiarUserValido(true);
    cambiarCredenciales(true);
  };

  const onClickPassword = () => {
    cambiarPasswordValido(true);
    cambiarCredenciales(true);
  };

  const handleClick = (event) => {
    event.preventDefault();
    var valid = true;
    form.username === ""
      ? cambiarUserValido((valid = false))
      : cambiarUserValido((valid = true));
    form.password === ""
      ? cambiarPasswordValido((valid = false))
      : cambiarPasswordValido((valid = true));
    if (captcha.current.getValue()) {
      cambiarUsuarioValido((valid = true));
      cambiarCaptchaValido((valid = true));
    } else {
      cambiarUsuarioValido((valid = false));
      cambiarCaptchaValido((valid = false));
    }
    if (valid) iniciarSesion();
  };

  const iniciarSesion = async () => {
    const url = "https://localhost:7052/api/User/StartSession";
    const origin = "https://localhost:3000";

    const login = {
      username: form.username,
      password: form.password,
    };

    const myHeaders = {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": origin,
    };

    const settings = {
      method: "post",
      headers: myHeaders,
      body: JSON.stringify(login),
    };

    try {
      const response = await fetch(url, settings);
      const data = await response.json();

      if (!response.status == 200 || !response.status == 404) {
        const message = `Un error ha ocurrido: ${response.status}`;
        throw new Error(message);
      }

      if (response.status === 200) {
        cookies.set("username", data.userName, { path: "/" });
        dispatch(setUser(data));

        // Guardar la información en el localStorage
        localStorage.setItem("user", JSON.stringify(data));

        navigate("/Home");
      }

      if (response.status === 404) {
        cambiarCredenciales(false);
      }
    } catch (error) {
      throw Error(error);
    }
  };

  useEffect(() => {
    if (cookies.get("username")) {
      navigate("/Home");
    }
  }, []);

  return (
    <div
      className="m-0 row justify-content-center align-items-center login"
      style={{ height: "calc(100vh - 56px)" }}
    >
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
            <span id="reauth-email" className="reauth-email"></span>
            <p className="input_title text-dark">{t("user")}</p>
            <input
              type="text"
              name="username"
              id="username"
              className="login_box"
              onChange={onChange}
              onClick={onClickUser}
              placeholder={t("correo@gmail.com")}
              required
              autoFocus
            />
            {userValido === false && (
              <div className="user_error">{t("user_error")}</div>
            )}
            <p className="input_title text-dark">{t("password")}</p>
            <input
              type="password"
              name="password"
              id="password"
              className="login_box"
              onChange={onChange}
              onClick={onClickPassword}
              placeholder="******"
              required
            />
            {passwordValido === false && (
              <div className="error_password">{t("error_password")}</div>
            )}
            <div className="ReCAPTCHA">
              <ReCAPTCHA
                ref={captcha}
                sitekey="6LdN-NoeAAAAAErGaW79_lgvfkZ4TumWk2swCykg"
                onChange={onChangeCaptcha}
                hl={i18n.language}
              />
            </div>
            <br />
            {captchaValido === false && (
              <div className="error_captcha">{t("error_captcha")}</div>
            )}
            <button
              className="btn btn-lg btn-success"
              type="submit"
              onClick={handleClick}
              style={{
                backgroundColor: "#198754",
                borderRadius: "5px",
              }}
            >
              {" "}
              {t("login")}{" "}
            </button>
            {credencialesValido === false && (
              <div className="invalid_credentials">
                {t("invalid_credentials")}
              </div>
            )}
            <br />
            <center>
              <Link className="text-dark" to="/ForgotPassword">
                {t("forgot_password")}
              </Link>
            </center>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Login;
