using GeaWebMVC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.RepositoryInterfaces;
using System;

namespace GeaTest.Business
{
    [TestClass]
    public class BusinessRegistroDeFluxoTeste
    {
        private Mock<IRepositoryRegistroDeFluxo> _mock;
        private BusinessRegistroDeFluxo _businessRegistroDeFluxo;
        [TestInitialize()]
        public void Initialize()
        {
            _mock = new Mock<IRepositoryRegistroDeFluxo>();
            _businessRegistroDeFluxo = new BusinessRegistroDeFluxo(_mock.Object);
        }
        [TestMethod]
        public void CalculaValorAPagar_True()
        {
            DateTime dataHoraEntrada = new DateTime(2018,5,1,0,0,0);
            DateTime dataHoraSaida = new DateTime(2018,5,1, 0, 2, 0);

            decimal esperado = 0.26m;
            decimal? obitido = _businessRegistroDeFluxo.calculaValorPorIntervaloDeDatas(dataHoraEntrada, dataHoraSaida);

            Assert.AreEqual(esperado, obitido);
        }
        
    }
}
