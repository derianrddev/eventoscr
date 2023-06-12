import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Login from '../pages/auth/Login';
import ForgotPassword from '../pages/auth/ForgotPassword';
import RecoverPassword from '../pages/auth/RecoverPassword';
import { MasterPage } from "../components/MasterPage";
import { Events } from "../pages/Events";
import { CreateTickets } from "../pages/CreateTickets";

function App() {
    return (
        <Router>
            <MasterPage>
                <Routes>    
                    <Route exact path="/" element={<Login />} />
                    <Route exact path="/ForgotPassword" element={<ForgotPassword />} />
                    <Route exact path="/RecoverPassword" element={<RecoverPassword />} />
                    <Route exact path="/Home" element={<Home />} />
                    <Route exact path="/Events" element={<Events />} />
                    <Route exact path="/CreateTickets/:eventId" element={<CreateTickets />} />
                </Routes>
            </MasterPage>
        </Router>
    );
}

export default App;