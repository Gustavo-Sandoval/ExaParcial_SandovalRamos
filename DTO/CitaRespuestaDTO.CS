namespace ExaParcial_SandovalRamos.DTO
{
    /// <summary>
    /// DTO PARA MOSTRAR LA INFORMACIÓN COMPLETA DE LA CITA
    /// </summary>
    public class CitaRespuestaDTO
    {
        /// <summary>
        /// ID DE LA CITA
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FECHA DE LA CITA
        /// </summary>
        public DateTime FechaCita { get; set; }

        /// <summary>
        /// NOMBRE DEL PACIENTE
        /// </summary>
        public string NombrePaciente { get; set; } = string.Empty;

        /// <summary>
        /// NOMBRE DEL MÉDICO
        /// </summary>
        public string NombreMedico { get; set; } = string.Empty;

        /// <summary>
        /// ESPECIALIDAD DEL MÉDICO
        /// </summary>
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>
        /// ESTADO DE LA CITA
        /// </summary>
        public string Estado { get; set; } = string.Empty;
    }
}