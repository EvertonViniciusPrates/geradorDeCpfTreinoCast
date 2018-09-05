using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoInicial.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Tipo")]
        public string Type { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}