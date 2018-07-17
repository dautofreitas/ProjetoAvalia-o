using System;
using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessRegistroDeFluxo
    {
        void Create(RegistroDeFluxo RegistroDeFluxo);
        IEnumerable<RegistroDeFluxo> GetAll();
        RegistroDeFluxo GetById(int? RegistroDeFluxoId);
        void Update(RegistroDeFluxo RegistroDeFluxo);
        void Rmove(RegistroDeFluxo RegistroDeFluxo);
        RegistroDeFluxo CalculaValorAPagar(DateTime DataHoraSaida, int RegistroDeFluxoId);
    }
}