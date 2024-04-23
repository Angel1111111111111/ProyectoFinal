import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

export const Nutritionist = () => {
  const [nutritionists, setNutritionists] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchNutritionists = async () => {
      try {
        const response = await axios.get('API_URL/nutritionists');
        setNutritionists(response.data);
      } catch (error) {
        console.error('Error fetching nutritionists:', error);
      }
    };

    fetchNutritionists();
  }, []);

  const handleScheduleAppointment = (nutritionistId, dayOfWeek, startTime, endTime) => {
    const appointmentData = {
      nutritionistId,
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
      <h1>Lista de Nutricionistas</h1>
      <ul>
        {nutritionists.map(nutritionist => (
          <li key={nutritionist.id}>
            <h2>{nutritionist.name}</h2>
            <p>Especialidad: {nutritionist.specialty}</p>
            <p>Turno: {nutritionist.shift}</p>
            <p>Día de la semana: {nutritionist.dayOfWeek}</p>
            <p>Hora de inicio: {nutritionist.startTime}</p>
            <p>Hora de fin: {nutritionist.endTime}</p>
            <button onClick={() => handleScheduleAppointment(nutritionist.id, nutritionist.dayOfWeek, nutritionist.startTime, nutritionist.endTime)}>
              Agendar cita
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
