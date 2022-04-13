using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MundiUtil.WEB.Models.Entities
{
    public class ClaseInsumo
    {
        [Key]

        public int IdTipoInsumo { get; set; }
        [Column("Tipo Insumo", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TipoInsumo { get; set; }


    }
}
