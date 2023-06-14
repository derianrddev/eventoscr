import { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";
import { MasterPage } from "../components/MasterPage";
import { setUser } from "../store/auth/authSlice";
import {
  AvailableEvents,
  BuyTickets,
  CreateTickets,
  Events,
  ForgotPassword,
  Home,
  Login,
  RecoverPassword,
  TicketDelivery,
} from "../pages";

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
          <Route exact path="/BuyTickets/:eventId" element={<BuyTickets />} />
          <Route exact path="/TicketDelivery" element={<TicketDelivery />} />
        </Routes>
      </MasterPage>
    </Router>
  );
}

export default App;
