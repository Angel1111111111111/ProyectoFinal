import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

export const Pediatrician = () => {
  const [pediatricians, setPediatricians] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchPediatricians = async () => {
      try {
        const response = await axios.get('API_URL/pediatricians');
        setPediatricians(response.data);
      } catch (error) {
        console.error('Error fetching pediatricians:', error);
      }
    };

    fetchPediatricians();
  }, []);

  const handleScheduleAppointment = (pediatricianId, dayOfWeek, startTime, endTime) => {
    const appointmentData = {
      pediatricianId,
      dayOfWeek,
      startTime,
      endTime,
    };

    // Aquí deberías enviar los datos de la cita a la base de datos
    // axios.post('API_URL/appointments', appointmentData)

    // Redirección al formulario de citas
    navigate('/todoForm');
  };

  return (
    <div>
      <h1>Lista de Pediatras</h1>
      <ul>
        {pediatricians.map(pediatrician => (
          <li key={pediatrician.id}>
            <h2>{pediatrician.name}</h2>
            <p>Especialidad: {pediatrician.specialty}</p>
            <p>Turno: {pediatrician.shift}</p>
            <p>Día de la semana: {pediatrician.dayOfWeek}</p>
            <p>Hora de inicio: {pediatrician.startTime}</p>
            <p>Hora de fin: {pediatrician.endTime}</p>
            <button onClick={() => handleScheduleAppointment(pediatrician.id, pediatrician.dayOfWeek, pediatrician.startTime, pediatrician.endTime)}>
              Agendar cita
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
