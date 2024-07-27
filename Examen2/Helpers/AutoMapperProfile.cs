using Examen2.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Examen2.Helpers
{
    public class AutoMapperProfile
    {
        public static async Task LoadDataAsync(
           ExamenContext context,
           ILoggerFactory loggerFactory
           )
        {
            try
            {
                //cargar las los servicios e interfaces, osea hacer intercambios
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }
    }
}
