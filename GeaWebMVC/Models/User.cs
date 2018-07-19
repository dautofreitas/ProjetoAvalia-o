using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Models
{
    public class User
    {
        [Required(ErrorMessage ="Favor informar o login")]
        
        [RegularExpression(@"^[a-zA-Z].+$", ErrorMessage =
            "Por favor informa apenas letras")]
        [StringLength(30, ErrorMessage = "O senha deve conter no máximo 20 digitos")]
        public string Login { get; set; }
        [StringLength(15, ErrorMessage = "O senha deve conter no máximo 15 digitos")]
        [Required(ErrorMessage = "Favor informar a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}