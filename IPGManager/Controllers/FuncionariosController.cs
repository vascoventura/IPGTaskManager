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
    public class FuncionariosController : Controller
    {
        private readonly IPGManagerDBContext _context;

        public FuncionariosController(IPGManagerDBContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var Funcionarios = from s in _context.Funcionario
                              select s;

            if (!String.IsNullOrEmpty(searchString))
    {
                 Funcionarios = Funcionarios.Where(s => s.Nome.Contains(searchString)
                               || s.Apelido.Contains(searchString));
    }
            switch (sortOrder)
            {
                case "name_desc":
                    Funcionarios = Funcionarios.OrderByDescending(s => s.Apelido);
                    break;
                case "Date":
                    Funcionarios = Funcionarios.OrderBy(s => s.DataNascimento);
                    break;
                case "date_desc":
                    Funcionarios = Funcionarios.OrderByDescending(s => s.DataNascimento);
                    break;
                default:
                    Funcionarios = Funcionarios.OrderBy(s => s.Nome);
                    break;
            }
            int pageSize = 3;

            return View(await PaginatedList<Funcionario>.CreateAsync(Funcionarios.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descricao");
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "NomeDepartamento");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Apelido,Contacto,DataNascimento,Genero,CargoId,DepartamentoId,HorarioId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descricao", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "NomeDepartamento", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descricao", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "NomeDepartamento", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Apelido,Contacto,DataNascimento,Genero,CargoId,DepartamentoId,HorarioId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descricao", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "NomeDepartamento", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Cargo)
                .Include(f => f.Departamento)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioId == id);
        }
    }
}
