using System;
using System.Collections.Generic;

namespace GeaWeb.Models
{
    public partial class Operador
    {
        public Operador()
        {
            this.RegistroDeFluxos = new List<RegistroDeFluxo>();
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
