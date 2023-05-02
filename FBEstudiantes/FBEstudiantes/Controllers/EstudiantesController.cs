using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FBEstudiantes.Data.Repositories;
using FBEstudiantes.Model;

namespace FBEstudiantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _estudiantesRepository;

        public EstudiantesController(IEstudianteRepository estudiantesRepository)
        {
            _estudiantesRepository = estudiantesRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEstudiantes()
        {
            return Ok(await _estudiantesRepository.GetAllEstudiantes());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetEstudianteDetails(int id)
        {
            return Ok(await _estudiantesRepository.GetDetailsEstudiante(id));
        }

        [HttpPost]
        public async Task <IActionResult> CreateEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _estudiantesRepository.InsertEstudiante(estudiante);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estudiantesRepository.UpdateEstudiante(estudiante);

            return NoContent();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            await _estudiantesRepository.DeleteEstudiante(new Estudiante { IdEstudiante = id });

            return NoContent();
        }

    }

    public class CursosController : ControllerBase
    {
        private readonly ICursoRepository _CursoRepository;

        public CursosController(ICursoRepository CursosRepository)
        {
            _CursoRepository = CursosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCursos()
        {
            return Ok(await _CursoRepository.GetAllCursos());
        }
    }
}
