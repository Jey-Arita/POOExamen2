﻿
using Microsoft.EntityFrameworkCore;
using Examen2.Database;
using Examen2.Helpers;

namespace Examen2
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Add Custom services Llamamos el contexto
            services.AddDbContext<ExamenContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Llamos los servicios
            //services.AddTransient<ILibrosServices, LibrosServices>();

            // Configurar AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
