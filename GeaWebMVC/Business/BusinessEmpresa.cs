using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessEmpresa : IBusinessEmpresa
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        public BusinessEmpresa(IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
        }


        public IEnumerable<Empresa> GetAll()
        {
            return _repositoryEmpresa.GetAll();
        }

        public Empresa GetById(int? EmpresaId)
        {
            return _repositoryEmpresa.GetById(EmpresaId);
        }

        public void Update(Empresa Empresa)
        {
            _repositoryEmpresa.Update(Empresa);
        }

        public void Create(Empresa Empresa)
        {
            _repositoryEmpresa.Add(Empresa);
        }

        public void Remove(Empresa empresa)
        {
            _repositoryEmpresa.Remove(empresa);
        }
    }
}