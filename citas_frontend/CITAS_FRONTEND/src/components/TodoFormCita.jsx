import React, { useState, useEffect } from 'react';
import { NavigationBar } from './NavigationBar';

export const TodoFormCita = ({ onCitaAgendada, citaEditar }) => {
  const [formData, setFormData] = useState({
    fecha: '',
    hora: '',
    doctor_id: '',
    motivo_cita: '',
    paciente_id: '',
    estado: 'Pendiente',
  });

  useEffect(() => {
    if (citaEditar) {
      setFormData({
        fecha: citaEditar.fecha,
        hora: citaEditar.hora,
        doctor_id: citaEditar.doctor_id,
        motivo_cita: citaEditar.motivo_cita,
        paciente_id: citaEditar.paciente_id,
        estado: citaEditar.estado,
      });
    }
  }, [citaEditar]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onCitaAgendada(formData); // Envía la cita agendada al componente padre
    setFormData({
      fecha: '',
      hora: '',
      doctor_id: '',
      motivo_cita: '',
      paciente_id: '',
      estado: 'Pendiente',
    });
  };

  return (
    <div>
      <NavigationBar />
      <div className="flex justify-center items-center h-screen bg-gray-100">
        <form onSubmit={handleSubmit} className="bg-gray-100 p-8 rounded-lg shadow-lg">
          <h2 className="text-gray-800 text-2xl font-bold mb-4">Agendar Cita</h2>

          <label htmlFor="fecha" className="block text-gray-800 mb-2">Fecha:</label>
          <input
            type="date"
            id="fecha"
            name="fecha"
            value={formData.fecha}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />

          <label htmlFor="hora" className="block text-gray-800 mb-2">Hora:</label>
          <input
            type="time"
            id="hora"
            name="hora"
            value={formData.hora}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />

          <label htmlFor="doctor_id" className="block text-gray-800 mb-2">Doctor:</label>
          <input
            name="doctor_id"
            id="doctor_id"
            value={formData.doctor_id}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />

          <label htmlFor="motivo_cita" className="block text-gray-800 mb-2">Motivo de la Cita:</label>
          <input
            name="motivo_cita"
            id="motivo_cita"
            value={formData.motivo_cita}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />

          <label htmlFor="paciente_id" className="block text-gray-800 mb-2">Paciente:</label>
          <input
            name="paciente_id"
            id="paciente_id"
            value={formData.paciente_id}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />
          <label htmlFor="estado" className="block text-gray-800 mb-2">Estado:</label>
          <input
            type="text"
            id="estado"
            name="estado"
            value={formData.estado}
            onChange={handleChange}
            className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          />

          <button
            type="submit"
            className="w-full bg-gray-700 text-white py-2 rounded-lg hover:bg-gray-800 focus:outline-none focus:ring focus:border-gray-600"
          >
            {citaEditar ? 'Reagendar Cita' : 'Agendar Cita'}
          </button>
        </form>
      </div>
    </div>
  );
};
