import { useNavigate } from "react-router-dom";
import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/Home.css";
import Cookies from "universal-cookie";
import { useTranslation } from "react-i18next";

function Home() {
  const utf8 = require("utf8");
  const cookies = new Cookies();
  const navigate = useNavigate();
  const { t, i18n } = useTranslation();

  function changeToEnglish() {
    i18n.changeLanguage("en");
  }

  function changeToSpanish() {
    i18n.changeLanguage("es");
  }

  useEffect(() => {
        if (!cookies.get('username')) {
            navigate('/');
        }
    }, []);

  return (
    <>
      {/* Banner destacado */}
      <section
        className="banner"
        style={{
          backgroundImage:
            "url('https://images.pexels.com/photos/2747449/pexels-photo-2747449.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1')",
          backgroundSize: "cover",
          backgroundPosition: "center",
          padding: "130px 0",
        }}
      >
        <div className="container text-center">
          <div className="row">
            <div className="col-md-6 mx-auto">
              <h1 className="text-light display-4">Bienvenido a EventosCR</h1>
              <p className="text-light">
                Reserva entradas para los mejores eventos en Costa Rica
              </p>
              <button
                className="btn btn-success btn-lg"
                href="#"
                style={{
                  backgroundColor: "#198754",
                  borderRadius: "5px",
                }}
              >
                Explorar Eventos
              </button>
            </div>
          </div>
        </div>
      </section>

      {/* Eventos destacados */}
      <section className="eventos-destacados mt-4">
        <div className="container">
          <h2 className="text-center">Eventos Destacados</h2>
          <div className="row text-center">
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <h5 className="card-title">Nombre del Evento 1</h5>
                  <p className="card-text">Breve descripción del evento 1.</p>
                  <p className="card-text">Fecha: 01 de enero de 2024</p>
                  <p className="card-text">Ubicación: Ciudad, Costa Rica</p>
                  <button
                    href="#"
                    className="btn btn-primary"
                    style={{
                      backgroundColor: "#0d6efd",
                      borderRadius: "5px",
                    }}
                  >
                    Más detalles
                  </button>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <h5 className="card-title">Nombre del Evento 2</h5>
                  <p className="card-text">Breve descripción del evento 2.</p>
                  <p className="card-text">Fecha: 15 de febrero de 2024</p>
                  <p className="card-text">Ubicación: Playa, Costa Rica</p>
                  <button
                    href="#"
                    className="btn btn-primary"
                    style={{
                      backgroundColor: "#0d6efd",
                      borderRadius: "5px",
                    }}
                  >
                    Más detalles
                  </button>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <h5 className="card-title">Nombre del Evento 3</h5>
                  <p className="card-text">Breve descripción del evento 3.</p>
                  <p className="card-text">Fecha: 10 de marzo de 2024</p>
                  <p className="card-text">Ubicación: Montaña, Costa Rica</p>
                  <button
                    href="#"
                    className="btn btn-primary"
                    style={{
                      backgroundColor: "#0d6efd",
                      borderRadius: "5px",
                    }}
                  >
                    Más detalles
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Categorías de eventos */}
      <section className="categorias-eventos">
        <div className="container">
          <h2 className="text-center">Categorías de Eventos</h2>
          <div className="row">
            <div className="col-md-4">
              <div className="card mt-3 p-0">
                <img
                  src="https://www.eventindustryshow.com/img/blog/Eventos-y-Exposiciones-53.jpg"
                  className="card-img-top"
                  alt="Música"
                  style={{ height: "250px" }}
                />
                <div className="card-body">
                  <h5 className="card-title">Música</h5>
                  <p className="card-text">
                    Descubre los mejores conciertos y festivales de música en
                    Costa Rica. Disfruta de tus artistas favoritos en vivo y
                    vive experiencias inolvidables.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3 p-0">
                <img
                  src="https://www.protocoloimep.com/app/uploads/2017/06/teatro-event-manager.png"
                  className="card-img-top"
                  alt="Teatro"
                  style={{ height: "250px" }}
                />
                <div className="card-body">
                  <h5 className="card-title">Teatro</h5>
                  <p className="card-text">
                    Sumérgete en el mundo del teatro y disfruta de las mejores
                    obras y espectáculos. Descubre la magia de las actuaciones
                    en vivo y vive momentos emocionantes.
                  </p>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3 p-0">
                <img
                  src="https://d1qqtien6gys07.cloudfront.net/wp-content/uploads/2022/01/16365715142561.jpeg"
                  className="card-img-top"
                  alt="Deportes"
                  style={{ height: "250px" }}
                />
                <div className="card-body">
                  <h5 className="card-title">Deportes</h5>
                  <p className="card-text">
                    Vive la pasión del deporte en Costa Rica. Descubre los
                    eventos deportivos más emocionantes, desde partidos de
                    fútbol hasta competiciones de surf y mucho más.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Testimonios de clientes */}
      <section className="testimonios">
        <div className="container">
          <h2 className="text-center">Testimonios de Clientes</h2>
          <div className="row">
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <blockquote className="blockquote">
                    <p className="card-text fs-5">
                      ¡Increíble experiencia! Disfruté de un concierto
                      inolvidable gracias a EventosCR. La reserva de entradas
                      fue rápida y sencilla, y el evento superó todas mis
                      expectativas.
                    </p>
                    <footer className="blockquote-footer">Sara G.</footer>
                  </blockquote>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <blockquote className="blockquote">
                    <p className="card-text fs-5">
                      Nunca había asistido a un evento deportivo tan emocionante
                      como el que reservé a través de EventosCR. La atención al
                      cliente fue excepcional, y sin duda volveré a utilizar
                      este servicio para futuros eventos.
                    </p>
                    <footer className="blockquote-footer">Juan M.</footer>
                  </blockquote>
                </div>
              </div>
            </div>
            <div className="col-md-4">
              <div className="card mt-3">
                <div className="card-body">
                  <blockquote className="blockquote">
                    <p className="card-text fs-5">
                      Gracias a EventosCR, pude disfrutar de una obra de teatro
                      maravillosa. La plataforma es fácil de usar y me permitió
                      encontrar el evento perfecto. ¡Recomiendo EventosCR a
                      todos los amantes del teatro!
                    </p>
                    <footer className="blockquote-footer">María R.</footer>
                  </blockquote>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}

export default Home;
