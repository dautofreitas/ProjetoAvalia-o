using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessOperador : IBusinessOperador
    {
        private readonly IRepositoryOperador _repositoryOperador;

        public BusinessOperador(IRepositoryOperador repositoryOperador)
        {
            _repositoryOperador = repositoryOperador;
        }


        public IEnumerable<Operador> GetAll()
        {
            return _repositoryOperador.GetAll();
        }

        public Operador GetById(int? OperadorId)
        {
            return _repositoryOperador.GetById(OperadorId);
        }

        public void Update(Operador Operador)
        {
            _repositoryOperador.Update(Operador);
        }

        
        public void Create(Operador Operador)
        {
            _repositoryOperador.Add(Operador);
        }

        public void Remove(Operador Operador)
        {
            _repositoryOperador.Remove(Operador);
        }

        public Operador FindByLogin(string login)
        {
            return _repositoryOperador.FindSingle(op => op.Login == login);
        }

        public Operador FindByCpf(string cpf)
        {
            return _repositoryOperador.FindSingle(op => op.Cpf == cpf);
        }
    }
}