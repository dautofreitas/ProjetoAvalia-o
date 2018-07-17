using System;
using System.Collections.Generic;

namespace GeaWebMVC.Models
{
    public partial class Carro
    {
        public Carro()
        {
            this.RegistroDeFluxos = new List<RegistroDeFluxo>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
