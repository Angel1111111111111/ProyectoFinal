using System;
using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Citas
{
    public class CitasDto
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
