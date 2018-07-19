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
    public class BusinessOperador : IBusinessOperador
    {
        private readonly IRepositoryOperador _repositoryOperador;
        private MessageReturn msgRetorno ;

        public BusinessOperador(IRepositoryOperador repositoryOperador)
        {
            _repositoryOperador = repositoryOperador;
            msgRetorno = new MessageReturn();
        }


        public IEnumerable<Operador> GetAll()
        {
            return _repositoryOperador.GetAll();
        }

        public Operador GetById(int? OperadorId)
        {
            return _repositoryOperador.GetById(OperadorId);
        }

        public MessageReturn Update(Operador operador)
        {
            validateOperador(operador);

            if (msgRetorno.IsValid)
                _repositoryOperador.Update(operador);
            return msgRetorno;

        }

        
        public MessageReturn Create(Operador operador)
        {

            validateOperador(operador);

            if (msgRetorno.IsValid)
                _repositoryOperador.Add(operador);
            
            
            return msgRetorno;
        }

        public void Remove(Operador Operador)
        {
            _repositoryOperador.Remove(Operador);
        }

        public Operador FindByLogin(string login)
        {
            return _repositoryOperador.FindSingle(op => op.Login.ToUpper() == login.ToUpper());
        }

        public Operador FindByCpf(string cpf)
        {
            return _repositoryOperador.FindSingle(op => op.Cpf == cpf);
        }

        public bool Isvalid(string login, string senha)
        {
            Operador operadorExistente = FindByLogin(login);
            if (operadorExistente != null)
            {
                return(login.ToUpper() == operadorExistente?.Login.ToUpper() && senha.ToUpper() == operadorExistente?.Senha.ToUpper());
            }

            return false;
        }

        private void validateOperador(Operador operador)
        {
            if (FindByLogin(operador.Login) != null)
            {
                msgRetorno.AddError("Já existe um usuário com o Login informado");

            }
            if (FindByCpf(operador.Cpf) != null)
            {
                msgRetorno.AddError("Já existe um usuário com o cpf informado");
            }

        }


    }
}