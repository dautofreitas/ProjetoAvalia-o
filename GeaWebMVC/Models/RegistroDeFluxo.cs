using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeaWebMVC.Models
{
    public partial class RegistroDeFluxo
    {
        public int? FaturamentoId { get; set; }
        public int? OperadorId { get; set; }
        public int? CarroId { get; set; }
        public int? Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataEntrada { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? HoraEntrada { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataSaida { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? HoraSaida { get; set; }
        public double? ValorAPagar { get; set; }
        public virtual Carro Carro { get; set; }
        public virtual Faturamento Faturamento { get; set; }
        public virtual Operador Operador { get; set; }
    }
}
