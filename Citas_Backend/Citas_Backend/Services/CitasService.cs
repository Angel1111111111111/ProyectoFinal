using AutoMapper;
using Citas_Backend.Database;
using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citas_Backend.Services
{
    public class CitasService : ICitasService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CitasService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CitasDto>>> GetListAsync(string searchTerm = "")
        {
            var citasEntity = await _context.Citas
                .Where(c => c.DoctorId.ToString().Contains(searchTerm))
                .ToListAsync();

            var citasDto = _mapper.Map<List<CitasDto>>(citasEntity);

            return new ResponseDto<List<CitasDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Datos obtenidos correctamente",
                Data = citasDto
            };
        }

        public async Task<ResponseDto<CitasDto>> GetOneByIdAsync(string idString)
        {
            if (!Guid.TryParse(idString, out Guid id))
            {
                return new ResponseDto<CitasDto>
                {
                    Status = false,
                    StatusCode = 400,
                    Message = "El formato del Id no es válido"
                };
            }

            var citaEntity = await _context.Citas.SingleOrDefaultAsync(c => c.Id == id);

            if (citaEntity == null)
            {
                return new ResponseDto<CitasDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"Cita con Id {id} no encontrada"
                };
            }

            var citaDto = _mapper.Map<CitasDto>(citaEntity);

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Cita con Id {id} encontrada",
                Data = citaDto
            };
        }

        public async Task<ResponseDto<CitasDto>> CreateAsync(CitasDto model)
        {
            var citaEntity = _mapper.Map<CitasEntity>(model);

            _context.Citas.Add(citaEntity);
            await _context.SaveChangesAsync();

            var citaDto = _mapper.Map<CitasDto>(citaEntity);

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Cita creada correctamente",
                Data = model
            };
        }

        public async Task<ResponseDto<CitasDto>> UpdateAsync(CitasDto dto, Guid id)
        {
            var citaEntity = await _context.Citas.SingleOrDefaultAsync(c => c.Id == id);

            if (citaEntity == null)
            {
                return new ResponseDto<CitasDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"Cita con Id {id} no encontrada"
                };
            }

            _mapper.Map(dto, citaEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Cita con Id {id} actualizada correctamente",
                Data = dto
            };
        }

        public async Task<ResponseDto<CitasDto>> DeleteAsync(Guid id)
        {
            var citaEntity = await _context.Citas.SingleOrDefaultAsync(c => c.Id == id);

            if (citaEntity == null)
            {
                return new ResponseDto<CitasDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"Cita con Id {id} no encontrada"
                };
            }

            _context.Citas.Remove(citaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<CitasDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $"Cita con Id {id} eliminada correctamente"
            };
        }
    }
}
