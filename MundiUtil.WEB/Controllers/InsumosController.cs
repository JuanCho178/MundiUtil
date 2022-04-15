using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MundiUtil.WEB.Dtos;
using MundiUtil.WEB.Models.Abstract;
using MundiUtil.WEB.Models.DAL;
using MundiUtil.WEB.Models.Entities;

namespace MundiUtil.WEB.Controllers
{
    public class InsumosController : Controller
    {
        private readonly ITInsumosBusiness _insumoBusiness;
        private readonly IClaseInsumoBusiness _claseInsumoBusiness;
        public InsumosController(ITInsumosBusiness insumoBusiness, IClaseInsumoBusiness claseInsumoBusiness)
        {
            _insumoBusiness = insumoBusiness;
            _claseInsumoBusiness = claseInsumoBusiness;
        }

        // GET: Insumos
        public async Task<IActionResult> Index()
        {
            //return View(await _context.insumo.ToListAsync());
            var listaInsumo = await _insumoBusiness.ObtenerInsumosTodos();
            return View(listaInsumo);
        }

        // GET: Insumos/Create
        public async Task<IActionResult> Create() // Este Metodo Sirve Para Crear el Insumo
        {
            ViewData["ListaTipoInsumo"] = new SelectList(await _claseInsumoBusiness.ObtenerTodaListaInsumos(), "IdTipoInsumo", "TipoInsumo");
            return View();
        }

        // POST: Insumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInsumos,Nombre,Cantidad,ReferenciaInsumo,TipoInsumo")] GuardarInsumoDto guardarInsumoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _insumoBusiness.GuardarInsumo(guardarInsumoDto);
                    var respuesta = await _insumoBusiness.GuardarCambios();
                    if (respuesta)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(guardarInsumoDto);

        }

        // GET: Insumos/Edit/5
        public async Task<IActionResult> Edit(int? id) // Este Metodo Sirve Para Editar Los Insumos.
        {
            if (id != null)
            {
                try
                {
                    var insumosDto = await _insumoBusiness.ObtenerInsumosPorId(id.Value);
                    ViewData["ListaTipoInsumo"] = new SelectList(await _claseInsumoBusiness.ObtenerTodaListaInsumos(), "IdTipoInsumo", "TipoInsumo", insumosDto.TipoInsumo); // Lista de Los TIpos de Insumos Registrados en la BD..
                    if (insumosDto == null)
                        return View("Index");
                    return View(insumosDto);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View("Index");
        }

        //// POST: Insumos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInsumos,Nombre,Cantidad,ReferenciaInsumo,TipoInsumo")] GuardarInsumoDto guardarInsumoDto) // Este Metodo Guardara el Insumo Editado
        {
            if (id != guardarInsumoDto.IdInsumos)
            {
                return View(guardarInsumoDto);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _insumoBusiness.EditarInsumo(guardarInsumoDto);
                    var guardarEmpleado = await _insumoBusiness.GuardarCambios();
                    if (guardarEmpleado)
                        return RedirectToAction("Index");
                    else
                        return View(guardarInsumoDto);

                }
                catch (Exception)
                {
                    return View(guardarInsumoDto);
                }

            }
            return View(guardarInsumoDto);
        }

        // GET: Insumos/Details/5
        public async Task<IActionResult> Details(int? id) // Este Metodo mostara toda la Informacion del Insumo...
        {
            if (id != null)
            {
                try
                {
                    var insumo = await _insumoBusiness.ObtenerInsumosPorId(id.Value);
                    if (insumo == null)
                    {
                        return RedirectToAction("Index");
                    }

                    return View(insumo);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

        //// POST: Insumos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ? id) // Este Metodo Permite Eliminar el Insumo Registrado o Editado...
        {
            try
            {
                var insumo = await _insumoBusiness.ObtenerInsumosPorId(id.Value);
                if (insumo == null)
                    return RedirectToAction("Index");
                _insumoBusiness.EliminarInsumo(insumo);
                var eliminarEmpleado = await _insumoBusiness.GuardarCambios();
                if (eliminarEmpleado)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
