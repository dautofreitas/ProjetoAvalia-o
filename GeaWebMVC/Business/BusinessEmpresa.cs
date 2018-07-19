using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using GeaWebMVC.Utils;
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
        private MessageReturn messageRetorno;
        public BusinessEmpresa(IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
            messageRetorno = new MessageReturn();
        }


        public IEnumerable<Empresa> GetAll()
        {
            return _repositoryEmpresa.GetAll();
        }

        public Empresa GetById(int? EmpresaId)
        {
            return _repositoryEmpresa.GetById(EmpresaId);
        }

        public MessageReturn Update(Empresa empresa)
        {
            validateEmpresa(empresa);

            if (messageRetorno.IsValid)
                _repositoryEmpresa.Update(empresa);

            return messageRetorno;
        }

        public void Remove(Empresa empresa)
        {
            _repositoryEmpresa.Remove(empresa);
        }

        MessageReturn IBusinessEmpresa.Create(Empresa empresa)
        {
            validateEmpresa(empresa);

            if (messageRetorno.IsValid)
                _repositoryEmpresa.Add(empresa);

            return messageRetorno;
        }

        public Empresa GetByNome(string nome)
        {
            return _repositoryEmpresa.FindSingle(e => e.Nome.ToUpper() == nome.ToUpper());
        }

        public Empresa GetByCnpj(string cnpj)
        {
            return _repositoryEmpresa.FindSingle(e => e.Cnpj.ToUpper() == cnpj.ToUpper());
        }

        private void validateEmpresa(Empresa empresa)
        {
            if(GetByCnpj(empresa.Cnpj) != null)
            {
                messageRetorno.AddError("Já existe uma empresa com o CNPJ informado");
            }
            if (GetByCnpj(empresa.Nome) != null)
            {
                messageRetorno.AddError("Já existe uma empresa com o Nome informado");
            }
          
        }
    }
}