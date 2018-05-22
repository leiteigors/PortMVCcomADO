using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCcomADO.Models
{
    public class Time
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do time")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe a cor do time")]
        public string cores { get; set; }

        [Required(ErrorMessage = "Informe o estado do time")]
        public string estado { get; set; }
    }
}