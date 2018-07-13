using System;
using System.Collections.Generic;

namespace GeaWeb.Models
{
    public partial class RegistroDeFluxo
    {
        public int? FaturamentoId { get; set; }
        public int? OperadorId { get; set; }
        public int? CarroId { get; set; }
        public int? Id { get; set; }
        public DateTime? DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public decimal? ValorAPagar { get; set; }
        public virtual Carro Carro { get; set; }
        public virtual Faturamento Faturamento { get; set; }
        public virtual Operador Operador { get; set; }
    }
}
