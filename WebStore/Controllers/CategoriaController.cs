using Microsoft.AspNetCore.Mvc;
using WebStore.Datos;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _context.Categorias;
            return View(lista);
        }
        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (!ModelState.IsValid) { return View(categoria); }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0) {  return NotFound(); }

            var obj = _context.Categorias.Find(Id);
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (!ModelState.IsValid) { return View(categoria); }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }

            var obj = _context.Categorias.Find(Id);
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (categoria == null) { return NotFound(); }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
