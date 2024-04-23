import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

export const Psychologist = () => {
  const [psychologists, setPsychologists] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchPsychologists = async () => {
      try {
        const response = await axios.get('API_URL/psychologists');
        setPsychologists(response.data);
      } catch (error) {
        console.error('Error fetching psychologists:', error);
      }
    };

    fetchPsychologists();
  }, []);

  const handleScheduleAppointment = (psychologistId, dayOfWeek, startTime, endTime) => {
    const appointmentData = {
      psychologistId,
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
      <h1>Lista de Psicólogos</h1>
      <ul>
        {psychologists.map(psychologist => (
          <li key={psychologist.id}>
            <h2>{psychologist.name}</h2>
            <p>Especialidad: {psychologist.specialty}</p>
            <p>Turno: {psychologist.shift}</p>
            <p>Día de la semana: {psychologist.dayOfWeek}</p>
            <p>Hora de inicio: {psychologist.startTime}</p>
            <p>Hora de fin: {psychologist.endTime}</p>
            <button onClick={() => handleScheduleAppointment(psychologist.id, psychologist.dayOfWeek, psychologist.startTime, psychologist.endTime)}>
              Agendar cita
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
