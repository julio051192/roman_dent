using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using romandent.Models;

namespace romandent.Controllers
{
    public class CitasController : Controller
    {
        private readonly RomanDentContext _context;

        // Constructor que recibe el contexto de la base de datos
        public CitasController(RomanDentContext context)
        {
            _context = context;
        }

        // GET: /Citas
        // GET: /Citas/Index
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestión de Citas";

            // Por ahora solo mostramos un mensaje
            // Más adelante cargaremos las citas de la base de datos
            return View();
        }

        // GET: /Citas/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Nueva Cita";
            return View();
        }

        // POST: /Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            // Por ahora solo redirigimos
            TempData["Message"] = "Función de crear cita en desarrollo";
            return RedirectToAction(nameof(Index));
        }

        // Método para probar conexión
        public string Test()
        {
            return "Controlador de Citas funcionando correctamente ✅";
        }
    }
}