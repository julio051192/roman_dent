using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using romandent.Models;

namespace romandent.Controllers
{
    public class PacientesController : Controller
    {
        private readonly RomanDentContext _context;

        public PacientesController(RomanDentContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var pacientes = await _context.Pacientes
                .Where(p => p.Activo == true)
                .OrderBy(p => p.Apellidos)
                .ThenBy(p => p.Nombres)
                .ToListAsync();

            return View(pacientes);
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.IdPaciente == id);

            if (paciente == null) return NotFound();

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                // Generar historia clínica automática
                var count = await _context.Pacientes.CountAsync();
                paciente.NumeroHistoriaClinica = $"HC-{DateTime.Now.Year}-{(count + 1):D4}";
                paciente.Activo = true;
                paciente.FechaRegistro = DateTime.Now;

                _context.Add(paciente);
                await _context.SaveChangesAsync();

                TempData["Success"] = "✅ Paciente registrado exitosamente";
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();

            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (id != paciente.IdPaciente) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "✅ Paciente actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PacienteExists(paciente.IdPaciente))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.IdPaciente == id);

            if (paciente == null) return NotFound();

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                // Desactivar en vez de eliminar físicamente
                paciente.Activo = false;
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                TempData["Success"] = "✅ Paciente desactivado exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar
        private async Task<bool> PacienteExists(int id)
        {
            return await _context.Pacientes.AnyAsync(e => e.IdPaciente == id);
        }

        // Búsqueda de pacientes
        public async Task<IActionResult> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return RedirectToAction(nameof(Index));

            var pacientes = await _context.Pacientes
                .Where(p => p.Activo == true &&
                    (p.Nombres.Contains(termino) ||
                     p.Apellidos.Contains(termino) ||
                     p.DocumentoIdentidad.Contains(termino) ||
                     (p.NumeroHistoriaClinica != null && p.NumeroHistoriaClinica.Contains(termino))))
                .OrderBy(p => p.Apellidos)
                .ToListAsync();

            ViewBag.Termino = termino;
            return View("Index", pacientes);
        }
    }
}

