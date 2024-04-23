import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { constants } from '../helpers/constants';

export const Dermatologist = () => {
  const [doctorInfo, setDoctorInfo] = useState([]);
  const { API_URL } = constants();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [doctorsResponse, turnosResponse] = await Promise.all([
          axios.get(`${API_URL}/doctores`),
          axios.get(`${API_URL}/doctores/turnos`)
        ]);

        const turnos = turnosResponse.data.reduce((acc, turno) => {
          acc[turno.id] = turno;
          return acc;
        }, {});

        const doctorsWithTurnos = doctorsResponse.data.map(doctor => ({
          ...doctor,
          turno: turnos[doctor.turnoId]
        }));

        setDoctorInfo(doctorsWithTurnos);
      } catch (error) {
        console.error('Error al obtener datos:', error);
      }
    };

    fetchData();
  }, [API_URL]);

  return (
    <div>
      <h1 className="text-3xl font-bold mb-6 text-center p-5">Lista de Doctores y Turnos</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 px-6">
        {doctorInfo.map((doctor, index) => (
          <div key={index} className="bg-white p-4 rounded-lg shadow-md">
            <h2 className="text-xl font-semibold">{doctor.nombre}</h2>
            {doctor.turno && (
              <div>
                <p className="font-semibold">Turno:</p>
                <p>Hora de inicio: {doctor.turno.horaInicio}</p>
                <p>Hora de fin: {doctor.turno.horaFin}</p>
              </div>
            )}
            <Link
              to={`/todoForm?doctor=${encodeURIComponent(doctor.nombre)}`}
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mt-2 inline-block"
            >
              Agendar Cita - {doctor.nombre}
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
};
