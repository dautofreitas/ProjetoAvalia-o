using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessRegistroDeFluxo : IBusinessRegistroDeFluxo
    {
        private readonly IRepositoryRegistroDeFluxo _repositoryRegistroDeFluxo;

        public BusinessRegistroDeFluxo(IRepositoryRegistroDeFluxo repositoryRegistroDeFluxo)
        {
            _repositoryRegistroDeFluxo = repositoryRegistroDeFluxo;
        }


        public IEnumerable<RegistroDeFluxo> GetAll()
        {
            return _repositoryRegistroDeFluxo.GetAll();
        }

        public RegistroDeFluxo GetById(int? RegistroDeFluxoId)
        {
            return _repositoryRegistroDeFluxo.GetById(RegistroDeFluxoId);
        }

        public void Update(RegistroDeFluxo RegistroDeFluxo)
        {
            _repositoryRegistroDeFluxo.Update(RegistroDeFluxo);
        }

        public void Create(RegistroDeFluxo RegistroDeFluxo)
        {
            _repositoryRegistroDeFluxo.Add(RegistroDeFluxo);
        }

        public void Rmove(RegistroDeFluxo RegistroDeFluxo)
        {
            _repositoryRegistroDeFluxo.Remove(RegistroDeFluxo);
        }

        public RegistroDeFluxo CalculaValorAPagar(DateTime DataHoraSaida, int RegistroDeFluxoId)
        {
            RegistroDeFluxo registro = _repositoryRegistroDeFluxo.GetById(RegistroDeFluxoId);

            registro.DataSaida = DataHoraSaida;
            registro.HoraSaida = DataHoraSaida;

            var DataHoraEntrada = registro.DataEntrada.Value.AddHours(registro.HoraEntrada.Value.Hour).AddMinutes(registro.HoraEntrada.Value.Minute);

            double totalMinutos =  (registro.HoraSaida - DataHoraEntrada).Value.TotalMinutes;

            registro.ValorAPagar = calculaValorPorIntervaloDeDatas(DataHoraEntrada, DataHoraSaida);

            _repositoryRegistroDeFluxo.Update(registro);

            return registro;
        }

        public decimal? calculaValorPorIntervaloDeDatas(DateTime DataHoraEntrada, DateTime DataHoraSaida)
        {
            double totalMinutos = (DataHoraSaida - DataHoraEntrada).TotalMinutes;

            return (decimal)(totalMinutos * 0.13);
        }
    }
}