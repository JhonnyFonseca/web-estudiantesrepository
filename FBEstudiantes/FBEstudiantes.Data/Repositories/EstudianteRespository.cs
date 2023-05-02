using Dapper;
using FBEstudiantes.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBEstudiantes.Data.Repositories
{
    public class EstudianteRespository : IEstudianteRepository
    {
        private readonly MySQLConfiguration _connectionStrinng;
        public EstudianteRespository(MySQLConfiguration connectionString)
        {
              _connectionStrinng = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionStrinng.ConnectionString);
        }

        public async Task<bool> DeleteEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"Delete form mydb.estudiante where idEstudainte = @idEstudainte";
            var result = await db.ExecuteAsync(sql, new { idEstudiante = estudiante.IdEstudiante });

            return result > 0;
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiantes()
        {
            var db = dbConnection();
            var sql = @"call mydb.EstudianteCurso('ie', 0)";
            return await db.QueryAsync<Estudiante>(sql, new { });
        }

        public async Task<Estudiante> GetDetailsEstudiante(int id)
        {
            var db = dbConnection();
            var sql = @"call mydb.EstudianteCurso('ie', @IdEstudiante)";
            return await db.QueryFirstOrDefaultAsync<Estudiante>(sql, new { IdEstudiante = id}) ;
        }

        public async Task<bool> InsertEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"insert into mydb.estudiante (idEstudiante,Nombre1,Nombre2,Apellido1,Apellido2,NumContacto,Email,Direccion)
                        values @idEstudiante,@nombre1,@nombre2,@apellido1,@apellido2,@numcontacto, @email, @direccion";
            var result = await db.ExecuteAsync(sql, new { estudiante.IdEstudiante, estudiante.Nombre1, estudiante.Nombre2, estudiante.Apellido1, estudiante.Apellido2, estudiante.NumContacto, estudiante.Email, estudiante.Direccion });

            return result > 0;
        }

        public async Task<bool> UpdateEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"update mydb.estudiante 
                        set Nombre1 = @nombre1,Nombre2=  @nombre2,Apellido1 =@apellido1,Apellido2=@apellido2,NumContacto=@numcontacto,Emai=l@email,Direccion=@direccion
                        where idEstudiante =@idEstudiante";
            var result = await db.ExecuteAsync(sql, new { estudiante.IdEstudiante, estudiante.Nombre1, estudiante.Nombre2, estudiante.Apellido1, estudiante.Apellido2, estudiante.NumContacto, estudiante.Email, estudiante.Direccion });

            return result > 0;
        }

        
    }

    public class CursoRespository : ICursoRepository
    {
        private readonly MySQLConfiguration _connectionStrinng;
        public CursoRespository(MySQLConfiguration connectionString)
        {
            _connectionStrinng = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionStrinng.ConnectionString);
        }

        public async Task<IEnumerable<Cursos>> GetAllCursos()
        {
            var db = dbConnection();
            var sql = @"call mydb.EstudianteCurso('ac', 0)";
            return await db.QueryAsync<Cursos>(sql, new { });
        }
    }
}
