using MundiUtil.WEB.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MundiUtil.WEB.Models.Abstract
{
    public interface ITInsumosBusiness
    {
        Task<IEnumerable<InsumoDto>> ObtenerInsumosTodos();
        void GuardarInsumo(GuardarInsumoDto guardarInsumoDto);
        Task<bool> GuardarCambios();
        Task<GuardarInsumoDto> ObtenerInsumosPorId(int? id);
        void EditarInsumo(GuardarInsumoDto guardarInsumoDto);
        void EliminarInsumo(GuardarInsumoDto guardarInsumoDto);
    }
}
