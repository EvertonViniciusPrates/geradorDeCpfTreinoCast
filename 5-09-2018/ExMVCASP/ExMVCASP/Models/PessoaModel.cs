using ExMVCASP.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExMVCASP.Models
{
    public class PessoaModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [DisplayName]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        public EnumDropDownListFor sexo { get; set; }
    }
}