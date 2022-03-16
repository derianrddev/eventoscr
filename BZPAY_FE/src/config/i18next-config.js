import i18n from "i18next";
import { initReactI18next } from 'react-i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import Backend from 'i18next-http-backend';

i18n      //.use(Backend)
    .use(LanguageDetector)
    .use(initReactI18next)
    .init({
        //lng:'en',
        fallbacklng: 'es',
        resources: {
            es: {
                translation: {
                    welcome: 'Hola. Bienvenido al NuevoUI {{ username }} usted ha sido exitosamente logueado y se encuentra en la página de home',
                    user: 'Usuario',
                    password:'Contraseña',
                    login: 'Iniciar Sesión',
                    actual_language: 'Lenguaje Actual',
                    close_session: 'Cerrar Sesión',
                    spanish: 'Español',
                    english: 'Inglés',
                    started_session: 'Sesión Iniciada',
                    error_user: 'Por favor digite un usuario válido',
                    error_password: 'Por favor digite un password válido',
                    error_captcha: 'Por favor seleccione el captcha',
                    invalid_credentials: 'Credenciales Inválidas'
                }
            },
            en: {
                translation: {
                    welcome: 'Hi.Welcome to the NewUI {{ username }} you have been successfully logged in and you are on the home page',
                    user: 'User',
                    password:'Password',
                    login: 'Login',
                    actual_language: 'Actual Language',
                    close_session: 'Close Session',
                    spanish: 'Spanish',
                    english: 'English',
                    started_session: 'Started Session',
                    error_user: 'please enter a valid username',
                    error_password: 'please enter a valid password',
                    error_captcha: 'Please check the captcha',
                    invalid_credentials:'Invalid credentials'
                }
            }

        }
    })

