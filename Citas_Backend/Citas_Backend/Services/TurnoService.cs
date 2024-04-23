using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Turnos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citas_Backend.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TurnoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<TurnoDto>>> GetTurnosAsync()
        {
            var turnos = await _context.Turnos.ToListAsync();
            var turnoDtos = _mapper.Map<List<TurnoDto>>(turnos);

            return new ResponseDto<List<TurnoDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Lista de turnos obtenida correctamente",
                Data = turnoDtos
            };
        }

        public async Task<ResponseDto<TurnoDto>> CreateTurnoAsync(TurnoCreateDto turnoDto)
        {
            try
            {
                var turnoEntity = _mapper.Map<TurnoEntity>(turnoDto);

                _context.Turnos.Add(turnoEntity);
                await _context.SaveChangesAsync();


                return new ResponseDto<TurnoDto>
                {
                    Status = true,
                    StatusCode = 201,
                    Message = "Turno creado correctamente",

                };
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la creación del turno
                return new ResponseDto<TurnoDto>
                {
                    Status = false,
                    StatusCode = 500,
                    Message = $"Error al crear el turno: {ex.Message}"
                };
            }
        }

        // Implementa otros métodos según sea necesario, como obtener, actualizar o eliminar turnos.
    }
}
