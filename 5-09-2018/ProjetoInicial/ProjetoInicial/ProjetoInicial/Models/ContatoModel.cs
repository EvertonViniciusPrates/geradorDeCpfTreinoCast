using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoInicial.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [DisplayName("Tipo do Contato")]
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Contato { get; set; }
    }
}