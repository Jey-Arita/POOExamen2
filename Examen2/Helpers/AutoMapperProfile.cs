using AutoMapper;
using Examen2.Database.Entities;
using Examen2.Dtos.Clientes;
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
            CreateMap<ClienteEntity, ClienteDto>();

        }
    }
}
