using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeaWebMVC.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            this.Faturamentos = new List<Faturamento>();
            this.Operadores = new List<Operador>();
        }
        [Required(ErrorMessage = "Favor informar o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Favor informar o CNPJ")]
        [RegularExpression(@"^[0-9].+$", ErrorMessage =
            "Por favor informa apenas números")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter 14 Digitos")]      
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Favor informar a E-mail")]
        public string Email { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Faturamento> Faturamentos { get; set; }
        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
