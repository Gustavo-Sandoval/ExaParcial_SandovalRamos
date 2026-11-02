using System.Text.Json;

namespace ExaParcial_SandovalRamos.Middleware
{
    /// <summary>
    /// MIDDLEWARE PARA CAPTURAR EXCEPCIONES DE FORMA CENTRALIZADA
    /// </summary>
    public class MiddlewareExcepciones
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// CONSTRUCTOR DEL MIDDLEWARE
        /// </summary>
        /// <param name="next"></param>
        public MiddlewareExcepciones(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// MÉTODO QUE INTERCEPTA LAS PETICIONES HTTP
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepcionAsync(context, ex);
            }
        }

        /// <summary>
        /// MÉTODO PARA MANEJAR LAS EXCEPCIONES
        /// </summary>
        private static Task ManejarExcepcionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var respuesta = new RespuestaError
            {
                StatusCode = context.Response.StatusCode,
                Mensaje = "Error interno del servidor",
                Detalle = ex.Message
            };

            var json = JsonSerializer.Serialize(respuesta);

            return context.Response.WriteAsync(json);
        }
    }
}