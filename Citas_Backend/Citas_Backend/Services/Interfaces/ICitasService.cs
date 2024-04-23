using Citas_Backend.Dtos;
using Citas_Backend.Dtos.Citas;

namespace Citas_Backend.Services.Interfaces
{
    public interface ICitasService
    {
        Task<ResponseDto<CitasDto>> CreateAsync(CitasDto model);
        Task<ResponseDto<CitasDto>> DeleteAsync(Guid id);
        Task<ResponseDto<List<CitasDto>>> GetListAsync(string searchTerm = "");
        Task<ResponseDto<CitasDto>> GetOneByIdAsync(string idString);
        Task<ResponseDto<CitasDto>> UpdateAsync(CitasDto dto, Guid id);
    }
}
