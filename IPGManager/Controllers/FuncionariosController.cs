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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
                                               string searchString,
                                               int? pageNumber){


            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CargoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "cargo" : "";
            ViewData["CurrentFilter"] = searchString; //string de pesquisa

            //Paginacao
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }





            /*var funcionario = _context.Funcionario.Include(f => f.Cargo).Include(f => f.Horario);
                return View(await funcionario.ToListAsync());*/

            var funcionarios = from s in _context.Funcionario.Include(s => s.Cargo).Include(s => s.Horario)
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                funcionarios = funcionarios.Where(s => s.Nome.Contains(searchString));                                   
            }


            

            switch (sortOrder)
            {
                case "name_desc":
                    funcionarios = funcionarios.OrderByDescending(s => s.Nome);
                    break;
                case "cargo":
                    funcionarios = funcionarios.OrderBy(s => s.Cargo);
                    break;
                default:
                    funcionarios = funcionarios.OrderBy(s => s.Nome);
                    break;
            }
       
                    int pageSize = 3;
                    return View(await PaginatedList<Funcionario>.CreateAsync(funcionarios.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Cargo)
                .Include(f => f.Horario)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HInicio");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Contacto,DataNascimento,Genero,CargoId,HorarioId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descricao", funcionario.CargoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioId", funcionario.HorarioId);
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo", funcionario.CargoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioId", funcionario.HorarioId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Contacto,DataNascimento,Genero,CargoId,HorarioId")] Funcionario funcionario)
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo", funcionario.CargoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioId", funcionario.HorarioId);
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
                .Include(f => f.Horario)
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
