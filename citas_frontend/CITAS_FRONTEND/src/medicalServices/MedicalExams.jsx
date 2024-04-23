import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

export const MedicalExams = () => {
  const [medicalExams, setMedicalExams] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    // Llamar a la API para obtener la lista de dermatólogos
    const fetchDermatologists = async () => {
      try {
        const response = await axios.get('API_URL/dermatologists');
        setMedicalExams(response.data);
      } catch (error) {
        console.error('Error fetching dermatologists:', error);
      }
    };

    fetchDermatologists();
  }, []);

  const handleScheduleAppointment = (medicalExamsId, dayOfWeek, startTime, endTime) => {
    // Aquí deberías enviar los datos de la cita a la base de datos
    // y luego redirigir al usuario al formulario de citas
    const appointmentData = {
      medicalExamsId: medicalExamsId,
      dayOfWeek,
      startTime,
      endTime,
    };

    // Lógica para enviar los datos de la cita a la base de datos
    // axios.post('API_URL/appointments', appointmentData)

    // Redirección al formulario de citas
    navigate('/todoForm');
  };

  return (
    <div>
      <h1>Lista de Doctores para atenderte en tus Examenes Medicos</h1>
      <ul>
        {medicalExams.map(dermatologist => (
          <li key={dermatologist.id}>
            <h2>{dermatologist.name}</h2>
            <p>Especialidad: {dermatologist.specialty}</p>
            <p>Turno: {dermatologist.shift}</p>
            <p>Día de la semana: {dermatologist.dayOfWeek}</p>
            <p>Hora de inicio: {dermatologist.startTime}</p>
            <p>Hora de fin: {dermatologist.endTime}</p>
            <button onClick={() => handleScheduleAppointment(dermatologist.id, dermatologist.dayOfWeek, dermatologist.startTime, dermatologist.endTime)}>
              Agendar cita
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
