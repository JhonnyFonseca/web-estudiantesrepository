using FBEstudiantes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBEstudiantes.Data.Repositories
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        Task<Estudiante> GetDetailsEstudiante(int id);
        Task<bool> InsertEstudiante(Estudiante estudiante);
        Task<bool> UpdateEstudiante(Estudiante estudiante);
        Task<bool> DeleteEstudiante(Estudiante estudiante);
    }

    public interface ICursoRepository
    {
        Task<IEnumerable<Cursos>> GetAllCursos();
    }
}
