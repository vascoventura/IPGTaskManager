using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPGManager.Models;

namespace IPGManager.Controllers
{
    public class TFCsController : Controller
    {
        private readonly IPGManagerDBContext _context;

        public TFCsController(IPGManagerDBContext context)
        {
            _context = context;
        }

        // GET: TFCs
        public async Task<IActionResult> Index()
        {
            var iPGManagerDBContext = _context.TFC.Include(t => t.Cargo).Include(t => t.Funcionario).Include(t => t.Tarefa);
            return View(await iPGManagerDBContext.ToListAsync());
        }

        // GET: TFCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tFC = await _context.TFC
                .Include(t => t.Cargo)
                .Include(t => t.Funcionario)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.TFCId == id);
            if (tFC == null)
            {
                return NotFound();
            }

            return View(tFC);
        }

        // GET: TFCs/Create
        public IActionResult Create()
        {
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "NomeTarefa");
            return View();
        }

        // POST: TFCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TFCId,CargoID,FuncionarioId,TarefaId")] TFC tFC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tFC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo", tFC.CargoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tFC.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "NomeTarefa", tFC.TarefaId);
            return View(tFC);
        }

        // GET: TFCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tFC = await _context.TFC.FindAsync(id);
            if (tFC == null)
            {
                return NotFound();
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo", tFC.CargoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tFC.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "NomeTarefa", tFC.TarefaId);
            return View(tFC);
        }

        // POST: TFCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TFCId,CargoID,FuncionarioId,TarefaId")] TFC tFC)
        {
            if (id != tFC.TFCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tFC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TFCExists(tFC.TFCId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo", tFC.CargoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tFC.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "NomeTarefa", tFC.TarefaId);
            return View(tFC);
        }

        // GET: TFCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tFC = await _context.TFC
                .Include(t => t.Cargo)
                .Include(t => t.Funcionario)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.TFCId == id);
            if (tFC == null)
            {
                return NotFound();
            }

            return View(tFC);
        }

        // POST: TFCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tFC = await _context.TFC.FindAsync(id);
            _context.TFC.Remove(tFC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TFCExists(int id)
        {
            return _context.TFC.Any(e => e.TFCId == id);
        }

        public IActionResult CascadingDropDownList()
        {
            ViewData["CargoID"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            return View();
        }

        public JsonResult Cascading_Get_Cargos()
        {
            return Json(_context.Cargo.Select(c => new { CargoId = c.CargoId, CargoName = c.NomeCargo}));
        }

        public JsonResult Cascading_Get_Func(int? cargos)
        {
           
            var funcionarios = _context.Funcionario.AsQueryable();

            if (cargos != null)
            {
                funcionarios = funcionarios.Where(p => p.CargoId == cargos);
            }

            return Json(funcionarios.Select(p => new { FuncionarioId = p.FuncionarioId, FuncionarioName = p.Nome }));
        }

        public JsonResult Cascading_Get_Tar(int? cargos)
        {

            var tarefas = _context.Tarefa.AsQueryable();

            if (cargos != null)
            {
                tarefas = tarefas.Where(p => p.CargoId == cargos);
            }

            return Json(tarefas.Select(p => new { TarefaId = p.TarefaId, TarefaName = p.NomeTarefa }));
        }

    }
}
