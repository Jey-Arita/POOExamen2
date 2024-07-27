using Examen2.Dtos.Clientes;
using Examen2.Dtos.Common;
using Examen2.Dtos.Prestamos;

namespace Examen2.Services.Interfaces
{
    public interface IPrestamoService
    {
        Task<ResponseDto<PrestamoDto>> CrearPrestamoAsync(CreatePrestamoDto dto);
    }
}
