using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GeaWebMVC.Business;
using GeaWebMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.RepositoryInterfaces;

namespace GeaTest.Business
{
    [TestClass]
    public class BusinessFaturamentoTeste
    {
        private Mock<IRepositoryRegistroDeFluxo> _mockRegistro;
        private Mock<IRepositoryFaturamento> _mockFaturamento;
        private BusinessFaturamento _businessFaturamento;

        [TestInitialize()]
        public void Initialize()
        {
            _mockRegistro = new Mock<IRepositoryRegistroDeFluxo>();
            _mockFaturamento = new Mock<IRepositoryFaturamento>();
            _businessFaturamento = new BusinessFaturamento(_mockFaturamento.Object, _mockRegistro.Object);
        }
        [TestMethod]
        public void GerarFaturamento_True()
        {
            Faturamento faturamento = new Faturamento { DataCompetencia = new DateTime(2018, 05, 05) };
            //Expression<Func<TEntity, bool>>

            IEnumerable<RegistroDeFluxo> RegistrosDeFluxo = new List<RegistroDeFluxo>
                                                            { new RegistroDeFluxo {DataSaida= new DateTime(2018, 05, 05), ValorAPagar = 10},
                                                              new RegistroDeFluxo{DataSaida=new DateTime(2018,05,05), ValorAPagar = 10},
                                                              new RegistroDeFluxo{DataSaida = new DateTime(2018,05,05),ValorAPagar = 10 }};
            
            _mockRegistro.Setup(r => r.Find(It.IsAny<Expression<Func<RegistroDeFluxo, bool>>>())).Returns(RegistrosDeFluxo);

            double? esperado = 1.5;
            double? resultado = _businessFaturamento.GerarFaturamento(faturamento).ValorCompetencia;

            Assert.AreEqual(esperado, resultado);
        }
    }
}
