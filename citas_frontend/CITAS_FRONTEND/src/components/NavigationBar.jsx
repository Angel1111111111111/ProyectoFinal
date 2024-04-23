import React, { useState } from 'react';
import { Link } from 'react-router-dom';

export const NavigationBar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false); // Estado para controlar si el usuario está autenticado

  // Función para manejar el cierre de sesión
  const handleLogout = () => {
    // Lógica para cerrar sesión
    setIsLoggedIn(false); // Actualiza el estado para indicar que el usuario ha cerrado sesión
  };

  return (
    <nav className="flex items-center justify-between flex-wrap bg-gray-500 p-4">
      <div className="flex items-center flex-shrink-0 text-white mr-6">
        <Link to="/">
          <span className="font-semibold text-xl tracking-tight">
            Logo
          </span>
        </Link>
      </div>
      <div>
        <Link
          to="/"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Inicio
        </Link>
        <Link
          to="/todoForm"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Agenda cita
        </Link>
        <Link
          to="/historialMedico"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Historial médico
        </Link>
        {/* Condición para mostrar el enlace al perfil */}
        {isLoggedIn && (
          <Link
            to="/profile"
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
          >
            Perfil
          </Link>
        )}
        {/* Enlace de inicio de sesión o cierre de sesión según el estado del usuario */}
        {isLoggedIn ? (
          <button
            onClick={handleLogout}
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
          >
            Cerrar sesión
          </button>
        ) : (
          <Link
            to="/login"
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
          >
            Iniciar sesión
          </Link>
        )}
      </div>
    </nav>
  );
};
