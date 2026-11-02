using ExaParcial_SandovalRamos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ExaParcial_SandovalRamos.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// LISTA EN MEMORIA PARA SIMULAR PACIENTES REGISTRADOS
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
        /// OBTENER TODOS LOS PACIENTES
        /// </summary>
        [HttpGet]
        public List<Paciente> Get()
        {
            return _ListaPacientes;
        }

        /// <summary>
        /// OBTENER PACIENTE POR ID
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<Paciente> Get(int id)
        {
            var paciente = _ListaPacientes.FirstOrDefault(x => x.Id == id);

            if (paciente is null)
            {
                return NotFound($"El paciente con ID {id} no existe.");
            }

            return Ok(paciente);
        }

        /// <summary>
        /// REGISTRAR PACIENTE
        /// </summary>
        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            var existePaciente = _ListaPacientes.Any(x => x.Id == paciente.Id);

            if (existePaciente)
            {
                return BadRequest($"El paciente con ID {paciente.Id} ya existe.");
            }

            _ListaPacientes.Add(paciente);

            return Ok("Paciente registrado correctamente.");
        }

        /// <summary>
        /// ACTUALIZAR PACIENTE
        /// </summary>
        [HttpPut]
        public ActionResult Put(Paciente paciente)
        {
            var datosPaciente = _ListaPacientes.FirstOrDefault(x => x.Id == paciente.Id);

            if (datosPaciente is null)
            {
                return BadRequest($"El paciente con ID {paciente.Id} no existe.");
            }

            datosPaciente.Nombre = paciente.Nombre;
            datosPaciente.Dni = paciente.Dni;

            return Ok("Paciente actualizado correctamente.");
        }

        /// <summary>
        /// ELIMINAR PACIENTE
        /// </summary>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var paciente = _ListaPacientes.FirstOrDefault(x => x.Id == id);

            if (paciente is null)
            {
                return BadRequest($"El paciente con ID {id} no existe.");
            }

            _ListaPacientes.Remove(paciente);

            return NoContent();
        }
    }
}