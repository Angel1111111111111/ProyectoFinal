﻿using Citas_Backend.Database;
using Citas_Backend.Dtos.Pacientes;
using Citas_Backend.Dtos;
using Citas_Backend.Entities;
using Citas_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Citas_Backend.Dtos.pacientes;

namespace Citas_Backend.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PacienteService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PacienteDto>> ObtenerPacientePorCorreoElectronicoAsync(string correoElectronico)
        {
            var pacienteEntity = await _context.Pacientes.FirstOrDefaultAsync(p => p.CorreoElectronico == correoElectronico);

            if (pacienteEntity == null)
            {
                return new ResponseDto<PacienteDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = "Paciente no encontrado",
                };
            }

            var pacienteDto = _mapper.Map<PacienteDto>(pacienteEntity);

            return new ResponseDto<PacienteDto>
            {
                Status = true,
                StatusCode = 200,
                Message = "Paciente encontrado",
                Data = pacienteDto
            };
        }

        public async Task<ResponseDto<PacienteDto>> RegistrarPacienteAsync(PacienteCreateDto pacienteDto)
        {
            var pacienteEntity = _mapper.Map<PacienteEntity>(pacienteDto);
            pacienteEntity.Id = Guid.NewGuid(); // Generar nuevo ID

            _context.Pacientes.Add(pacienteEntity);
            await _context.SaveChangesAsync();

            var pacienteDtoResult = _mapper.Map<PacienteDto>(pacienteEntity);

            return new ResponseDto<PacienteDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Paciente registrado correctamente",
                Data = pacienteDtoResult
            };
        }
    }
}
