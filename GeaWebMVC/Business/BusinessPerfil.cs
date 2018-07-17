using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessPerfil : IBusinessPerfil
    {

        private readonly IRepositoryPerfil _repositoryPerfil;

        public BusinessPerfil(IRepositoryPerfil repositoryPerfil)
        {
            _repositoryPerfil = repositoryPerfil;
        }


        public IEnumerable<Perfil> GetAll()
        {
            return _repositoryPerfil.GetAll();
        }

        public Perfil GetById(int? PerfilId)
        {
            return _repositoryPerfil.GetById(PerfilId);
        }

        public void Update(Perfil Perfil)
        {
            _repositoryPerfil.Update(Perfil);
        }

        public void Create(Perfil Perfil)
        {
            _repositoryPerfil.Add(Perfil);
        }

        public void Remove(Perfil Perfil)
        {
            _repositoryPerfil.Remove(Perfil);
        }
    }
}