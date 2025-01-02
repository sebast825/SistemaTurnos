using AutoMapper;
using Moq;
using SistemaTurnos.Dal;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Tests;

[TestClass]
public class UnitTest1
{
    private  ITurnoService _turnoService;


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
    [TestMethod]
    public void TestMethod2()
    {
        bool result = _turnoService.suma(1, 1);
        Assert.AreEqual(1,1);
    }
}