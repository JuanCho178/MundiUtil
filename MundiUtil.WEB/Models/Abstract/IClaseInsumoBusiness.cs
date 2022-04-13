using MundiUtil.WEB.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MundiUtil.WEB.Models.Abstract
{
    public interface IClaseInsumoBusiness
    {
        Task<IEnumerable<ClaseInsumoDto>> ObtenerTodaListaInsumos();
    }
}
