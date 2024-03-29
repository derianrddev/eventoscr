import React from "react";
import ReactDOM from "react-dom";
import { Provider } from 'react-redux'
import Routes from "./routes/Routes";
import "./config/i18next-config";
import "@fontsource/poppins";
import "./css/index.css";
import { store } from "./store";

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <Routes />
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);
