using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Citas_Backend.Dtos.Consultas;

namespace Citas_Backend.Services
{
    public class ConsultaService : IConsultasService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConsultaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ConsultaDto>> CreateConsultaAsync(ConsultaCreateDto consultaCreateDto)
        {
            try
            {
                var consultaEntity = _mapper.Map<ConsultaEntity>(consultaCreateDto);
                _context.Consultas.Add(consultaEntity);
                await _context.SaveChangesAsync();

                var consultaDto = _mapper.Map<ConsultaDto>(consultaEntity);

                return new ResponseDto<ConsultaDto>
                {
                    Status = true,
                    StatusCode = 201,
                    Message = "Consulta creada correctamente",
                    Data = consultaDto
                };
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones de base de datos específicas aquí
                return new ResponseDto<ConsultaDto>
                {
                    Status = false,
                    StatusCode = 500,
                    Message = "Error al crear la consulta: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones aquí
                return new ResponseDto<ConsultaDto>
                {
                    Status = false,
                    StatusCode = 500,
                    Message = "Error al crear la consulta: " + ex.Message
                };
            }

        }
        public async Task<ResponseDto<List<ConsultaDto>>> GetConsultasAsync()
        {
            try
            {
                var consultasEntity = await _context.Consultas.ToListAsync();
                var consultasDto = _mapper.Map<List<ConsultaDto>>(consultasEntity);

                return new ResponseDto<List<ConsultaDto>>
                {
                    Status = true,
                    StatusCode = 200,
                    Message = "Consultas obtenidas correctamente",
                    Data = consultasDto
                };
            }
            catch (Exception ex)
            {
                return HandleErrorResponse($"Error al obtener las consultas: {ex.Message}");
            }
        }

        private ResponseDto<List<ConsultaDto>> HandleErrorResponse(string errorMessage)
        {
            return new ResponseDto<List<ConsultaDto>>
            {
                Status = false,
                StatusCode = 500,
                Message = errorMessage
            };
        }
    }
}
