using Encuesta.Data;
using Encuesta.Interfaces;
using Encuesta.Repositories;
using Encuesta.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Encuesta.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbEncuestaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbEncuesta"))
            );
        }

        //public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        //{
        //   // services.Configure<OpcionesPaginacion>(options => configuration.GetSection("Pagination").Bind(options));

        //    //return services;
        //}
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Servicios
            services.AddTransient<IEncuestaService, EncuestaService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IListadoCamposService, ListadoCamposService>();
            services.AddTransient<IRespuestasService, RespuestasService>();
            //Repositorios
            services.AddTransient<IEncuestaRepository, EncuestaRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IListadoCamposRepository, ListadoCamposRepository>();
            services.AddTransient<IRespuestasRepository, RespuestasRepository>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                //doc.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Title = "Encuesta",
                //    Version = "v1",
                //});

                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Encuesta", Version = "v1" });

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Esquema de autorizacion. <BR/>
                      Por favor ingresar 'Bearer' [espacio] seguido del token generado en el login.
                      <BR/>Ejemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });


                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
