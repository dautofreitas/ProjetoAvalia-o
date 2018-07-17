using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessEmpresa
    {
        void Create(Empresa empresa);
        IEnumerable<Empresa> GetAll();
        Empresa GetById(int? empresaId);
        void Update(Empresa empresa);
        void Remove(Empresa empresa);
    }
}