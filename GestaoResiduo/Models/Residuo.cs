using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoResiduo.Models
{
    public class Residuo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduo { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }

}
