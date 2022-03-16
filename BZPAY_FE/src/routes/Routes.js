import React from "react";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Login from '../pages/auth/Login';

function App() {
    return (
        <Router>
            <Routes>    
                <Route exact path="/" element={<Login />} />
                <Route exact path="/Home" element={<Home />} />
            </Routes>
        </Router>
    );
}

export default App;