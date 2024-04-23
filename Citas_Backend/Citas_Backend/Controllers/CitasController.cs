using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Citas_Backend.Services;
using Citas_Backend.Services.Interfaces;
using Citas_Backend.Dtos.Citas;

namespace Citas_Backend.Controllers
{
    [Route("api/citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitasService _citasService;

        public CitasController(ICitasService citasService)
        {
            _citasService = citasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasDto>>> GetCitas()
        {
            var response = await _citasService.GetListAsync();

            if (!response.Status)
            {
                return StatusCode(response.StatusCode, response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitasDto>> GetCita(Guid id)
        {
            var response = await _citasService.GetOneByIdAsync(id.ToString());

            if (!response.Status)
            {
                return StatusCode(response.StatusCode, response.Message);
            }

            return Ok(response.Data);
        }


        [HttpPost]
        public async Task<ActionResult<CitasDto>> PostCita(CitasDto citaDto)
        {
            var response = await _citasService.CreateAsync(citaDto);

            if (!response.Status)
            {
                return StatusCode(response.StatusCode, response.Message);
            }

            return CreatedAtAction(nameof(GetCita), new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(Guid id, CitasDto citaDto)
        {
            if (id != citaDto.Id)
            {
                return BadRequest("El ID de la cita en el cuerpo de la solicitud no coincide con el ID de la ruta.");
            }

            var response = await _citasService.UpdateAsync(citaDto, id);

            if (!response.Status)
            {
                return StatusCode(response.StatusCode, response.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(Guid id)
        {
            var response = await _citasService.DeleteAsync(id);

            if (!response.Status)
            {
                return StatusCode(response.StatusCode, response.Message);
            }

            return NoContent();
        }
    }
}
