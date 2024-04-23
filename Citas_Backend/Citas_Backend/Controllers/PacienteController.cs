using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Dtos.Pacientes;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.pacientes;

namespace Citas_Backend.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDto<PacienteDto>>> Register(PacienteCreateDto pacienteDto)
        {
            var response = await _pacienteService.RegistrarPacienteAsync(pacienteDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{correoElectronico}")]
        public async Task<ActionResult<ResponseDto<PacienteDto>>> GetPaciente(string correoElectronico)
        {
            var response = await _pacienteService.ObtenerPacientePorCorreoElectronicoAsync(correoElectronico);
            return StatusCode(response.StatusCode, response);
        }
    }
}
