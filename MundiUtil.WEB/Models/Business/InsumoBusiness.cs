using MundiUtil.WEB.Dtos;
using MundiUtil.WEB.Models.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MundiUtil.WEB.Models.Abstract;
using System;
using MundiUtil.WEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MundiUtil.WEB.Models.Business
{
    public class InsumoBusiness : ITInsumosBusiness
    {
        private readonly AppDbContext _context;
        public InsumoBusiness(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<InsumoDto>> ObtenerInsumosTodos()
        {
            //return await _context.Empleados.ToListAsync();

            await using (_context)
            {
                IEnumerable<InsumoDto> listaInsumo =
                (from insumos in _context.insumo
                 join tipos in _context.clases
                 on insumos.TipoInsumo equals
                 tipos.IdTipoInsumo
                 select new InsumoDto
                 {
                     IdInsumos = insumos.IdInsumos,
                     Nombre = insumos.Nombre,
                     TipoInsumo = tipos.TipoInsumo,
                     Cantidad = insumos.Cantidad,
                     ReferenciaInsumo = insumos.ReferenciaInsumo


                 }).ToList();
                return listaInsumo;
            }
        }


        public void GuardarInsumo(GuardarInsumoDto guardarInsumoDto)
        {
            if (guardarInsumoDto == null)
            {
                throw new ArgumentNullException(nameof(guardarInsumoDto));
            }
            Insumo  insumo = new()
            {
                Nombre = guardarInsumoDto.Nombre,
                TipoInsumo = guardarInsumoDto.TipoInsumo,
                Cantidad = guardarInsumoDto.Cantidad,
                ReferenciaInsumo = guardarInsumoDto.ReferenciaInsumo,
                IdInsumos = guardarInsumoDto.IdInsumos

            };
            _context.Add(insumo);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<GuardarInsumoDto> ObtenerInsumosPorId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var insumo = await _context.insumo.AsNoTracking().FirstOrDefaultAsync(x => x.IdInsumos == id);
            //var facultad = await _context.Facultades.FirstOrDefaultAsync(x => x.FacultadId == id);
            if (insumo != null)
            {
                GuardarInsumoDto guardarInsumoDto = new()
                {
                    IdInsumos = insumo.IdInsumos,
                    Nombre = insumo.Nombre,
                    TipoInsumo = insumo.TipoInsumo,
                    Cantidad = insumo.Cantidad,
                    ReferenciaInsumo = insumo.ReferenciaInsumo,

                };
                return guardarInsumoDto;
            }
            return null;

        }

        public void EditarInsumo(GuardarInsumoDto guardarInsumoDto)
        {
            if (guardarInsumoDto == null)
            {
                throw new ArgumentNullException(nameof(guardarInsumoDto));
            }
            Insumo insumo = new()
            {
                Nombre = guardarInsumoDto.Nombre,
                TipoInsumo = guardarInsumoDto.TipoInsumo,
                Cantidad = guardarInsumoDto.Cantidad,
                ReferenciaInsumo = guardarInsumoDto.ReferenciaInsumo,
                IdInsumos = guardarInsumoDto.IdInsumos

            };
            _context.Update(insumo);
        }

        public void EliminarInsumo(GuardarInsumoDto guardarInsumoDto)
        {
            if (guardarInsumoDto == null)
            {
                throw new ArgumentNullException(nameof(guardarInsumoDto));
            }
            Insumo insumo = new()
            {
                Nombre = guardarInsumoDto.Nombre,
                TipoInsumo = guardarInsumoDto.TipoInsumo,
                Cantidad = guardarInsumoDto.Cantidad,
                ReferenciaInsumo = guardarInsumoDto.ReferenciaInsumo,
                IdInsumos = guardarInsumoDto.IdInsumos

            };
            _context.Remove(insumo);
        }
    }
    
}
