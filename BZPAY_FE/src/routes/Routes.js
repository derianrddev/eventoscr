import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";
import Home from "../pages/Home";
import Login from "../pages/auth/Login";
import ForgotPassword from "../pages/auth/ForgotPassword";
import RecoverPassword from "../pages/auth/RecoverPassword";
import { MasterPage } from "../components/MasterPage";
import { Events } from "../pages/Events";
import { CreateTickets } from "../pages/CreateTickets";
import { AvailableEvents } from "../pages/AvailableEvents";
import { setUser } from "../store/auth/authSlice";
import { BuyTickets } from "../pages/BuyTickets";

function App() {
  const dispatch = useDispatch();

  useEffect(() => {
    // Consultar el localStorage al cargar la página
    const userData = localStorage.getItem("user");

    if (userData) {
      // Si hay datos en el localStorage, actualizar el estado con ellos
      dispatch(setUser(JSON.parse(userData)));
    }
  }, []);

  return (
    <Router>
      <MasterPage>
        <Routes>
          <Route exact path="/" element={<Login />} />
          <Route exact path="/ForgotPassword" element={<ForgotPassword />} />
          <Route exact path="/RecoverPassword" element={<RecoverPassword />} />
          <Route exact path="/Home" element={<Home />} />
          <Route exact path="/Events" element={<Events />} />
          <Route
            exact
            path="/CreateTickets/:eventId"
            element={<CreateTickets />}
          />
          <Route exact path="/AvailableEvents" element={<AvailableEvents />} />
          <Route
            exact
            path="/BuyTickets/:eventId"
            element={<BuyTickets />}
          />
        </Routes>
      </MasterPage>
    </Router>
  );
}

export default App;
