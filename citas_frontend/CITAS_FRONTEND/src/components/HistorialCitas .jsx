import React, { useState } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';

//import { useHistory } from 'react-router-dom';

export const HistorialCitas = () => {
  const [citas, setCitas] = useState([]);

  const agregarCita = (nuevaCita) => {
    setCitas([...citas, nuevaCita]);
  };

  const reagendarCita = (idCita, nuevaFecha, nuevaHora) => {
    // Aquí podrías hacer lo que necesites con los datos de la cita para editarla
    // En este ejemplo, simplemente redirigimos al usuario a TodoFormCita
    history.push('/todoformcita', { citaEditar: { id: idCita, fecha: nuevaFecha, hora: nuevaHora } });
  };

  const cancelarCita = (idCita) => {
    const citasFiltradas = citas.filter(cita => cita.id !== idCita);
    setCitas(citasFiltradas);
  };

  const handleConsulta = (idCita, motivoCita) => {
    // Redireccionar al usuario a la página de consulta con el motivo de la cita
    history.push('/consulta', { motivoConsulta: motivoCita });
  };

  return (
    <div>
      <h2>Historial de Citas</h2>
      <ul>
        {citas.map((cita) => (
          <li key={cita.id}>
            <p>Paciente: {cita.paciente}</p>
            <p>Fecha: {cita.fecha}</p>
            <p>Hora: {cita.hora}</p>
            <p>Doctor: {cita.doctor}</p>
            <p>Motivo: {cita.motivo}</p>
            <p>Estado: {cita.estado}</p>
            <button onClick={() => cancelarCita(cita.id)}>Cancelar cita</button>
            <button onClick={() => reagendarCita(cita.id, nuevaFecha, nuevaHora)}>Reagendar cita</button>
            <button onClick={() => handleConsulta(cita.id, cita.motivo)}>Hacer consulta</button>
          </li>
        ))}
      </ul>
    </div>
  );
};
