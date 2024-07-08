using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Data.DataSeed;
using SistemaTurnos.Dal.Repository;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//--------------Services------------------------ | configuracion DB
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));


//-------------------------------Inyecciones-----| los repositorios creados
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IEstadoUsuarioRepository, EstadoUsuarioRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IDisponibilidadMedicoRepository, DisponibilidadMedicoRepository>();
builder.Services.AddScoped<IDiaSemanaRepository, DiaSemanaRepository>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataContext>(),
    x.GetRequiredService<IPacienteRepository>(),
    x.GetRequiredService<IPersonaRepository>(),
    x.GetRequiredService<IEstadoUsuarioRepository>(),
    x.GetRequiredService<IMedicoRepository>(),
        x.GetRequiredService<IDisponibilidadMedicoRepository>(),
        x.GetRequiredService<IDiaSemanaRepository>()

        ));


builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IDisponibilidadMedicoService, DisponibilidadMedicoService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
