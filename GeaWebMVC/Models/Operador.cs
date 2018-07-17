using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeaWebMVC.Models
{
    public partial class Operador
    {
        public Operador()
        {
            this.RegistroDeFluxos = new List<RegistroDeFluxo>();
        }
        [Required]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"^[0-9].+$", ErrorMessage =
            "Por favor informa apenas números")]        
        [StringLength(11,MinimumLength =11,ErrorMessage = "O CPF deve conter 11 Digitos")]
        public string Cpf { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        public int EmpresaId { get; set; }
        public int? Id { get; set; }
        [Required]
        public int PerfilId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
