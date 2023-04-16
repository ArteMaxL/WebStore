using Microsoft.AspNetCore.Mvc;
using WebStore.Datos;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAplicacionController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> lista = _context.TipoAplicaciones;
            return View(lista);
        }
        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {
            if (!ModelState.IsValid) { return View(tipoAplicacion); }

            _context.TipoAplicaciones.Add(tipoAplicacion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }

            var obj = _context.TipoAplicaciones.Find(Id);
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TipoAplicacion tipoAplicacion)
        {
            if (!ModelState.IsValid) { return View(tipoAplicacion); }

            _context.TipoAplicaciones.Update(tipoAplicacion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }

            var obj = _context.TipoAplicaciones.Find(Id);
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(TipoAplicacion tipoAplicacion)
        {
            if (tipoAplicacion == null) { return NotFound(); }

            _context.TipoAplicaciones.Remove(tipoAplicacion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
