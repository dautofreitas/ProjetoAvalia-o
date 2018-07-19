using System.Collections.Generic;
using GeaWebMVC.Models;
using GeaWebMVC.Utils;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessEmpresa
    {
        MessageReturn Create(Empresa empresa);
        IEnumerable<Empresa> GetAll();
        Empresa GetById(int? empresaId);
        MessageReturn Update(Empresa empresa);
        void Remove(Empresa empresa);
        Empresa GetByNome(string nome);
        Empresa GetByCnpj(string cnpj);


    }
}