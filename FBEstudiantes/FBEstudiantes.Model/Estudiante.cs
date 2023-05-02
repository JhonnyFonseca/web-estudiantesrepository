using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBEstudiantes.Model
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NumContacto { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

    }

    public class Cursos
    {
        public int idCurso { get; set; }

        public string NombreCurso { get; set; }
    }
}
