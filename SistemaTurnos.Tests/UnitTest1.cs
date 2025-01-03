using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;
using System.Xml;

namespace SistemaTurnos.Tests;

[TestClass]
public class UnitTest1
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
    public void HayTurnoSameHorario()
    {
        Turno tresTurno = new Turno()
        {
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today.AddHours(13).AddMinutes(20)
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(tresTurno);
        TimeSpan checkiarDisponibilidad = new TimeSpan(13, 20, 0);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList);

        Assert.IsTrue(rsta);
    }
    [TestMethod]
    public void HayTurnoLimiteMayor()
    {
        Turno tresTurno = new Turno()
        {
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today.AddHours(13).AddMinutes(39)
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(tresTurno);
        TimeSpan checkiarDisponibilidad = new TimeSpan(13, 20, 0);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList);

        Assert.IsTrue(rsta);
    }
    [TestMethod]
    public void NoHayTurnoLimiteMayor()
    {
        Turno tresTurno = new Turno()
        {
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today.AddHours(13).AddMinutes(40)
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(tresTurno);
        TimeSpan checkiarDisponibilidad = new TimeSpan(13, 20, 0);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList);

        Assert.IsFalse(rsta);
    }
    [TestMethod]
    public void NoHayTurnoLimiteMenor()
    {
        Turno tresTurno = new Turno()
        {
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today.AddHours(13)
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(tresTurno);
        TimeSpan checkiarDisponibilidad = new TimeSpan(13, 20, 0);

        bool rsta = _turnoService.HayTurno(checkiarDisponibilidad, duracionTurno, turnoList);

        Assert.IsFalse(rsta);
    }

    [TestMethod]
    public void ObtenerTurnosAgrupadosPorDia_EnviaUnTurno()
    {
        Turno unTurno = new Turno()
        {
            Id = 1,
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(unTurno);
        
        Dictionary<DateTime, List<Turno>> rsta = _turnoService.SortTurnosByDay(turnoList);

        var turnoDeHoy = rsta[DateTime.Today.Date];

        Assert.IsTrue(rsta.ContainsKey(DateTime.Today.Date));
        Assert.IsTrue(turnoDeHoy.Any(t => t.Id == 1));
    }
    [TestMethod]
    public void ObtenerTurnosAgrupadosPorDia_EnviaDosTurnoS()
    {
        Turno unTurno = new Turno()
        {
            Id = 1,
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today
        };
        Turno dosTurno = new Turno()
        {
            Id = 2,
            MedicoId = 5,
            PacienteId = 3,
            Fecha = DateTime.Today.AddDays(1)
        };
        List<Turno> turnoList = new List<Turno>();
        turnoList.Add(unTurno);
        turnoList.Add(dosTurno);

        Dictionary<DateTime, List<Turno>> rsta = _turnoService.SortTurnosByDay(turnoList);

        var turnoDeHoy = rsta[DateTime.Today.Date];
        var turnoDeMañana= rsta[DateTime.Today.Date.AddDays(1)];

        Assert.IsTrue(rsta.ContainsKey(DateTime.Today.Date));
        Assert.IsTrue(turnoDeHoy.Any(t => t.Id == 1));
        Assert.IsFalse(turnoDeHoy.Any(t => t.Id == 2));
        Assert.IsFalse(turnoDeMañana.Any(t => t.Id == 1));
        Assert.IsTrue(turnoDeMañana.Any(t => t.Id == 2));
        Assert.AreEqual(2,rsta.Count);

    }

}