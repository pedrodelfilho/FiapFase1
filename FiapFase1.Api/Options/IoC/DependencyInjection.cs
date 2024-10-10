using AutoMapper;
using FiapFase1.Data.Context;
using FiapFase1.Data.Repositories;
using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Entities.Requests;
using FiapFase1.Domain.Interfaces.Repositories;
using FiapFase1.Domain.Interfaces.Services;
using FiapFase1.Manager.Services;
using Microsoft.EntityFrameworkCore;

namespace FiapFase1.Api.Options.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection       
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection strings
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BdPadraoConnection")));

            // JWT
            var jwtOptions = configuration.GetSection("JwtOptions");

            //Auto Mapper
            var autoMapperConfig = new MapperConfiguration(cfg => { 
                cfg.CreateMap<RegistrarContatoRequest, Contato>().ReverseMap(); 
                cfg.CreateMap<AtualizarContatoRequest, Contato>().ReverseMap(); 
            
            });
            services.AddSingleton(autoMapperConfig.CreateMapper());

            // Repositórios
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IDDDRepository, DDDRepository>();

            // Services          
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IDDDService, DDDService>();
            return services;
        }
    }
}
