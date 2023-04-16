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
    }
}
