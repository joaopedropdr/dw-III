using exercicio_preparatorio.Data;
using exercicio_preparatorio.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace exercicio_preparatorio.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly ContextMongoDb _context;
        // Precisa criar um construtor para injetar o ContextMongoDb
        public ClinicaController(ContextMongoDb context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinica.Find(_ => true).ToListAsync());
        }

        // GET create 
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                await _context.Clinica.InsertOneAsync(clinica);
                return RedirectToAction("Index");
            }
            return View(clinica);
        }

        // GET Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clinica = await _context.Clinica.Find(c => c.Id == id).FirstOrDefaultAsync();
            if (clinica == null)
            {
                return NotFound();
            }
            return View(clinica);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id, Nome")] Clinica clinica)
        {
            if(id != clinica.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Clinica.ReplaceOneAsync(c => c.Id == id, clinica);
                }
                catch (Exception ex) 
                {
                    if(!await ClinicaExists(clinica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(clinica);
        }

        //get delete
        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var clinica = await _context.Clinica.Find(c => c.Id == id).FirstOrDefaultAsync();
            if(clinica == null)
            {
                return NotFound();
            }
            return View(clinica);
        }

        // Post delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _context.Clinica.DeleteOneAsync(c => c.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AtivarAlarme(string id)
        {
            if(id == null)
            {
                return View();
            }
            // Salva o filtro se o id for igual ao id da clinica, e o update seta o alarme como true
            var filter = Builders<Clinica>.Filter.Eq(c => c.Id, id);
            var update = Builders<Clinica>.Update.Set(c => c.Alarme, true);
            await _context.Clinica.UpdateOneAsync(filter, update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DesativarAlarme(string id)
        {
            var filter = Builders<Clinica>.Filter.Eq(c => c.Id, id);
            var update = Builders<Clinica>.Update.Set(c => c.Alarme, false);
            await _context.Clinica.UpdateOneAsync(filter, update);
            return RedirectToAction("Index");
        }

        private async Task<bool> ClinicaExists(string id)
        {
            return await _context.Clinica.Find(e => e.Id == id).AnyAsync();
        }
    }
}
