using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPGManager.Models;
using PagedList;

namespace IPGManager.Controllers
{
    public class ProfessoresController : Controller
    {
       
        private readonly IPGManagerDBContext _context;

        public ProfessoresController(IPGManagerDBContext context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index(
      string sortOrder,
      string currentFilter,
      string searchString,
      int? pageNumber)
        {
            PopulateDepartmentDropDownList();
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
            var Professores = _context.Professor
        .Include(c => c.Genero)
        .Include(d => d.Departamento)
        .AsNoTracking();
            //var Professores = from s in _context.Professor
            //             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Professores = Professores.Where(s => s.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    Professores = Professores.OrderBy(s => s.Nome);
                    break;
                case "name_desc":
                    Professores = Professores.OrderByDescending(s => s.Nome);
                    break;
                case "Date":
                    Professores = Professores.OrderBy(s => s.DataNascimento);
                    break;
                case "date_desc":
                    Professores = Professores.OrderByDescending(s => s.DataNascimento);
                    break;
                default:
                    Professores = Professores.OrderBy(s => s.Nome);
                    break;
            }
            int pageSize = 3;
           
            return View(await PaginatedList<Professor>.CreateAsync(Professores.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(c => c.Genero)
        .Include(d => d.Departamento)
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
                
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentQuery = from d in _context.Departamento

                               select d;
            ViewBag.DepartamentoID = new SelectList(departmentQuery.AsNoTracking(), "DepartamentoId", "NomeDepartamento", selectedDepartment);
        }
        private void PopulategendersDropDownList(object selectedGender = null)
        {
            var gendersQuery = from d in _context.Genero
                                   
                                   select d;
            ViewBag.GenderID = new SelectList(gendersQuery.AsNoTracking(), "GeneroId", "GeneroTipo", selectedGender);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            PopulategendersDropDownList();
            PopulateDepartmentDropDownList();
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorId,Nome,Contacto,DataNascimento,GeneroId,DepartamentoId")] Professor professor)
        {

            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(professor);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            PopulategendersDropDownList();
            PopulateDepartmentDropDownList();
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,Nome,Contacto,DataNascimento,GeneroId,DepartamentoId")] Professor professor)
        {
            
            if (id != professor.ProfessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorId))
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
            return View(professor);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(c => c.Genero)
        .Include(d => d.Departamento)
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.ProfessorId == id);
        }
    }
}
