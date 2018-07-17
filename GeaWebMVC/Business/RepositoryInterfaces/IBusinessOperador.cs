using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessOperador
    {
        void Create(Operador Operador);
        IEnumerable<Operador> GetAll();
        Operador GetById(int? OperadorId);
        void Update(Operador Operador);
        void Remove(Operador Operador);
        Operador FindByLogin(string login);
        Operador FindByCpf(string cpf);
    }
}