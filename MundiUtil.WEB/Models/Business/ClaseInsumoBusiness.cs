using Microsoft.EntityFrameworkCore;
using MundiUtil.WEB.Dtos;
using MundiUtil.WEB.Models.Abstract;
using MundiUtil.WEB.Models.DAL;
using MundiUtil.WEB.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MundiUtil.WEB.Models.Business
{
    public class ClaseInsumoBusiness : IClaseInsumoBusiness
    {
        private readonly AppDbContext _context;
        public ClaseInsumoBusiness(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<ClaseInsumoDto>> ObtenerTodaListaInsumos()
        {
            List<ClaseInsumo> listaTipoInsumo = new();
            List<ClaseInsumoDto> ListaTipoInsumoDto = new();
            listaTipoInsumo = await _context.clases.OrderBy(x => x.TipoInsumo).ToListAsync();


            foreach (var c in listaTipoInsumo)
            {
                ClaseInsumoDto claseInsumo = new()
                {
                    IdTipoInsumo = c.IdTipoInsumo,
                    TipoInsumo = c.TipoInsumo,

                };
                ListaTipoInsumoDto.Add(claseInsumo);
            } 
            return ListaTipoInsumoDto;
        }
    }
    
}
