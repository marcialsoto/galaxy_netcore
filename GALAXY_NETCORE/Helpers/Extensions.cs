using System;
using GALAXY_NETCORE.Manager;
using GALAXY_NETCORE.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GALAXY_NETCORE.Helpers
{
    public static class Extensions
    {
        public static void InyectaDependencias(this IServiceCollection services)
        {

            services.AddTransient<ITipoArticuloServices, TipoArticuloServices>();
            services.AddTransient<ITipoArticuloManager, TipoArticuloManager>();

            services.AddTransient<IUserAppServices, UserAppServices>();
            services.AddTransient<IUsuarioManager, UsuarioManager>();

            services.AddTransient<IArticuloServices, ArticuloServices>();
            services.AddTransient<IArticuloManager, ArticuloManager>();

            services.AddTransient<IOpcionServices, OpcionServices>();
            services.AddTransient<IOpcionManager, OpcionManager>();

        }

        public static void GestionExcepciones(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError($"Sucedio un error inesperado: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

    }
}
