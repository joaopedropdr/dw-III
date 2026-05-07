using exercicio_p1.Data;
using exercicio_p1.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace exercicio_p1.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly ContextMongoDb _context;
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinica.Find(_=> true).ToListAsync());
        }
        
        // GET create 
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, Alarme")] Clinica clinica )
        {
            if (ModelState.IsValid)
            {
                await _context.Clinica.InsertOneAsync(clinica);
                return RedirectToAction("Index");
            }
            return View(clinica);
        }
    }
}
