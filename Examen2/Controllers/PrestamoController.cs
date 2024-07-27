using Examen2.Dtos.Clientes;
using Examen2.Dtos.Common;
using Examen2.Dtos.Prestamos;
using Examen2.Services;
using Examen2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen2.Controllers
{
    [Route("api/prestamos")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public LoansController(IPrestamoService prestamoService)
        {
            this._prestamoService = prestamoService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<PrestamoDto>>> Create(CreatePrestamoDto dto)
        {
            var response = await _prestamoService.CrearPrestamoAsync(dto);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
            });
        }
    }
}
