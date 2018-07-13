using System;
using System.Collections.Generic;

namespace GeaWeb.Models
{
    public partial class Faturamento
    {
        public Faturamento()
        {
            this.RegistroDeFluxos = new List<RegistroDeFluxo>();
        }

        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public DateTime DataCompetencia { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal? ValorCompetencia { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
