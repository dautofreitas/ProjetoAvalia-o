using System;
using System.Collections.Generic;

namespace GeaWebMVC.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            this.Faturamentos = new List<Faturamento>();
            this.Operadores = new List<Operador>();
        }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Faturamento> Faturamentos { get; set; }
        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
