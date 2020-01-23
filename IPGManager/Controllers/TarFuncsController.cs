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
    public class TarFuncsController : Controller
    {
        private readonly IPGManagerDBContext _context;

        public TarFuncsController(IPGManagerDBContext context)
        {
            _context = context;
        }

        // GET: TarFuncs
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            

            var TarFuncs = _context.TarFunc
        .Include(c => c.Tarefa)
        .Include(d => d.Funcionario)
        .AsNoTracking();


            if (!String.IsNullOrEmpty(searchString))
            {
                TarFuncs = TarFuncs.Where(s => s.Funcionario.Nome.Contains(searchString));
            }

            int pageSize = 5;

            return View(await PaginatedList<TarFunc>.CreateAsync(TarFuncs.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: TarFuncs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarFunc = await _context.TarFunc
                .Include(t => t.Funcionario)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.TarFuncId == id);
            if (tarFunc == null)
            {
                return NotFound();
            }

            return View(tarFunc);
        }

        // GET: TarFuncs/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "DescricaoTarefa");
            return View();
        }

        // POST: TarFuncs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarFuncId,FuncionarioId,TarefaId")] TarFunc tarFunc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarFunc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarFunc.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "DescricaoTarefa", tarFunc.TarefaId);
            return View(tarFunc);
        }

        // GET: TarFuncs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarFunc = await _context.TarFunc.FindAsync(id);
            if (tarFunc == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarFunc.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "DescricaoTarefa", tarFunc.TarefaId);
            return View(tarFunc);
        }

        // POST: TarFuncs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarFuncId,FuncionarioId,TarefaId")] TarFunc tarFunc)
        {
            if (id != tarFunc.TarFuncId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarFunc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarFuncExists(tarFunc.TarFuncId))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarFunc.FuncionarioId);
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "TarefaId", "DescricaoTarefa", tarFunc.TarefaId);
            return View(tarFunc);
        }

        // GET: TarFuncs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarFunc = await _context.TarFunc
                .Include(t => t.Funcionario)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.TarFuncId == id);
            if (tarFunc == null)
            {
                return NotFound();
            }

            return View(tarFunc);
        }

        // POST: TarFuncs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarFunc = await _context.TarFunc.FindAsync(id);
            _context.TarFunc.Remove(tarFunc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarFuncExists(int id)
        {
            return _context.TarFunc.Any(e => e.TarFuncId == id);
        }
    }
}
