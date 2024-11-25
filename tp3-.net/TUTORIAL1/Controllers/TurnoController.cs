using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TUTORIAL1.Context;
using TUTORIAL1.Models;

namespace TUTORIAL1.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnoDbContext _context;

        public TurnoController(TurnoDbContext context)
        {
            _context = context;
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
            var turnoDbContext = _context.Turnos.Include(t => t.Medico).Include(t => t.Paciente);
            return View(await turnoDbContext.ToListAsync());
        }

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }



        // GET: Turno/Create
        public IActionResult Create()
        {
            if (TempData["EspecialidadSeleccionada"] == null)
            {
                return RedirectToAction("SelectEspecialidad");
            }
            Especialidad especialidadSeleccionada = (Especialidad)TempData["EspecialidadSeleccionada"];

            if (especialidadSeleccionada != null)
            {
                ViewData["MedicoNombre"] = new SelectList(_context.Medicos
                    .Where(m => m.Especialidad == especialidadSeleccionada), "Id", "NombreCompleto");
            }
            else
            {
                ViewData["MedicoNombre"] = new SelectList(_context.Medicos, "Id", "NombreCompleto");
            }
            ViewData["PacienteNombre"] = new SelectList(_context.Pacientes, "Id", "NombreCompleto");
            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaHora,MedicoId,PacienteId")] Turno turno)
        {
            ModelState.Remove("Medico");
            ModelState.Remove("Paciente");
            if (!ModelState.IsValid)
            {

                ViewData["MedicoId"] = new SelectList(_context.Medicos.ToList(), "Id", "NombreCompleto", turno.MedicoId);
                ViewData["PacienteId"] = new SelectList(_context.Pacientes.ToList(), "Id", "NombreCompleto", turno.PacienteId);
                return View(turno);
            }

            _context.Add(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["MedicoNombre"] = new SelectList(_context.Medicos, "Id", "NombreCompleto", turno.MedicoId);
            ViewData["PacienteNombre"] = new SelectList(_context.Pacientes, "Id", "NombreCompleto", turno.PacienteId);

            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,MedicoId,PacienteId")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Medico");
            ModelState.Remove("Paciente");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
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
            ViewData["MedicoNombre"] = new SelectList(_context.Medicos, "Id", "NombreCompleto", turno.MedicoId);
            ViewData["PacienteNombre"] = new SelectList(_context.Pacientes, "Id", "NombreCompleto", turno.PacienteId);

            return View(turno);
        }


        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }
        public async Task<IActionResult> TurnosPorPaciente(int id)
        {
      
            var turnos = await _context.Turnos.Include(t => t.Medico).Include(t => t.Paciente)
                .Where(t => t.PacienteId == id) 
                .OrderBy(t => t.FechaHora) 
                .ToListAsync();

            if (!turnos.Any())
            {
                ViewBag.ErrorMessage = "No se encontraron turnos para este paciente.";
            }

            return View(turnos); 
        }
        public IActionResult SelectEspecialidad()
        {
            var especialidades = Enum.GetValues(typeof(Especialidad)).Cast<Especialidad>();
            ViewBag.Especialidades = new SelectList(especialidades);
            return View();
        }

        // POST: Turno/FilterByEspecialidad
        [HttpPost]
        public IActionResult FilterByEspecialidad(Especialidad especialidad)
        {
            // Guardar la especialidad seleccionada en TempData para usarla en el método Create
            TempData["EspecialidadSeleccionada"] = especialidad;
            return RedirectToAction("Create");
        }

    }
}

