using System.Collections.Generic;
using GeaWebMVC.Models;
using GeaWebMVC.Utils;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessOperador
    {
        MessageReturn Create(Operador Operador);
        IEnumerable<Operador> GetAll();
        Operador GetById(int? OperadorId);
        MessageReturn Update(Operador Operador);
        void Remove(Operador Operador);
        Operador FindByLogin(string login);
        bool Isvalid(string login,string senha);
        Operador FindByCpf(string cpf);
    }
}