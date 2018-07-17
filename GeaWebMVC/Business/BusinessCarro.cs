using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessCarro : IBusinessCarro
    {
        private readonly IRepositoryCarro _repositoryCarro;

        public BusinessCarro(IRepositoryCarro repositoryCarro)
        {
            _repositoryCarro = repositoryCarro;
        }


        public IEnumerable<Carro> GetAll()
        {
            return _repositoryCarro.GetAll();
        }

        public Carro GetById(int? carroId)
        {
            return _repositoryCarro.GetById(carroId);
        }

        public void Update(Carro Carro)
        {
            _repositoryCarro.Update(Carro);
        }

        public void Create(Carro Carro)
        {
            _repositoryCarro.Add(Carro);
        }

        public void Remove(Carro carro)
        {
            _repositoryCarro.Remove(carro);
        }

        public Carro FindByPlaca(string placa)
        {
            return _repositoryCarro.FindSingle(c => c.Placa == placa.ToUpper());
        }
    }
}