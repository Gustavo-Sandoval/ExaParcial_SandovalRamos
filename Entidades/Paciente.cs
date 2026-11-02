namespace ExaParcial_SandovalRamos.Entidades
{
    /// <summary>
    /// CLASE QUE REPRESENTA A UN PACIENTE DE LA CLÍNICA
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// IDENTIFICADOR DEL PACIENTE
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// NOMBRE COMPLETO DEL PACIENTE
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// DNI DEL PACIENTE
        /// </summary>
        public string Dni { get; set; } = string.Empty;
    }
}