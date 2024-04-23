using Microsoft.AspNetCore.Mvc;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Turnos;
using System.Threading.Tasks;

namespace Citas_Backend.Controllers
{
    [Route("api/turnos")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTurnos()
        {
            var response = await _turnoService.GetTurnosAsync();
            if (response.Status)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurno(TurnoCreateDto turnoDto)
        {
            var response = await _turnoService.CreateTurnoAsync(turnoDto);
            if (response.Status)
            {
                return CreatedAtAction(nameof(GetTurnos), new { id = response.Data.Id }, response.Data);
            }
            else
            {
                return StatusCode(response.StatusCode, response.Message);
            }
        }
    }
}
