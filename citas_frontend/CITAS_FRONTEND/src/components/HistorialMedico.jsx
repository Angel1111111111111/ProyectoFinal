import React, { useState, useEffect } from 'react';

export const HistorialMedico = ({ consultas }) => {
  const [historialConsultas, setHistorialConsultas] = useState([]);

  useEffect(() => {
    setHistorialConsultas(consultas);
  }, [consultas]);

  return (
    <div>
      <h2>Historial Médico</h2>
      <ul>
        {historialConsultas && historialConsultas.map((consulta, index) => (
          <li key={index}>
            <p>Doctor: {consulta.doctor}</p>
            <p>Paciente: {consulta.paciente}</p>
            <p>Peso: {consulta.peso}</p>
            <p>Altura: {consulta.altura}</p>
            <p>Antecedentes: {consulta.antecedentes}</p>
            <p>Diagnóstico: {consulta.diagnostico}</p>
            <p>Medicamento Recomendado: {consulta.medicamento}</p>
            <p>Motivo de la Consulta: {consulta.motivoConsulta}</p>
            <p>Comentario: {consulta.comentario}</p>
            {/* Agregar más campos según sea necesario */}
          </li>
        ))}
      </ul>
    </div>
  );
};
