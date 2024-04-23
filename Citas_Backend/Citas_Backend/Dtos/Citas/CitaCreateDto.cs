using System.ComponentModel.DataAnnotations;

namespace Citas_Backend.Dtos.Citas
{
    public class CitaCreateDto
    {
        [Required]
        public Guid PacienteId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Display(Name = "fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }
        
        [Display(Name = "estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Estado { get; set; }
    }
}
