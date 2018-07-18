using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Models
{
    [NotMapped]
    public class RegistroDeFluxoWihtCarro
    {
        public int? Id { get; set; }
        [Display(Name="Data Entrada")]
        [Required(ErrorMessage = "Favor informar a Data de entrada")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataEntrada { get; set; }
        [Display(Name = "Hora Entrada")]
        [Required(ErrorMessage = "Favor informar a hora de entrada")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime? HoraEntrada { get; set; }
        [Display(Name = "Data Saída")]
        public DateTime? DataSaida { get; set; }
        [Display(Name = "Hora Saída")]
        public DateTime? HoraSaida { get; set; }
        [Required(ErrorMessage = "Favor informar a placa do veículo")]
        [RegularExpression(@"^[a-zA-Z]{3}\d{4}$", ErrorMessage =
                    "Por favor informa um formato de placa válido, Ex:AAA1111")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Favor informar a marca do veículo")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Favor informar o modelo do veículo")]
        public string Modelo { get; set; }

    }
}