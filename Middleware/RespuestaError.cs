namespace ExaParcial_SandovalRamos.Middleware
{
    /// <summary>
    /// CLASE PARA ESTRUCTURAR LAS RESPUESTAS DE ERROR
    /// </summary>
    public class RespuestaError
    {
        /// <summary>
        /// CÓDIGO DE ESTADO HTTP
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// MENSAJE DEL ERROR
        /// </summary>
        public string Mensaje { get; set; } = string.Empty;

        /// <summary>
        /// DETALLE DEL ERROR GENERADO
        /// </summary>
        public string Detalle { get; set; } = string.Empty;
    }
}
