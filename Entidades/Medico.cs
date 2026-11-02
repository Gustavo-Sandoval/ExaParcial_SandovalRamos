namespace ExaParcial_SandovalRamos.Entidades
{
    /// <summary>
    /// CLASE QUE REPRESENTA A UN MÉDICO DE LA CLÍNICA
    /// </summary>
    public class Medico
    {
        /// <summary>
        /// IDENTIFICADOR ÚNICO DEL MÉDICO
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// NOMBRE COMPLETO DEL MÉDICO
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// ESPECIALIDAD MÉDICA DEL PROFESIONAL
        /// </summary>
        public string Especialidad { get; set; } = string.Empty;
    }
}