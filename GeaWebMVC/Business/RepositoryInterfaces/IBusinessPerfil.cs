using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessPerfil
    {
        void Create(Perfil Perfil);
        IEnumerable<Perfil> GetAll();
        Perfil GetById(int? PerfilId);
        void Update(Perfil Perfil);
        void Remove(Perfil Perfil);
    }
}