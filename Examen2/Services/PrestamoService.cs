using AutoMapper;
using Examen2.Database;
using Examen2.Database.Entities;
using Examen2.Dtos.Clientes;
using Examen2.Dtos.Common;
using Examen2.Dtos.InfoPrestamos;
using Examen2.Dtos.Prestamos;
using Examen2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PrestamoService> _logger;

        public PrestamoService(ExamenContext context, IMapper mapper, ILogger<PrestamoService> logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<ResponseDto<PrestamoDto>> CrearPrestamoAsync(CreatePrestamoDto dto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Verificamos si el cliente existe
                    var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente);
                    if (!clienteExiste)
                    {
                        return new ResponseDto<PrestamoDto>
                        {
                            StatusCode = 404,
                            Status = false,
                            Message = "Cliente no encontrado."
                        };
                    }

                    // Crear y guardar el préstamo
                    var prestamoEntity = _mapper.Map<PrestamoEntity>(dto);
                    _context.Prestamos.Add(prestamoEntity);
                    await _context.SaveChangesAsync();

                    // Calcular el plan de amortización
                    var planAmortizacion = CalcularPlanAmortizacion(dto);
                    foreach (var amortizacion in planAmortizacion)
                    {
                        var infoPrestamoEntity = _mapper.Map<InfoPrestamoEntity>(amortizacion);
                        infoPrestamoEntity.IdPrestamo = prestamoEntity.IdPrestamo;
                        _context.InfoPrestamos.Add(infoPrestamoEntity);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new ResponseDto<PrestamoDto>
                    {
                        StatusCode = 201,
                        Status = true,
                        Message = "Préstamo y plan de amortización creados correctamente.",
                        Data = new PrestamoDto
                        {
                            IdPrestamo = prestamoEntity.IdPrestamo,
                            Monto = dto.Monto,
                            Interes = dto.Interes,
                            Plazo = dto.Plazo,
                            FechaDesombolso = dto.FechaDesombolso,
                            IdCliente = dto.IdCliente
                        }
                    };
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(e, "Error al crear la publicacion");
                    return new ResponseDto<PrestamoDto>
                    {
                        StatusCode = 500,
                        Status = false,
                        Message = "Se produjo un error al crear la publicacion"
                    }; ;
                }
            }
        }



        private List<InfoPrestamosDto> CalcularPlanAmortizacion(CreatePrestamoDto prestamoDto)
        {
            decimal monto = (decimal)prestamoDto.Monto;
            decimal interesAnual = (decimal)prestamoDto.Interes;
            int plazoMeses = prestamoDto.Plazo;
            decimal tasaMensual = interesAnual / 100 / 12;
            decimal cuotaMensual = monto * tasaMensual / (1 - (decimal)Math.Pow((double)(1 + tasaMensual), -plazoMeses));

            var amortizaciones = new List<InfoPrestamosDto>();
            decimal saldoPrincipal = monto;

            for (int mes = 1; mes <= plazoMeses; mes++)
            {
                decimal interesMensual = saldoPrincipal * tasaMensual;
                decimal principalPago = cuotaMensual - interesMensual;
                saldoPrincipal -= principalPago;

                amortizaciones.Add(new InfoPrestamosDto
                {
                    IdAmortizacion = Guid.NewGuid(),
                    NoCuota = mes,
                    Fecha = prestamoDto.FechaDesombolso.AddMonths(mes),
                    Dias = 30,
                    Interes = interesMensual,
                    Abono = principalPago,
                    CuotaSinSVSD = cuotaMensual,
                    CuotaConSVSD = cuotaMensual,
                    SaldoPrincipal = saldoPrincipal
                });
            }

            return amortizaciones;
        }
    }
}
