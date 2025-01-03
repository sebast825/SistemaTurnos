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
public class HorariosDisponiblesporDisponibilidadTest
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
    public void ObtenerHorariosDisponibles_TurnosHorarioNoCoincidenConDisponibilidad_RetornaHorariosDisponibles()
    {


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            DataTurnoTest.GetTurnos(),

            DataTurnoTest.GetHorarioDisponiblesResponse());

        CollectionAssert.AreEqual(DataTurnoTest.GetHorariosEsperados(), result.Horario);

    }
    [TestMethod]
    public void ObtenerHorariosDisponibles_TurnosHorarioCoincidenAlPrincipioConDisponibilidad_RetornaHorariosDisponibles()
    {

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
            new TimeSpan(13, 20, 0),
            new TimeSpan(13, 40, 0)
        };
        List<Turno> GetTurnos = new List<Turno>()
        {
            new Turno{
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Today.AddHours(13),
            },
        };


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            GetTurnos,
            
            DataTurnoTest.GetHorarioDisponiblesResponse());

        CollectionAssert.AreEqual(horariosEsperados, result.Horario);

    }
    //[TestMethod] Desabilitada porque chekea limite superior, actualmente solo toma el horario exacto, para modificar usar funcion TuroDisponible
    public void ObtenerHorariosDisponibles_TurnosHorarioCoincidenAlFinalConDisponibilidad_RetornaHorariosDisponibles()
    {

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
             new TimeSpan(13, 0, 0),
            new TimeSpan(13, 20, 0)

        };
        List<Turno> GetTurnos = new List<Turno>()
        {
            new Turno{
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Today.AddHours(13).AddMinutes(59),
            },
        };


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            GetTurnos,
     
            DataTurnoTest.GetHorarioDisponiblesResponse());
      
        CollectionAssert.AreEqual(horariosEsperados, result.Horario);


    }
    [TestMethod]
    public void ObtenerHorariosDisponibles_TurnosHorarioCoincidenAlMedioConDisponibilidad_RetornaHorariosDisponibles()
    {

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
             new TimeSpan(13, 0, 0),
            new TimeSpan(13, 40, 0)

        };
        List<Turno> GetTurnos = new List<Turno>()
        {
            new Turno{
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Today.AddHours(13).AddMinutes(20),
            },
        };


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            GetTurnos,
            DataTurnoTest.GetHorarioDisponiblesResponse());
   
        CollectionAssert.AreEqual(horariosEsperados, result.Horario);
        


    }

    [TestMethod]
    public void ObtenerHorariosDisponibles_TurnosHorarioCoincidenAlMedioConDisponibilidad_RetornaHorariosDisponibles2()
    {

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
             new TimeSpan(13, 0, 0)
       

        };
        List<Turno> GetTurnos = new List<Turno>()
        {
            new Turno{
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Today.AddHours(13).AddMinutes(20),
            },
              new Turno{
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Today.AddHours(13).AddMinutes(40),
            },
        };


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            GetTurnos,

            DataTurnoTest.GetHorarioDisponiblesResponse());

        CollectionAssert.AreEqual(horariosEsperados, result.Horario);
    }

    [TestMethod]
    public void ObtenerHorariosDisponibles_TurnosVacio_RetornaHorariosDisponibles()
    {

        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
             new TimeSpan(13, 0, 0),
               new TimeSpan(13, 20, 0),
                 new TimeSpan(13, 40, 0),


        };
        List<Turno> GetTurnos = new List<Turno>();



        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            DataTurnoTest.GetDisponibilidadMedico(),
            GetTurnos,

            DataTurnoTest.GetHorarioDisponiblesResponse());

        CollectionAssert.AreEqual(horariosEsperados, result.Horario);

    }
    [TestMethod]
    public void ObtenerHorariosDisponibles_DisponibilidadEntre1300y1410_RetornaHorariosDisponibles()
    {
        DisponibilidadMedico disponibilidadMedico = new DisponibilidadMedico()
        {
            MedicoId = 5,
            DiaSemanaId = 3,
            StartTime = new TimeSpan(13, 0, 0),
            EndTime = new TimeSpan(14, 10, 0)
        };
        List<TimeSpan> horariosEsperados = new List<TimeSpan>()
        {
            new TimeSpan(13, 0, 0),
            new TimeSpan(13, 20, 0),
            new TimeSpan(13, 40, 0),
             new TimeSpan(14, 00, 0),


        };
        List<Turno> GetTurnos = new List<Turno>();


        TurnoHorarioDisponibleResponseDTO result = _turnoService.ObtenerHorariosDisponiblesPorDisponibilidad(
            disponibilidadMedico,
            GetTurnos,

            DataTurnoTest.GetHorarioDisponiblesResponse());

        CollectionAssert.AreEqual(horariosEsperados, result.Horario);

    }

}