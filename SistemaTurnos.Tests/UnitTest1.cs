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
    public void TestMethod1()
    {
        bool result = _turnoService.suma(1, 1);
        Assert.IsTrue(result);
    }




    [TestMethod]
    public void ObtenerHorariosDisponiblesPorDisponibilidad()
    {

        DateTime dateHoy = DateTime.Now;

        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            DataTurnoTest.GetTurnos(),
            dateHoy,
            DataTurnoTest.GetHorariosDisponiblesDTO());

        CollectionAssert.AreEqual(DataTurnoTest.GetHorariosEsperados(), result.Horario);

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

  
}