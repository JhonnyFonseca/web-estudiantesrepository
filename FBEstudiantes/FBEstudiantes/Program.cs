using FBEstudiantes;
using FBEstudiantes.Data;
using FBEstudiantes.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConections"));
builder.Services.AddSingleton(mySQLConfiguration);

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySQLConections")));

builder.Services.AddScoped<IEstudianteRepository, EstudianteRespository>();
builder.Services.AddScoped<ICursoRepository, CursoRespository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();
app.Run();
