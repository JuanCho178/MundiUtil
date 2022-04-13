using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MundiUtil.WEB.Dtos
{
    public class GuardarInsumoDto
    {

        public int IdInsumos { get; set; }
        [DisplayName("Nombre de Insumo")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [DisplayName("Cantidad Por Kilo")]
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
