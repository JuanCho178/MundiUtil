using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MundiUtil.WEB.Models.Entities
{
    public class Insumo
    {

        [Key]
        public int IdInsumos { get; set; }

        [DisplayName("Nombre de Insumo")]
        [Column("NombreInsumo", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [DisplayName("Cantida por Kilo")]
        [Required(ErrorMessage = "Este campo es obligatorio")]

        public int Cantidad { get; set; }
        [DisplayName("Referencia de Insumo")]
        [Required(ErrorMessage = "Este campo es obligatorio")]

        public int ReferenciaInsumo { get; set; }
        [DisplayName("Tipo de Insumo")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int TipoInsumo { get; set; }
    }
}
