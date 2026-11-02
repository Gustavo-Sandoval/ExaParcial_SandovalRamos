using System.ComponentModel.DataAnnotations;

namespace ExaParcial_SandovalRamos.DTO
{
    /// <summary>
    /// DTO PARA REGISTRAR O ACTUALIZAR CITAS
    /// </summary>
    public class CitaDTO
    {
        /// <summary>
        /// FECHA DE LA CITA
        /// </summary>
        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        public DateTime FechaCita { get; set; }

        /// <summary>
        /// ID DEL PACIENTE
        /// </summary>
        [Required(ErrorMessage = "El paciente es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un paciente válido")]
        public int PacienteId { get; set; }

        /// <summary>
        /// ID DEL MÉDICO
        /// </summary>
        [Required(ErrorMessage = "El médico es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un médico válido")]
        public int MedicoId { get; set; }
    }
}