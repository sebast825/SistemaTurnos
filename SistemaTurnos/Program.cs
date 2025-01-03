using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Data.DataSeed;
using SistemaTurnos.Dal.Repository;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Filter;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir todas las solicitudes, esto esta bien en development, en produccion hay que modificarlo por seguridad
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//---------------------------------------JWT Swagger-----------------------------


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "JWT", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
        {
        {new OpenApiSecurityScheme
        {
             Reference = new OpenApiReference
             { Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
             }
        },
        new string[]{}

        }
    });
});
//--------------------------------------------------------------------------------

//--------------Services------------------------ | configuracion DB
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));


//-------------------------------Inyecciones-----| los repositorios creados
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IDisponibilidadMedicoRepository, DisponibilidadMedicoRepository>();
builder.Services.AddScoped<IDiaSemanaRepository, DiaSemanaRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<IAdministrativoRepository,AdministrativoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataContext>(),
    x.GetRequiredService<IPacienteRepository>(),
    x.GetRequiredService<IPersonaRepository>(),
    x.GetRequiredService<IMedicoRepository>(),
        x.GetRequiredService<IDisponibilidadMedicoRepository>(),
        x.GetRequiredService<IDiaSemanaRepository>(),
        x.GetRequiredService<ITurnoRepository>(),
        x.GetRequiredService<IAdministrativoRepository>(),
        x.GetRequiredService<IUsuarioRepository>(),
                x.GetRequiredService<IEspecialidadRepository>()


        ));


builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IDisponibilidadMedicoService, DisponibilidadMedicoService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IAdministrativoService, AdministrativoService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();
//para cada controlador agrega el manejo de exepciones

builder.Services.AddControllers(options =>
{
    //le indica que debe usar este filtro para cada accion del controlador

    options.Filters.Add<ExceptionHandlerFilter>();
});

//-----------------------------JWT---------------------------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
//----------------------------------------------------------------

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiereAdministrativo", policy => policy.RequireRole("Administrativo"));
    options.AddPolicy("RequiereMedico", policy => policy.RequireRole("Medico"));
    options.AddPolicy("RequierePaciente", policy => policy.RequireRole("Paciente"));
    // Agrega m�s pol�ticas seg�n sea necesario
});



var app = builder.Build();

//maneja los erroes del [authorize] de c#
//app.UseMiddleware<CustomAuthorizationMiddleware>();

// Use CORS
app.UseCors("AllowAll");

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
