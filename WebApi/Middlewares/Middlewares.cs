using Microsoft.AspNetCore.Builder;

namespace WebApi.Middlewares
{
    public class Middlewares
    {
        readonly RequestDelegate next; //me permite hacer  el llamado al  siguiente middleware en la app


        public Middlewares(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            
            //esta funcion invoca al middleware que sigue. siempre obtenemos la respuesta del ultimo middleware

            if (context.Request.Query.Any(p => p.Key == "Time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }

            if (!context.Response.HasStarted)
            {
                await next(context);
            }

        }

    }

    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Middlewares>();
        }
    }
}
