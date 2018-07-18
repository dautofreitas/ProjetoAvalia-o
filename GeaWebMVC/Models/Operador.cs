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
        [Required(ErrorMessage = "Favor informar o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Favor informar o CPF")]
        [RegularExpression(@"^[0-9].+$", ErrorMessage =
            "Por favor informa apenas números")]        
        [StringLength(11,MinimumLength =11,ErrorMessage = "O CPF deve conter 11 Digitos")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Favor informar o login")]
        [StringLength(20, ErrorMessage = "O senha deve conter no máximo 20 digitos")]
        public string Login { get; set; }
        [StringLength(15, ErrorMessage = "O senha deve conter no máximo 15 digitos")]
        [Required(ErrorMessage = "Favor informar a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Favor Selecionar a Empresa")]
        public int EmpresaId { get; set; }
        public int? Id { get; set; }
        [Required(ErrorMessage = "Favor selecionar o perfil")]
        public int PerfilId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<RegistroDeFluxo> RegistroDeFluxos { get; set; }
    }
}
