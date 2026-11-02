namespace ExaParcial_SandovalRamos.Entidades
{
    /// <summary>
    /// CLASE QUE REPRESENTA UNA CITA MÉDICA
    /// </summary>
    public class Cita
    {
        /// <summary>
        /// IDENTIFICADOR DE LA CITA
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FECHA DE LA CITA
        /// </summary>
        public DateTime FechaCita { get; set; }

        /// <summary>
        /// IDENTIFICADOR DEL PACIENTE
        /// </summary>
        public int PacienteId { get; set; }

        /// <summary>
        /// IDENTIFICADOR DEL MÉDICO
        /// </summary>
        public int MedicoId { get; set; }

        /// <summary>
        /// ESTADO DE LA CITA
        /// </summary>
        public string Estado { get; set; } = string.Empty;
    }
}