using ExaParcial_SandovalRamos.DTO;
using ExaParcial_SandovalRamos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ExaParcial_SandovalRamos.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitasController : ControllerBase
    {
        /// <summary>
        /// LISTA DE PACIENTES REGISTRADOS
        /// </summary>
        private static List<Paciente> _ListaPacientes = new()
        {
            new Paciente(){ Id = 1, Nombre = "Randy Sandoval", Dni = "12345678" },
            new Paciente(){ Id = 2, Nombre = "Julia Ramos", Dni = "87654321" },
            new Paciente(){ Id = 3, Nombre = "Maria Ramos", Dni = "11223344" },
            new Paciente(){ Id = 4, Nombre = "Andrea Cahua", Dni = "44332211" },
            new Paciente(){ Id = 5, Nombre = "Carmen Gutierrez", Dni = "55667788" }
        };

        /// <summary>
        /// LISTA DE MÉDICOS REGISTRADOS
        /// </summary>
        private static List<Medico> _ListaMedicos = new()
        {
            new Medico(){ Id = 1, Nombre = "Guillermo Salas", Especialidad = "Cardiologia" },
            new Medico(){ Id = 2, Nombre = "Julio Zevallos", Especialidad = "Pediatria" },
            new Medico(){ Id = 3, Nombre = "Sharon Manrique", Especialidad = "Neurologia" },
            new Medico(){ Id = 4, Nombre = "Almendra Auccasi", Especialidad = "Dermatologia" },
            new Medico(){ Id = 5, Nombre = "Rosa Mendoza", Especialidad = "Traumatologia" }
        };

        /// <summary>
        /// LISTA DE CITAS REGISTRADAS
        /// </summary>
        private static List<Cita> _ListaCitas = new()
        {
            new Cita()
            {
                Id = 1,
                FechaCita = DateTime.Now.AddDays(1),
                PacienteId = 1,
                MedicoId = 1,
                Estado = "Programada"
            },

            new Cita()
            {
                Id = 2,
                FechaCita = DateTime.Now.AddDays(2),
                PacienteId = 2,
                MedicoId = 2,
                Estado = "Programada"
            },

            new Cita()
            {
                Id = 3,
                FechaCita = DateTime.Now.AddDays(3),
                PacienteId = 3,
                MedicoId = 3,
                Estado = "Programada"
            },

            new Cita()
            {
                Id = 4,
                FechaCita = DateTime.Now.AddDays(4),
                PacienteId = 4,
                MedicoId = 4,
                Estado = "Programada"
            },

            new Cita()
            {
                Id = 5,
                FechaCita = DateTime.Now.AddDays(5),
                PacienteId = 5,
                MedicoId = 5,
                Estado = "Programada"
            }
        };

        /// <summary>
        /// OBTENER TODAS LAS CITAS
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            var resultado = _ListaCitas.Select(c =>
            {
                var paciente = _ListaPacientes.FirstOrDefault(p => p.Id == c.PacienteId);
                var medico = _ListaMedicos.FirstOrDefault(m => m.Id == c.MedicoId);

                return new CitaRespuestaDTO
                {
                    Id = c.Id,
                    FechaCita = c.FechaCita,
                    NombrePaciente = paciente?.Nombre ?? "No registrado",
                    NombreMedico = medico?.Nombre ?? "No registrado",
                    Especialidad = medico?.Especialidad ?? "No registrada",
                    Estado = c.Estado
                };
            });

            return Ok(resultado);
        }

        /// <summary>
        /// OBTENER CITA POR ID
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<Cita> Get(int id)
        {
            var cita = _ListaCitas.FirstOrDefault(x => x.Id == id);

            if (cita is null)
            {
                return NotFound($"La cita con ID {id} no existe.");
            }

            return Ok(cita);
        }

        /// <summary>
        /// REGISTRAR UNA NUEVA CITA
        /// </summary>
        [HttpPost]
        public ActionResult Post(CitaDTO citaDTO)
        {
            int nuevoId = _ListaCitas.Count + 1;

            Cita nuevaCita = new()
            {
                Id = nuevoId,
                FechaCita = citaDTO.FechaCita,
                PacienteId = citaDTO.PacienteId,
                MedicoId = citaDTO.MedicoId,
                Estado = "Programada"
            };

            _ListaCitas.Add(nuevaCita);

            return Ok("Cita registrada correctamente.");
        }

        /// <summary>
        /// ACTUALIZAR UNA CITA
        /// </summary>
        [HttpPut]
        public ActionResult Put(Cita cita)
        {
            var datosCita = _ListaCitas.FirstOrDefault(x => x.Id == cita.Id);

            if (datosCita is null)
            {
                return BadRequest($"La cita con ID {cita.Id} no existe.");
            }

            datosCita.FechaCita = cita.FechaCita;
            datosCita.PacienteId = cita.PacienteId;
            datosCita.MedicoId = cita.MedicoId;
            datosCita.Estado = cita.Estado;

            return Ok("Cita actualizada correctamente.");
        }

        /// <summary>
        /// ELIMINAR UNA CITA
        /// </summary>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cita = _ListaCitas.FirstOrDefault(x => x.Id == id);

            if (cita is null)
            {
                return BadRequest($"La cita con ID {id} no existe.");
            }

            _ListaCitas.Remove(cita);

            return NoContent();
        }
    }
}