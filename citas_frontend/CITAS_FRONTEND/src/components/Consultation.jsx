import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { HistorialMedico } from './HistorialMedico';

export const Consultation = () => {
  const [doctores, setDoctores] = useState([]);
  const [pacientes, setPacientes] = useState([]);
  const [selectedDoctor, setSelectedDoctor] = useState('');
  const [selectedPaciente, setSelectedPaciente] = useState('');
  const [peso, setPeso] = useState('');
  const [altura, setAltura] = useState('');
  const [antecedentes, setAntecedentes] = useState('');
  const [diagnostico, setDiagnostico] = useState('');
  const [medicamento, setMedicamento] = useState('');
  const [motivoConsulta, setMotivoConsulta] = useState('');
  const [comentario, setComentario] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [doctoresResponse, pacientesResponse] = await Promise.all([
          axios.get('API_URL/doctores'),
          axios.get('API_URL/pacientes')
        ]);
        setDoctores(doctoresResponse.data);
        setPacientes(pacientesResponse.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };
    fetchData();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const consultaData = {
      doctor: selectedDoctor,
      paciente: selectedPaciente,
      peso,
      altura,
      antecedentes,
      diagnostico,
      medicamento,
      motivoConsulta,
      comentario
    };
    try {
      // Enviar datos de la consulta a la API
      const response = await axios.post('API_URL/consultas', consultaData);
      console.log('Consulta enviada:', response.data);
      // Guardar datos de la consulta en el historial
      setConsultas([...consultas, response.data]);
      //await guardarEnHistorial(response.data);
      // Lógica para resetear el formulario después de enviar los datos
      // resetForm();
    } catch (error) {
      console.error('Error al enviar la consulta:', error);
    }
  };

  const setConsultas = async (consulta) => {
    try {
      // Guardar datos de la consulta en el historial
      await axios.post('API_URL/historialConsultas', consulta);
      console.log('Consulta guardada en el historial:', consulta);
    } catch (error) {
      console.error('Error al guardar la consulta en el historial:', error);
    }
  };

  return (
    <div>
      <h2>Consulta Médica</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="doctor">Doctor:</label>
          <select id="doctor" value={selectedDoctor} onChange={(e) => setSelectedDoctor(e.target.value)}>
            <option value="">Selecciona un doctor</option>
            {doctores.map((doctor) => (
              <option key={doctor.id} value={doctor.id}>{doctor.nombre}</option>
            ))}
          </select>
        </div>
        <div>
          <label htmlFor="paciente">Paciente:</label>
          <select id="paciente" value={selectedPaciente} onChange={(e) => setSelectedPaciente(e.target.value)}>
            <option value="">Selecciona un paciente</option>
            {pacientes.map((paciente) => (
              <option key={paciente.id} value={paciente.id}>{paciente.nombre}</option>
            ))}
          </select>
        </div>
        <div>
          <label htmlFor="peso">Peso:</label>
          <input type="text" id="peso" value={peso} onChange={(e) => setPeso(e.target.value)} />
        </div>
        <div>
          <label htmlFor="altura">Altura:</label>
          <input type="text" id="altura" value={altura} onChange={(e) => setAltura(e.target.value)} />
        </div>
        <div>
          <label htmlFor="antecedentes">Antecedentes:</label>
          <input type="text" id="antecedentes" value={antecedentes} onChange={(e) => setAntecedentes(e.target.value)} />
        </div>
        <div>
          <label htmlFor="diagnostico">Diagnóstico:</label>
          <input type="text" id="diagnostico" value={diagnostico} onChange={(e) => setDiagnostico(e.target.value)} />
        </div>
        <div>
          <label htmlFor="medicamento">Medicamento Recomendado:</label>
          <input type="text" id="medicamento" value={medicamento} onChange={(e) => setMedicamento(e.target.value)} />
        </div>
        <div>
          <label htmlFor="motivoConsulta">Motivo de la Consulta:</label>
          <input type="text" id="motivoConsulta" value={motivoConsulta} onChange={(e) => setMotivoConsulta(e.target.value)} />
        </div>
        <div>
          <label htmlFor="comentario">Comentario:</label>
          <input type="text" id="comentario" value={comentario} onChange={(e) => setComentario(e.target.value)} />
        </div>
        <button type="submit">Enviar Consulta</button>
      </form>
      <HistorialMedico consultas={consultas || []} />
    </div>
  );
};
