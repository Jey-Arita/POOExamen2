using Examen2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen2.Database
{
    public class ExamenSeeder
    {
        public static async Task LoadDataAsync(
            ExamenContext context,
            ILoggerFactory loggerFactory
            )
        {
            try
            {
                await LoadPrestamoAsync(loggerFactory, context);
                await LoadClienteAsync(loggerFactory, context);             
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }

        private static async Task LoadPrestamoAsync(ILoggerFactory loggerFactory, ExamenContext _context)
        {
            try
            {
                var jsonfilePath = "SeedData/clientes.json";
                var jsonContent = await File.ReadAllTextAsync(jsonfilePath);
                var clientes = JsonConvert.DeserializeObject<List<ClienteEntity>>(jsonContent);
                if (!await _context.Clientes.AnyAsync())
                {
                    _context.Clientes.AddRange(clientes);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenContext>();
                logger.LogError(e, "Error al ejecutar el Seed de clientes.");
            }
        }

        private static async Task LoadClienteAsync(ILoggerFactory loggerFactory, ExamenContext _context)
        {
            try
            {
                var jsonfilePath = "SeedData/prestamos.json";
                var jsonnContent = await File.ReadAllTextAsync(jsonfilePath);
                var prestamos = JsonConvert.DeserializeObject<List<PrestamoEntity>>(jsonnContent);
                if (!await _context.Prestamos.AnyAsync())
                {
                    _context.Prestamos.AddRange(prestamos);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenContext>();
                logger.LogError(e, "Error al ejecutar el Seed de prestamos.");
            }
        }
    }
}

