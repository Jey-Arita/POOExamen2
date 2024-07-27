using AutoMapper;
using Examen2.Database.Entities;
using Examen2.Dtos.Clientes;
using Examen2.Dtos.InfoPrestamos;
using Examen2.Dtos.Prestamos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Examen2.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapForClientes();
        }

        private void MapForClientes()
        {
            CreateMap<CreatePrestamoDto, PrestamoEntity>();

            CreateMap<PrestamoEntity, PrestamoDto>();

            CreateMap<InfoPrestamosDto, InfoPrestamoEntity>()
                .ForMember(dest => dest.IdAmortizacion, opt => opt.Ignore());
            CreateMap<InfoPrestamoEntity, InfoPrestamosDto>();

        }
    }
}
