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
            _context.TipoAplicaciones.Add(tipoAplicacion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
