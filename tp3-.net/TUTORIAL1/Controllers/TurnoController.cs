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


                RefrescarLista(turno);

                return View(turno);
                
            }
            if (!IsFechaValida(turno.FechaHora))
            {
                ViewBag.ErrorMessage = "La fecha debe ser mayor al día de hoy y no puede exceder un año.";
                RefrescarLista(turno);

                return View(turno);

            }
            if (!DentroHorarioLaboral(turno.FechaHora))
            {
                ViewBag.ErrorMessage = "El horario debe estar dentro de las horas laborales (8:00 a 16:00).";
                RefrescarLista(turno);

                return View(turno);
            }
            if (TurnoNoDisponible(turno.MedicoId, turno.FechaHora))
            {
                ViewBag.ErrorMessage = "El médico no está disponible.";
                RefrescarLista(turno);
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
            RefrescarLista(turno);


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
                if (!IsFechaValida(turno.FechaHora))
                {
                    ViewBag.ErrorMessage = "La fecha debe ser mayor al día de hoy y no puede exceder un año.";
                    RefrescarLista(turno);

                    return View(turno);

                }
                if (!DentroHorarioLaboral(turno.FechaHora))
                {
                    ViewBag.ErrorMessage = "El horario debe estar dentro de las horas laborales (8:00 a 16:00).";
                    RefrescarLista(turno);

                    return View(turno);
                }
                if (TurnoNoDisponible(turno.MedicoId, turno.FechaHora))
                {
                    ViewBag.ErrorMessage = "El médico no está disponible.";
                    RefrescarLista(turno);
                    return View(turno);
                }
                else 
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
            }
            RefrescarLista(turno);
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
            TempData["EspecialidadSeleccionada"] = especialidad;
            return RedirectToAction("Create");
        }
        private bool IsFechaValida(DateTime fecha)
        {
            var fechaActual = DateTime.Now;
            return fecha > fechaActual && fecha <= fechaActual.AddYears(1);
        }
        private bool DentroHorarioLaboral(DateTime fechaHora)
        {
            TimeSpan horaInicio = new TimeSpan(8, 0, 0); 
            TimeSpan horaFin = new TimeSpan(16, 0, 0);   
            TimeSpan horaTurno = fechaHora.TimeOfDay;
            return horaTurno >= horaInicio && horaTurno <= horaFin;
        }

        private void RefrescarLista(Turno turno)
        {
            ViewData["MedicoNombre"] = new SelectList(_context.Medicos, "Id", "NombreCompleto", turno.MedicoId);
            ViewData["PacienteNombre"] = new SelectList(_context.Pacientes, "Id", "NombreCompleto", turno.PacienteId);
        }
        // el médico puede agendar turnos dentro de una hora
        private bool TurnoNoDisponible(int medicoId, DateTime fechaHora)
        {
            TimeSpan duracionTurno = TimeSpan.FromHours(1);

            DateTime inicioRango = fechaHora;
            DateTime finRango = fechaHora.Add(duracionTurno);

            return _context.Turnos.Any(t =>
                t.MedicoId == medicoId &&
                (t.FechaHora >= inicioRango && t.FechaHora < finRango ||
                 t.FechaHora >= inicioRango.Add(-duracionTurno) && t.FechaHora < finRango));
        }

    }

}

