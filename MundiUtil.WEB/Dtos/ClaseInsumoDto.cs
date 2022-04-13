using System.ComponentModel.DataAnnotations;

namespace MundiUtil.WEB.Dtos
{
    public class ClaseInsumoDto
    {
        public int IdTipoInsumo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TipoInsumo { get; set; }

    }
}
