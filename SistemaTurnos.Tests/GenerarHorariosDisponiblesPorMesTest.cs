using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SistemaTurnos.Tests;

[TestClass]
public class GenerarHorariosDisponiblesPorMesTest
{
    private TurnoService _turnoService;
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IMapper> _mapperMock;
    TimeSpan duracionTurno = new TimeSpan(0, 20, 0);

    [TestInitialize]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _turnoService = new TurnoService(_unitOfWorkMock.Object, _mapperMock.Object);
    }


    [TestMethod]

    public void ObtenerHorariosDisponiblesMes_TurnosVacioUnaDisponibilidad()
    {
        DisponibilidadMedico disponibilidadMedico = new DisponibilidadMedico()
        {
            MedicoId = 5,
            DiaSemanaId = 3,
            StartTime = new TimeSpan(13, 0, 0),
            EndTime = new TimeSpan(14, 0, 0)            
        };


        List<DisponibilidadMedico> disponibilidadMedicosList = new List<DisponibilidadMedico>();
        disponibilidadMedicosList.Add(disponibilidadMedico);
    
        int medicoId = 5;

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
            new TimeSpan(13, 0, 0),
            new TimeSpan(13, 20, 0),
            new TimeSpan(13, 40, 0),
        };
       List<Turno> turnosList = new List<Turno>();


        List<TurnoHorarioDisponibleResponseDTO> rst = _turnoService.GenerarHorariosDisponiblesPorMes(medicoId, turnosList, disponibilidadMedicosList);

        foreach (TurnoHorarioDisponibleResponseDTO turno in rst) {
            CollectionAssert.AreEqual(turno.Horario, horariosEsperados);
            Assert.IsNotNull(turno, "El resultado no debería ser null");
            Assert.AreEqual(medicoId, turno.MedicoId, "El ID del médico no coincide");

        }
        
    }
 

  


}