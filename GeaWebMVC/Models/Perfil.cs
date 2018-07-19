using System;
using System.Collections.Generic;

namespace GeaWebMVC.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            this.Operadores = new List<Operador>();
        }

        public string Tipo { get; set; }
        public int? Id { get; set; }
        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
