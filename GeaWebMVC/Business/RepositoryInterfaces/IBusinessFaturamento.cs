using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessFaturamento
    {
        void Create(Faturamento faturamento);
        IEnumerable<Faturamento> GetAll();
        Faturamento GetById(int? FaturamentoId);
        void Update(Faturamento faturamento);
        void Remove(Faturamento faturamento);
        Faturamento GerarFaturamento(Faturamento faturamento);
        void SendEmail(Faturamento faturamento);


    }
}