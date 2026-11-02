using ExaParcial_SandovalRamos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ExaParcial_SandovalRamos.Controllers
{
    [ApiController]
    [Route("api/medicos")]
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// LISTA EN MEMORIA PARA SIMULAR MÉDICOS REGISTRADOS
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
        /// OBTENER TODOS LOS MÉDICOS
        /// </summary>
        [HttpGet]
        public List<Medico> Get()
        {
            return _ListaMedicos;
        }

        /// <summary>
        /// OBTENER MÉDICO POR ID
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<Medico> Get(int id)
        {
            var medico = _ListaMedicos.FirstOrDefault(x => x.Id == id);

            if (medico is null)
            {
                return NotFound($"El médico con ID {id} no existe.");
            }

            return Ok(medico);
        }

        /// <summary>
        /// REGISTRAR MÉDICO
        /// </summary>
        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            var existeMedico = _ListaMedicos.Any(x => x.Id == medico.Id);

            if (existeMedico)
            {
                return BadRequest($"El médico con ID {medico.Id} ya existe.");
            }

            _ListaMedicos.Add(medico);

            return Ok("Médico registrado correctamente.");
        }

        /// <summary>
        /// ACTUALIZAR MÉDICO
        /// </summary>
        [HttpPut]
        public ActionResult Put(Medico medico)
        {
            var datosMedico = _ListaMedicos.FirstOrDefault(x => x.Id == medico.Id);

            if (datosMedico is null)
            {
                return BadRequest($"El médico con ID {medico.Id} no existe.");
            }

            datosMedico.Nombre = medico.Nombre;
            datosMedico.Especialidad = medico.Especialidad;

            return Ok("Médico actualizado correctamente.");
        }

        /// <summary>
        /// ELIMINAR MÉDICO
        /// </summary>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var medico = _ListaMedicos.FirstOrDefault(x => x.Id == id);

            if (medico is null)
            {
                return BadRequest($"El médico con ID {id} no existe.");
            }

            _ListaMedicos.Remove(medico);

            return NoContent();
        }
    }
}