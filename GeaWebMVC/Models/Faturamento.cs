using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeaWebMVC.Models
{
    public partial class Faturamento
    {
        public Faturamento()
        {
            this.RegistroDeFluxos = new List<RegistroDeFluxo>();
        }

        public int? EmpresaId { get; set; }
        public int? Id { get; set; }
        
        [Display(Name = "Data da Competencia")]        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]       
        public DateTime DataCompetencia { get; set; }              
        
        [Display(Name = "Data de Pagamento")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime? DataPagamento { get; set; }
        [Display(Name = "Valor da Competencia")]
        [DataType(DataType.Currency)]
        public double? ValorCompetencia { get; set; }
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public double? Valor { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
