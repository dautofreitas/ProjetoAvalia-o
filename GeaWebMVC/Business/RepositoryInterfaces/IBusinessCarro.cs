using System.Collections.Generic;
using GeaWebMVC.Models;

namespace GeaWebMVC.Business.RepositoryInterfaces
{
    public interface IBusinessCarro
    {
        void Create(Carro Carro);
        IEnumerable<Carro> GetAll();
        Carro GetById(int? CarroId);
        void Update(Carro Carro);
        void Remove(Carro Carro);
        Carro FindByPlaca(string placa);
    }
}