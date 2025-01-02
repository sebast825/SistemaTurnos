using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Tests;

[TestClass]
public class UnitTest1
{
    private  TurnoService _turnoService;
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IMapper> _mapperMock;
    [TestInitialize]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _turnoService = new TurnoService(_unitOfWorkMock.Object, _mapperMock.Object);
    }
    [TestMethod]
    public void TestMethod1()
    {
       bool result = _turnoService.suma(1,1);
        Assert.IsTrue(result);
    }


    DisponibilidadMedico unaDisponibilidad = new DisponibilidadMedico
    {
        MedicoId = 5,
        DiaSemanaId = 3,
        StartTime = new TimeSpan(13, 0, 0),
        EndTime = new TimeSpan(14, 0, 0)
    };
    Turno unTurno = new Turno()
    {
         MedicoId = 5,
        PacienteId = 3,
        Fecha = new DateTime().AddDays(1)
    };
    Turno dosTurno = new Turno()
    {
        MedicoId = 5,
        PacienteId = 3,
        Fecha = new DateTime().AddDays(1)
    };
    List<Turno> turnoList = new List<Turno>();

    TurnoHorarioDisponibleResponseDTO horariosDisponibles = new TurnoHorarioDisponibleResponseDTO
    {
        MedicoId = 5,
        Fecha = new DateTime()
    };
    List<TimeSpan>Horario = new List<TimeSpan>
    {
        new TimeSpan(13, 0, 0),  // 13:00
        new TimeSpan(13, 20, 0), // 13:20
        new TimeSpan(13, 40, 0)  // 13:40
    };

    [TestMethod]
    public void ObtenerHorariosDisponiblesPorDisponibilidad()
    {
        turnoList.Add(unTurno);
        turnoList.Add(dosTurno);
        DateTime dateHoy = DateTime.Now;
        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(unaDisponibilidad, turnoList, dateHoy, horariosDisponibles);
        CollectionAssert.AreEqual(Horario, result.Horario);

    }

    Turno tresTurno = new Turno()
    {
        MedicoId = 5,
        PacienteId = 3,
        Fecha = DateTime.Today.AddHours(13).AddMinutes(30)
    };
    List<Turno> turnoList2 = new List<Turno>();

    TimeSpan duracionTurno = new TimeSpan(0, 20, 0);
    TimeSpan checkiarDisponibilidad = new TimeSpan(13, 20, 0);


    [TestMethod]
    public void HayTurnoSameHorario()
    {
        turnoList2.Add(tresTurno);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList2);
        Assert.IsTrue(rsta);
    }
    Turno cuatroTurno = new Turno()
    {
        MedicoId = 5,
        PacienteId = 3,
        Fecha = DateTime.Today.AddHours(13).AddMinutes(50)
    };

    List<Turno> turnoList3 = new List<Turno>();
    [TestMethod]
    public void NoHayTurnoSameHorario()
    {
        turnoList3.Add(cuatroTurno);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList3);
        Assert.IsFalse(rsta);
    }
}